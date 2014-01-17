using System;
using System.Numerics;
using System.Collections.Generic;

class FactorialCalc
{
    static void Main()
    {
        int numN;
        int numK;
        InputValues(out numN, out numK);
        BigInteger[] facValues = new BigInteger[Math.Max(numN, numK)+1];
        PopulateFactorialValues(numK, facValues);
        BigInteger result = facValues[numN] * facValues[numK] / facValues[( numK - numN )];
        Console.WriteLine("{0}!*{1}!/({1}-{0})!={2}",numN,numK,result);
    }

    private static void PopulateFactorialValues(int number, BigInteger[] facValues)
    {
        facValues[0] = 0;
        facValues[1] = 1;
        for ( int i = 2; i <= number; i++ )
        {
            facValues[i] = facValues[i - 1] * i;
        }
    }

    private static void InputValues(out int numN, out int numK)
    {
        do
        {
            Console.Write("Enter number n > 1 : ");
        }
        while ( !int.TryParse(Console.ReadLine(), out numN) || numN < 1 );
        do
        {
            Console.Write("Enter number K>{0}: ", numN);
        }
        while ( !int.TryParse(Console.ReadLine(), out numK) || numK <= numN );
    }
}
