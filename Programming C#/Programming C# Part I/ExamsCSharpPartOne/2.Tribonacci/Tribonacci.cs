using System;
using System.Numerics;

class Tribonacci
{
    static void Main(string[] args)
    {
        BigInteger result = 0;
        BigInteger firstTrib = BigInteger.Parse(Console.ReadLine());
        BigInteger secondTrib = BigInteger.Parse(Console.ReadLine());
        BigInteger tempTrib = BigInteger.Parse(Console.ReadLine());
        int numTrib = int.Parse(Console.ReadLine());
        if ( numTrib == 0 )
            Console.WriteLine(0);
        else if (numTrib==1)
            Console.WriteLine(firstTrib);
        else if (numTrib==2)
            Console.WriteLine(secondTrib);
        else if ( numTrib == 3 )
            Console.WriteLine( tempTrib);
        else
        {
            result = firstTrib + secondTrib + tempTrib;
            for ( int i = 3; i < numTrib -1; i++ )
            {
                firstTrib = secondTrib;
                secondTrib = tempTrib;
                tempTrib = result;
                result = firstTrib + secondTrib + tempTrib;
            }
            Console.WriteLine(result);

        }
    }
}
