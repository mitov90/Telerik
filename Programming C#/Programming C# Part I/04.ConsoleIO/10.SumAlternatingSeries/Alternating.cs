using System;

class Alternating
{
    static void Main()
    {
        byte precision = 3;
        double temp = 0d;
        double sign = -1.0d;

        for ( int i = 1; i < 800; i++ )
        {
            sign = -sign;
            temp += sign * Math.Round((double)1 / i, precision);
        }
        Console.WriteLine(Math.Round(temp,precision));

    }
}

