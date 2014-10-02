using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class RemoveDictonaryFromFile
{

    private static string RemoveWord(string input, string word)
    {
        string pattern = string.Format(@"\b{0}\b", word);
        string result = Regex.Replace(input, pattern, String.Empty);
        return result;
    }

    static void Main()
    {
        string sourceFilePath;
        string tempFilePath;
        try
        {
            var wordsFilePath = ReadPath(out sourceFilePath, out tempFilePath);

            var wordsToRemove = GetWordsToRemove(wordsFilePath);

            RemoveWordsToFile(sourceFilePath, tempFilePath, wordsToRemove);

            File.Delete(sourceFilePath);
            File.Move(tempFilePath, sourceFilePath);
        }
        catch ( IOException e)
        {
            Console.WriteLine(e.Message);
        }
        catch ( ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch ( UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
        }
        catch ( Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static string ReadPath(out string sourceFilePath, out string tempFilePath)
    {
        string wordsFilePath;

        do
        {
            Console.Write("Enter the path of the file containing words to remove: ");
            wordsFilePath = Console.ReadLine();
        } while ( !File.Exists(wordsFilePath) );

        do
        {
            Console.Write("Enter the path of a file in the local file system: ");
            sourceFilePath = Console.ReadLine();
        } while ( !File.Exists(sourceFilePath) );

        string extension = Path.GetExtension(sourceFilePath);

        tempFilePath = sourceFilePath.Insert(sourceFilePath.LastIndexOf(extension), "_tmp");
        return wordsFilePath;
    }

    private static void RemoveWordsToFile(string sourceFilePath, string tempFilePath, List<string> wordsToRemove)
    {
        using ( var reader = new StreamReader(sourceFilePath) )
        {
            using ( var writer = new StreamWriter(tempFilePath) )
            {
                string line;

                while ( ( line = reader.ReadLine() ) != null )
                {
                    line = wordsToRemove.Aggregate(line, RemoveWord);

                    writer.WriteLine(line);
                }
            }
        }
    }

    private static List<string> GetWordsToRemove(string wordsFilePath)
    {
        List<string> wordsToRemove = new List<string>();

        using ( var reader = new StreamReader(wordsFilePath) )
        {
            string line;
            while ( ( line = reader.ReadLine() ) != null )
            {
                wordsToRemove.Add(line);
            }
        }
        return wordsToRemove;
    }
}
