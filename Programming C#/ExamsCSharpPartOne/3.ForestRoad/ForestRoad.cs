using System;
using System.Text;

class ForestRoad
{
    static void Main()
    {
        int linesPerDirection = int.Parse(Console.ReadLine());
        int leadingDots = 0;
        char ch = '*';
        char dot  = '.';
        int switcher = 1;
        StringBuilder sb = new StringBuilder();

        for ( int i = 1; i < 2*linesPerDirection ; i++ )
        {
            if ( leadingDots+2 > linesPerDirection )
                switcher *= -1;
            sb.Append(dot,leadingDots);
            sb.Append(ch);
            sb.Append(dot, Math.Abs(linesPerDirection - leadingDots-1));
            sb.Append(Environment.NewLine);
            leadingDots += switcher;
        }
        Console.WriteLine(sb);
    }
}
