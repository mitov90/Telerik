using System;
using System.Collections.Generic;
using System.IO;

class SortLinesInFile
{
    static void Main()
    {
        List<string> lines = new List<string>();
        using (StreamReader sr = new StreamReader("strings.txt"))
        {
            string tempLine = sr.ReadLine();
            while(tempLine!=null)
            {
                lines.Add(tempLine);
                tempLine = sr.ReadLine();
            }
        }
        if (lines.Count>0)
        {
            lines.Sort();
            using (StreamWriter sw = new StreamWriter("sortedStrings.txt"))
            {
                foreach ( var line in lines )
                {
                    sw.WriteLine(line);
                }
            }
        }
    }
}
