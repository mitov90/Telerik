#region

using System;
using System.IO;
using System.Text.RegularExpressions;

#endregion

internal class DeletePrefixFromWords
{
    private static string ReplaceWordPrefix(string input, string prefix)
    {
        string pattern = String.Format(@"\b{0}\w+\b", prefix);
        string result = Regex.Replace(input, pattern, string.Empty);
        return result;
    }

    private static void Main()
    {
        const string prefix = "test";

        string sourcefilePath;
        string outputFile;
        if ( GetPath(out sourcefilePath, out outputFile) )
            return;

        using ( var reader = new StreamReader(sourcefilePath) )
        {
            using ( var writer = new StreamWriter(outputFile, false) )
            {

                 string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(ReplaceWordPrefix(line, prefix));
                    }

            }

        }
    }

    private static bool GetPath(out string sourcefilePath, out string outputFile)
    {
        do
        {
            Console.Write("Enter the path of a file in the local file system: ");
            sourcefilePath = Console.ReadLine();
        } while ( !File.Exists(sourcefilePath) );

        string extention = Path.GetExtension(sourcefilePath);
        outputFile = sourcefilePath.Insert(sourcefilePath.LastIndexOf(extention), "_out");

        return false;
    }
}
