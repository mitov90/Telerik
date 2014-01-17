using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceWordInFile
{
    private static string ReplaceWord(string input, string wordToFind, string replacement)
    {
        string pattern = String.Format(@"\b{0}\b", wordToFind);

        string result = Regex.Replace(input, pattern, replacement);
        return result;
    }

    static void Main()
    {
        const string NEW_VALUE = "finish";
        const string OLD_VALUE = "start";

        string sourceFile;
        string outputFile;

        InputFile(out sourceFile, out outputFile);

        try
        {
            using ( var reader = new StreamReader(sourceFile) )
            {
                using ( var writer = new StreamWriter(outputFile) )
                {
                    string temp = reader.ReadLine();

                    while ( temp != null )
                    {
                        writer.WriteLine(ReplaceWord(temp,OLD_VALUE,NEW_VALUE));
                        temp = reader.ReadLine();
                    }
                }
            }
        }
        catch(IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(UnauthorizedAccessException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("goodbey!");
        }
    }
        

    private static void InputFile(out string sourceFile, out string outputFile)
    {
        do
        {
            Console.Write("Enter path: ");
            sourceFile = Console.ReadLine();
        }
        while ( !File.Exists(sourceFile) );

        string extention = Path.GetExtension(sourceFile);
        outputFile = sourceFile.Insert(sourceFile.LastIndexOf(extention), "_new");
    }
}
