using System;
using System.Numerics;

class Fruits
{
    static void Main()
    {
        BigInteger goshkoNumber = BigInteger.Parse(Console.ReadLine());
        if ( goshkoNumber < 0 )
            goshkoNumber = -goshkoNumber;

        BigInteger oddSum = 0;
        BigInteger evenSum = 0;
        for ( int i = 0; goshkoNumber!=0; i++ )
        {
            BigInteger tempp = goshkoNumber %  (BigInteger)10;
            goshkoNumber /= 10;
            if ( tempp % 2 == 0 )
                evenSum += tempp;
            else
                oddSum += tempp;
        }
        if (oddSum>evenSum)
            Console.WriteLine("oranges {0}", oddSum);
        else if (evenSum>oddSum)
            Console.WriteLine("apples {0}",evenSum);
        else
            Console.WriteLine("both {0}",evenSum);
    }
}

