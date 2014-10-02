/*Write a program that reads a text file and inserts line
* numbers in front of each of its lines. The result should
* be written to another text file.
*/
using System;
using System.IO;

class AppendLineNumber
{
    static void Main()
    {
        using(StreamReader sr = new StreamReader("test.txt"))
        {
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                string line = sr.ReadLine();
                int curLine = 1;
                while(line!=null)
                {
                    sw.Write(curLine);
                    sw.Write(' ');
                    sw.WriteLine(line);
                    line = sr.ReadLine();
                    curLine++;
                }
            }
        }
       
    }
}