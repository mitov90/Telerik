using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

internal class WordCounter
{
    private static IEnumerable<KeyValuePair<string, int>> GetWordOccurrences(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentException("path cannot be null or empty.", "path");
        }

        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Could not find the file specified.", path);
        }

        var occurrences = new Dictionary<string, int>();

        using (var reader = new StreamReader(path))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split(
                    new[] { ' ', ',', ';', '.', '?', '!', '"', '\'', ':', '_' },
                    StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    var wordNoCaps = word.ToLower();
                    if (!occurrences.ContainsKey(wordNoCaps))
                    {
                        occurrences[wordNoCaps] = 1;
                    }
                    else
                    {
                        occurrences[wordNoCaps]++;
                    }
                }
            }
        }

        var occurrencesSorted =
            from entry in occurrences
            orderby entry.Value ascending
            select entry;

        return occurrencesSorted;
    }

    private static void Main()
    {
        const string SourceFilePath = "../../Resources/PrideAndPrejudice.txt";
        const string ResultFilePath = "../../Resources/result.txt";

        var occurrences = GetWordOccurrences(SourceFilePath);

        StringBuilder result = new StringBuilder();

        int index = 0;

        foreach (var occurrence in occurrences)
        {
            index++;
            result.AppendFormat(
                "{0, 5}. {1} -> {2}{3}",
                index,
                occurrence.Key,
                occurrence.Value,
                Environment.NewLine);
        }

        File.WriteAllText(ResultFilePath, result.ToString());
    }
}
