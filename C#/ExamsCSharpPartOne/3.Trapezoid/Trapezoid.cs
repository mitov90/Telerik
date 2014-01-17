using System;
using System.Text;

class Trapezoid
{
    static void Main(string[] args)
    {
        int numLines = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();
        int leadingDots = numLines;
        int middleDots = numLines-1;
        const char dot = '.';
        const char aster = '*';

        for ( int i = 0; i <= numLines; i++ )
        {
            if (i == 0)
            {
                sb.Append(dot,leadingDots);
                sb.Append(aster, numLines);
                sb.Append(Environment.NewLine);
            }
            else if (i==numLines)
            {
                sb.Append(aster,numLines*2);
            }
            else
            {
                sb.Append(dot, --leadingDots);
                sb.Append(aster);
                sb.Append(dot, middleDots++);
                sb.Append(aster);
                sb.Append(Environment.NewLine);

            }

        }
        Console.WriteLine(sb);
    }
}
