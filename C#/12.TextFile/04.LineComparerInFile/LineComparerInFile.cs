using System;
using System.Collections.Generic;
using System.IO;

class LineComparerInFile
{
    static void Main()
    {
        List<int> same = new List<int>();
        List<int> diffrent = new List<int>();

        try
        {
            using ( StreamReader firstFile = new StreamReader("file1.txt") )
            {
                using ( StreamReader secondFile = new StreamReader("file2.txt") )
                    CompareLines(same, diffrent, firstFile, secondFile);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        PrintLineNumbers(same, diffrent);
    }

    private static void PrintLineNumbers(List<int> same, List<int> diffrent)
    {
        Console.WriteLine("Number of line that are equal in both files: ");
        foreach ( var line in same )
        {
            Console.WriteLine(line);
        }
        Console.WriteLine("Number of line that are NOT equal: ");
        foreach ( var line in diffrent )
        {
            Console.WriteLine(line);
        }
    }

    private static void CompareLines(List<int> same, List<int> diffrent, StreamReader firstFile, StreamReader secondFile)
    {
        int curLine = 0;
        while ( true )
        {
            string firstLine = firstFile.ReadLine();
            curLine++;

            if ( firstLine == null )
                break;

            if ( firstLine == secondFile.ReadLine() )
            {
                same.Add(curLine);
            }
            else
            {
                diffrent.Add(curLine);
            }
        }
    }
}