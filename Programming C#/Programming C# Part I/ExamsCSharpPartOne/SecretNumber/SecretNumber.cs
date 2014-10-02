using System;
using System.Numerics;

class SecretNumber
{
    static void Main()
    {
        BigInteger number = BigInteger.Parse(Console.ReadLine());
        BigInteger specialSum = 0;
        if ( number < 0 )
            number *= -1;
        SecretSum(ref number, ref specialSum);
        Console.WriteLine(specialSum);

        if ( specialSum % 10 == 0 )
        {
            Console.WriteLine(number + " has no secret alpha-sequence");
            Environment.Exit(0);
        }

        char startLetter = (char) ('A' + ( specialSum % 26));
        for ( int i = 0; i < specialSum%10; i++ )
        {
            if (startLetter>'Z')
            {
                startLetter = 'A';
            }
            Console.Write(startLetter++);
            
        }


    }

    private static void SecretSum(ref BigInteger number, ref BigInteger specialSum)
    {
        int counter = 0;
        for ( BigInteger i = number; i != 0; i /= 10 )
        {
            counter++;

            if ( counter % 2 != 0 )
            {
                specialSum += ( i % 10 ) * counter * counter;
            }
            else
            {
                specialSum += ( i % 10 ) * ( i % 10 ) * counter;
            }
        }
    }
}