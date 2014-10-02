using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

class ArrayNumericalSystem
{
    static string[] matches = { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };

    static void Main()
    {
        string input = Console.ReadLine();
        int curNumber = input.Length / 3 - 1;
        BigInteger result = 0;

        for ( int curSyllable = 0; curSyllable < input.Length; curSyllable += 3 )
        {
            result += GetValueFromString(input.Substring(curSyllable, 3)) * (BigInteger) Math.Pow(13, curNumber);
            curNumber--;
        }
        Console.WriteLine(result);
    }

    static int GetValueFromString(string input)
    {
        for ( int i = 0; i < matches.Length; i++ )
        {
            if ( input == matches[i] )
                return i;
        }
        return -1;
    }
}
