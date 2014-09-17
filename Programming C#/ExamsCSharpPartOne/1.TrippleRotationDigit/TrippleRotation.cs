using System;

class TrippleRotation
{
    static void Main(string[] args)
    {
        int value = int.Parse(Console.ReadLine());

        for ( int i = 0; i < 3; i++ )
        {
            int temp = value % 10;
            int powerOfTen = PowerOfTen(NumberDigits(value));
            value += temp * powerOfTen;
            value /= 10;
        }
        Console.WriteLine(value);
    }

    static int PowerOfTen(int num)
    {
        int result = 1;
        for ( int i = 0; i < num; i++ )
        {
            result *= 10;
        }
        return result;
    }
    static int NumberDigits(int value)
    {
        int counter = 0;
        while (value != 0)
        {
            counter++;
            value /= 10;
        }
        return counter;
    }
}
