using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

using Wintellect.PowerCollections;

internal class ProductSearch
{
    private const string Chars =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789~`!@#$%^&*()-_=+[{]};:'\",<.>/? ";

    private static readonly Random RandomNumberGenerator = new Random();

    private static string GetRandomString(int size)
    {
        var buffer = new char[size];
        var length = Chars.Length;

        for (var i = 0; i < size; i++)
        {
            buffer[i] = Chars[RandomNumberGenerator.Next(length)];
        }

        return new string(buffer);
    }

    private static string[] GetRandomStringArray(int length, int stringMaxSize)
    {
        var value = new string[length];

        for (var i = 0; i < value.Length; i++)
        {
            value[i] = GetRandomString(RandomNumberGenerator.Next(1, stringMaxSize + 1));
        }

        return value;
    }

    private static double[] GetRandomDoubleArray(int length, double maxValue)
    {
        var value = new double[length];

        for (var i = 0; i < value.Length; i++)
        {
            value[i] = RandomNumberGenerator.NextDouble() * maxValue;
        }

        return value;
    }

    private static void GetRangeBounds(double maxValue, out double lowerBound, out double upperBound)
    {
        var midValue = RandomNumberGenerator.NextDouble() * maxValue;

        lowerBound = RandomNumberGenerator.NextDouble() * midValue;
        upperBound = midValue + RandomNumberGenerator.NextDouble() * (maxValue - midValue);
    }

    private static void CreateProductsFile(string path, int productsCount, double maxPrice, int nameMaxLength)
    {
        var pricesArray = GetRandomDoubleArray(productsCount, maxPrice);
        var namesArray = GetRandomStringArray(productsCount, nameMaxLength);

        using (var writer = new StreamWriter(path, false))
        {
            for (var i = 0; i < productsCount; i++)
            {
                writer.WriteLine("{0} | {1:F2}", namesArray[i], pricesArray[i]);
            }
        }
    }

    private static OrderedMultiDictionary<double, string> ReadProducts(string path)
    {
        var products = new OrderedMultiDictionary<double, string>(true);

        using (var reader = new StreamReader(path))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                var data = line.Split('|');
                products.Add(double.Parse(data[1]), data[0].Trim());
            }
        }

        return products;
    }

    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        var productsFilePath = "../../Resources/Products.txt";
        var resultsFilePath = "../../Resources/Results.txt";

        var productsCount = 500000;
        var searchesCount = 10000;
        var priceMaxValue = 100000.0;
        var nameMaxLength = 50;
        var extractSize = 20;

        CreateProductsFile(productsFilePath, productsCount, priceMaxValue, nameMaxLength);

        var products = ReadProducts(productsFilePath);

        // Another solution would be to use OrderedBag<Product> (Product implements IComparable<Product>
        // by comparing product prices). In this case the Range() method would be something like
        // products.Range(new Product("xxx", lowerPrice), true, new Product("xxx", upperPrice), true).
        using (var writer = new StreamWriter(resultsFilePath, false))
        {
            for (var i = 0; i < searchesCount; i++)
            {
                double upperPrice;
                double lowerPrice;
                GetRangeBounds(priceMaxValue, out lowerPrice, out upperPrice);
                var extract = products.Range(lowerPrice, true, upperPrice, true).Take(extractSize);

                writer.WriteLine(Environment.NewLine + "====================================");
                writer.WriteLine(
                    "{0}. First {1} products in the price range from {2:F2} to {3:F2}:", 
                    i + 1, 
                    extractSize, 
                    lowerPrice, 
                    upperPrice);

                var index = 0;

                foreach (var pair in extract)
                {
                    foreach (var name in pair.Value)
                    {
                        index++;
                        if (index > extractSize)
                        {
                            break;
                        }

                        writer.WriteLine("{0,3}. {1} | {2:F2}", index, name, pair.Key);
                    }

                    if (index > extractSize)
                    {
                        break;
                    }
                }
            }
        }
    }
}