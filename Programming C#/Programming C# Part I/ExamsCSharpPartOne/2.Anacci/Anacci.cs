using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class Anacci
{
    static char[] alphabet = new char[27];

    static void Main()
    {
        if ( Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug") )
        {
            Console.SetIn(new StreamReader("test.txt"));
        }

        for ( int i = 'A'; i <= 'Z'; i++ )
        {
            alphabet[i - (int)'A' + 1] = (char)i;
        }
        alphabet[0] = 'Z';

        int first = char.Parse(Console.ReadLine()) - 'A' + 1;
        int second = char.Parse(Console.ReadLine()) - 'A' + 1;
        int numLines = int.Parse(Console.ReadLine());
        int curAnacci = second;
        StringBuilder sb = new StringBuilder();
        int whiteSpaces = 0;

        for ( int i = 0; i < numLines; i++ )
        {
            if ( i == 0 )
            {
                sb.Append(alphabet[first]);
                sb.Append(Environment.NewLine);
                continue;
            }
            if ( i == 1 )
            {
                sb.Append(alphabet[second]);
                sb.Append(NextAnacci(ref first, ref second, ref curAnacci));
                sb.Append(Environment.NewLine);
                continue;
            }
            whiteSpaces++;
            sb.Append(NextAnacci(ref first, ref second, ref curAnacci));
            sb.Append(' ', whiteSpaces);
            sb.Append(NextAnacci(ref first, ref second, ref curAnacci));

            sb.Append(Environment.NewLine);
        }

        Console.WriteLine(sb);
    }

    static char NextAnacci(ref int first, ref int second, ref int curAnacci)
    {
        curAnacci = ( first + second ) % 26;
        first = second;
        second = curAnacci;

        return alphabet[curAnacci];
    }
}
