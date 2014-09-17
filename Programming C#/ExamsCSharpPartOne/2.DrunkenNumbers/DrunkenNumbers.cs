using System;
using System.Numerics;

class DrunkenNumbers
{
    static void Main()
    {
        byte rounds = byte.Parse(Console.ReadLine());
        BigInteger mitkoBeers=0;
        BigInteger vladkoBeers=0;

        for ( byte i = 0; i < rounds; i++ )
        {
            long numberInput = long.Parse(Console.ReadLine());
            if ( numberInput < 0 )
                numberInput *= -1;
            long digitsInNumber = (long)numberInput.ToString().Length;
            long mitkoNums = (long) numberInput / (long) Math.Pow(10, digitsInNumber / 2);
            long vladkoNums = (long) numberInput % (long) Math.Pow(10,Math.Ceiling((double)digitsInNumber/2));

            mitkoBeers += CalcBeers(mitkoNums);
            vladkoBeers += CalcBeers(vladkoNums);
        }

        if (mitkoBeers==vladkoBeers)
            Console.WriteLine("No " + (mitkoBeers + vladkoBeers));
        else
        Console.WriteLine("{0} {1}", mitkoBeers>vladkoBeers?"M":"V", Math.Abs((decimal)mitkoBeers-(decimal)vladkoBeers));
        

        


    }

    private static long CalcBeers(long numberToSumFrom)
    {
        long tempBeer = 0;
        for ( long j = numberToSumFrom; j != 0; j /= 10 )
        {
            tempBeer += j % 10;
        }
        return (long)tempBeer;
    }
}
