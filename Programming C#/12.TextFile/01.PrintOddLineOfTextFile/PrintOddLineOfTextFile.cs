using System;
using System.IO;

class PrintOddLineOfTextFile
{
    static void Main()
    {
        StreamReader sr = null;
        try
        {
            sr = new StreamReader("text.txt");

            string line = sr.ReadLine();
            int curLine = 1 ;
            while ( line != null )
            {
                if ( curLine % 2 != 0 )
                    Console.WriteLine(line);
                line = sr.ReadLine();
                curLine++;
            }
        }
            catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            if ( sr != null )
                sr.Close();
        }
    }
}