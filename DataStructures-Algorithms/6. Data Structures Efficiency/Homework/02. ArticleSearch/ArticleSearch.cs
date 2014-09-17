using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using Wintellect.PowerCollections;

internal class ArticleSearch
{
    private const string Chars =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789~`!@#$%^&*()-_=+[{]};:'\",<.>/? ";

    private static readonly Random RandomNumberGenerator = new Random();

    private static string GetRandomString(int size)
    {
        var buffer = new char[size];
        int length = Chars.Length;

        for (int i = 0; i < size; i++)
        {
            buffer[i] = Chars[RandomNumberGenerator.Next(length)];
        }

        return new string(buffer);
    }

    private static string[] GetRandomStringArray(int length, int stringMaxSize)
    {
        var value = new string[length];

        for (int i = 0; i < value.Length; i++)
        {
            value[i] = GetRandomString(RandomNumberGenerator.Next(1, stringMaxSize + 1));
        }

        return value;
    }

    private static double[] GetRandomDoubleArray(int length, double maxValue)
    {
        var value = new double[length];

        for (int i = 0; i < value.Length; i++)
        {
            value[i] = RandomNumberGenerator.NextDouble() * maxValue;
        }

        return value;
    }

    private static void GetRangeBounds(double maxValue, out double lowerBound, out double upperBound)
    {
        double midValue = RandomNumberGenerator.NextDouble() * maxValue;

        lowerBound = RandomNumberGenerator.NextDouble() * midValue;
        upperBound = midValue + RandomNumberGenerator.NextDouble() * (maxValue - midValue);
    }

    private static void CreateArticlesFile(string path, int articlesCount, double maxPrice, int stringMaxSize)
    {
        double[] pricesArray = GetRandomDoubleArray(articlesCount, maxPrice);
        string[] barcodesArray = GetRandomStringArray(articlesCount, stringMaxSize);
        string[] vendorsArray = GetRandomStringArray(articlesCount, stringMaxSize);
        string[] titlesArray = GetRandomStringArray(articlesCount, stringMaxSize);

        using (StreamWriter writer = new StreamWriter(path, false))
        {
            for (int i = 0; i < articlesCount; i++)
            {
                writer.WriteLine(
                    "{0,10:F2} | {1} | {2} | {3}",
                    pricesArray[i],
                    barcodesArray[i],
                    vendorsArray[i],
                    titlesArray[i]);
            }
        }
    }

    private static OrderedBag<Article> ReadArticles(string path)
    {
        OrderedBag<Article> articles = new OrderedBag<Article>();

        using (StreamReader reader = new StreamReader(path))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');

                double price = double.Parse(data[0]);

                Article article = new Article(
                    price,
                    data[1].Trim(),
                    data[2].Trim(),
                    data[3].Trim());

                articles.Add(article);
            }
        }

        return articles;
    }

    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        const string ArticlesFilePath = "../../Resources/Articles.txt";
        const string ResultsFilePath = "../../Resources/Results.txt";
        const double PriceMaxValue = 100000.0;
        const int ArticlesCount = 500000;
        const int SearchesCount = 10000;
        const int StringMaxSize = 50;
        const int ExtractSize = 20;

        var stopwatch = Stopwatch.StartNew();

        CreateArticlesFile(ArticlesFilePath, ArticlesCount, PriceMaxValue, StringMaxSize);

        stopwatch.Stop();
        Console.WriteLine("Articles file created for {0} second(s).", stopwatch.ElapsedMilliseconds / 1000);
        stopwatch.Restart();

        OrderedBag<Article> articles = ReadArticles(ArticlesFilePath);

        // Another solution would be to use OrderedMultiDictionary<double, Article>
        // (The keys are the article prices). In this case the Range() method would be
        // articles.Range(lowerPrice, true, upperPrice, true).
        using (var writer = new StreamWriter(ResultsFilePath, false))
        {
            for (int i = 0; i < SearchesCount; i++)
            {
                double lowerPrice;
                double upperPrice;
                GetRangeBounds(PriceMaxValue, out lowerPrice, out upperPrice);
                // Wintellect OrderedBag<T>.Range takes constant time.
                var extract = articles.Range(
                    new Article(lowerPrice, "N/A", "N/A", "N/A"),
                    true,
                    new Article(upperPrice, "N/A", "N/A", "N/A"),
                    true).Take(ExtractSize);

                writer.WriteLine(Environment.NewLine + "====================================");
                writer.WriteLine(
                    "{0}. First {1} articles in the price range from {2:F2} to {3:F2}:",
                    i + 1,
                    ExtractSize,
                    lowerPrice,
                    upperPrice);

                int index = 0;
                foreach (var article in extract)
                {
                    writer.WriteLine("{0,4}. {1}", ++index, article);
                }
            }
        }

        stopwatch.Stop();

        Console.WriteLine("Time elapsed: {0} minutes", stopwatch.ElapsedMilliseconds / 60000);
    }
}
