using System;
using System.Text;

class FirTree
{
    static void Main(string[] args)
    {
        int numLines = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();
        int magicNumber = 2;
        int leadingDots = numLines - magicNumber;
        int numAster = 1;
        const char dot = '.';
        const char aster = '*';

        for ( int i = 0; i < numLines - 1; i++ )
        {
            sb.Append(dot, leadingDots);
            sb.Append(aster, numAster);
            sb.Append(dot, leadingDots);
            sb.Append(Environment.NewLine);
            leadingDots -= 1;
            numAster += magicNumber;
        }
        sb.Append(dot, numLines - magicNumber);
        sb.Append(aster);
        sb.Append(dot, numLines - magicNumber);
        Console.WriteLine(sb);
    }
}
