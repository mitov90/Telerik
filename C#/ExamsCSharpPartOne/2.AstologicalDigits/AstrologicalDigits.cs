using System;
using System.Numerics;

class AstrologicalDigits
{
    static void Main(string[] args)
    {
        BigInteger value = BigInteger.Parse(Console.ReadLine().Replace('.','0'));
        if ( value < 0 )
            value = -value;
        while (true)
        {
            if ( value <= 9 )
                break;
            value = AstroSum(value);
        }
        Console.WriteLine(AstroSum(value));
    }

    static BigInteger AstroSum (BigInteger value)
    {
        BigInteger result = 0;
        int digitsInNumber = value.ToString().Length;
        //digits in number = Math.Floor(Math.Log10(number)+1);
        for ( int i = 0; i < digitsInNumber; i++ )
        {
            result += value % 10;
            value /= 10;
        }
        return result;
    }
}
