using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class FileDictonary
{
    private static int CountWord(string input, string word)
    {
        int count = 0;

        var pattRegex = new Regex(string.Format(@"\b{0}\b", word));
        var match = pattRegex.Match(input);
        while ( match.Success )
        {
            count++;
            match = match.NextMatch();
        }

        return count;
    }

    static void Main()
    {
        try
        {
            string tempFilePath;
            string sourceFilePath;
            var wordsFilePath = ReadPath(out sourceFilePath, out tempFilePath);

            var wordsToCount = GetWordsDictonary(wordsFilePath, sourceFilePath);

            using ( var writer = new StreamWriter(tempFilePath, false) )
            {
                foreach ( var pair in wordsToCount.OrderByDescending(key => key.Value) )
                {
                    writer.WriteLine(pair.Key + " " + pair.Value);
                }
            }
        }
        catch ( IOException e )
        {
            Console.WriteLine(e.Message);
        }
        catch ( ArgumentException e )
        {
            Console.WriteLine(e.Message);
        }
        catch ( UnauthorizedAccessException e )
        {
            Console.WriteLine(e.Message);
        }
        catch ( Exception e )
        {
            Console.WriteLine(e.Message);
        }

    }

    private static string ReadPath(out string sourceFilePath, out string tempFilePath)
    {
        string wordsFilePath;

        do
        {
            Console.Write("Enter the path of the file containing words to count: ");
            wordsFilePath = Console.ReadLine();
        } while ( !File.Exists(wordsFilePath) );

        do
        {
            Console.Write("Enter the path of a file in the local file system: ");
            sourceFilePath = Console.ReadLine();
        } while ( !File.Exists(sourceFilePath) );

        tempFilePath = "result.txt";

        return wordsFilePath;
    }

    private static Dictionary<string, int> GetWordsDictonary(string wordsFilePath, string sourceFilePath)
    {
        var wordsToCount = new Dictionary<string, int>();

        using ( var reader = new StreamReader(sourceFilePath) )
        {
            string input = reader.ReadToEnd();

            using ( var readerWords = new StreamReader(wordsFilePath) )
            {

                string line;
                while ( ( line = readerWords.ReadLine() ) != null )
                {
                    wordsToCount.Add(line, CountWord(input, line));
                }
            }
        }
        return wordsToCount;
    }
}
