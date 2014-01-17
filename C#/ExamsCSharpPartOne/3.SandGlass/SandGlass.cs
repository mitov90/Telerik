using System;
using System.Text;

class SandGlass
{
    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        int numLines = int.Parse(Console.ReadLine());
        const char dot = '.';
        const char aster = '*';
        int middleAster = numLines;
        int leadingDots = 0;
        int changePerLine = 2;
        for ( int i = 0; i < numLines; i++ )
        {
            sb.Append(dot, leadingDots);
            sb.Append(aster, middleAster);
            sb.Append(dot, leadingDots);
            sb.Append(Environment.NewLine);
            if ( i == numLines / 2 )
                changePerLine = -changePerLine;
            middleAster -= changePerLine;
            leadingDots += changePerLine/2;
        }
        Console.WriteLine(sb);
    }
}
