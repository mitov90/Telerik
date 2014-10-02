using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

internal class AhoCorasickStringSearcherDemo
{
    private static void Main()
    {
        var sourceFilePath = "../../Resources/PrideAndPrejudice.txt";
        var wordsFilePath = "../../Resources/Words.txt";
        var resultFilePath = "../../Resources/Result.txt";

        var text = File.ReadAllText(sourceFilePath);
        var words = File.ReadAllLines(wordsFilePath);

        var searcher = new AhoCorasickStringSearcher(words);

        searcher.OutputTree(Console.Out);

        var results = searcher.FindAll(text, 0);

        var occurrences = new SortedDictionary<string, int>();

        // put the results in a dictionary  
        foreach (var result in results)
        {
            if (!occurrences.ContainsKey(result.Value))
            {
                occurrences[result.Value] = 1;
            }
            else
            {
                occurrences[result.Value]++;
            }
        }

        var statistics = new StringBuilder();

        var index = 0;

        foreach (var occurrence in occurrences)
        {
            index++;
            statistics.AppendFormat(
                "{0, 5}. {1} -> {2}{3}", 
                index, 
                occurrence.Key, 
                occurrence.Value, 
                Environment.NewLine);
        }

        File.WriteAllText(resultFilePath, statistics.ToString());
    }
}