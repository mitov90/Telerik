using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Numerics;
class AmericanPie
{
    static void Main()
    {
        checked
        {
            BigInteger A = BigInteger.Parse(Console.ReadLine());
            BigInteger B = BigInteger.Parse(Console.ReadLine());
            BigInteger C = BigInteger.Parse(Console.ReadLine());
            BigInteger D = BigInteger.Parse(Console.ReadLine());

            BigInteger den = B * D;
            BigInteger num = A * D + C * B;
            BigInteger result = num / den;

            if ( result >= 1 )
                Console.WriteLine(result);
            else
            {
                Console.WriteLine("{0:0.00000000000000000000}", Math.Round((decimal)num / (decimal)den, 20));
            }
            Console.WriteLine(num + "/" + den);
        }
    }
}