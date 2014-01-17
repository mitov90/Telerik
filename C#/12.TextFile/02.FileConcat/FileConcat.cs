using System;
using System.IO;

class FileConcat
{
    static void Main()
    {
        try
        {
            using ( StreamWriter sw = new StreamWriter("file3.txt") )
            {
                StreamReader sr = null;
                using ( sr = new StreamReader("file1.txt") )
                {
                    string file1 = sr.ReadToEnd();
                    sw.Write(file1);
                }

                using ( sr = new StreamReader("file2.txt") )
                {
                    string file2 = sr.ReadToEnd();
                    sw.Write(file2);
                }
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
