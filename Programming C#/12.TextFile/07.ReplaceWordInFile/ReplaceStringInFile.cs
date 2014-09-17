using System;
using System.IO;

class ReplaceStringInFile
{
    static void Main()
    {
        const string OLD_VALUE = "start";
        const string NEW_VALUE = "finish";

        string sourceFile;

        do
        {
            Console.Write("Enter path: ");
            sourceFile = Console.ReadLine();
        }
        while ( !File.Exists(sourceFile) );

        string extention = Path.GetExtension(sourceFile);
        string output = sourceFile.Insert(sourceFile.LastIndexOf(extention), "_new");
        try
        {
            using ( StreamReader reader = new StreamReader(sourceFile) )
            {
                using ( StreamWriter writer = new StreamWriter(output) )
                {
                    string temp = reader.ReadLine();

                    while ( temp != null )
                    {
                        writer.WriteLine(temp.Replace(OLD_VALUE, NEW_VALUE));
                        temp = reader.ReadLine();
                    }
                }
            }
        }
        catch ( IOException ex )
        {
            Console.WriteLine(ex.Message);
        }
        catch ( UnauthorizedAccessException ex )
        {
            Console.WriteLine(ex.Message);
        }
    }
}
