using System;
using System.Numerics;
class Factoriel
{
    static void Main()
    {
        int numN;
        int numK;
        BigInteger result = 1;
        InputValues(out numN, out numK);

        for ( int i = numK+1; i <= numN; i++ )
        {
            result *= i;
        }
        Console.WriteLine("{0}!/{1}!={2}", numN, numK, result);
    }

    private static void InputValues(out int numN, out int numK)
    {
        do
        {
            Console.Write("Enter number (n>0): ");
        }
        while ( !int.TryParse(Console.ReadLine(), out numN) || numN < 0 );
        do
        {
            Console.Write("Enter number (0<k<{0}): ", numN);
        }
        while ( !int.TryParse(Console.ReadLine(), out numK) || numK < 0 || numK > numN - 1 );
    }
}
