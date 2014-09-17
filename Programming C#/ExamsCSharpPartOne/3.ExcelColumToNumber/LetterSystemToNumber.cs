using System;
using System.Numerics;
using System.IO;

class LetterSystemToNumber
{
    static void Main()
    {
        if ( Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug") )
        {
            Console.SetIn(new StreamReader("test.txt"));
        }
        BigInteger result = 0;
        byte numLines = byte.Parse(Console.ReadLine());

        for ( int i = 0; i < numLines; i++ )
        {
            int tempCol = char.Parse(Console.ReadLine()) - 'A' + 1;

            if ( i == numLines - 1 )
            {
                result += tempCol;
                continue;
            }
            BigInteger powerOfLetter = 1;
            for ( int j = 1; j < numLines-i; j++ )
            {
                powerOfLetter *= 26;
            }
            result += powerOfLetter * tempCol;
        }
        Console.WriteLine(result);
    }
}