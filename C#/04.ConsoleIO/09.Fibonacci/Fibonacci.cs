using System;
using System.Numerics;
using System.Numerics.BigInteger;

class Fibonacci
{
    static void Main()
    {
        //Console.WriteLine(FibonacciReccursive(100)); //slow
        Console.WriteLine(FibonacciIterative(1000));
        Console.WriteLine(FibonacciIterativeMem( 1000 )); 
    }

    static uint FibonacciReccursive(uint num)
    {
        if ( num == 1 )
            return 0;
        if ( num == 2 )
            return 1;
        return FibonacciReccursive(num - 2) + FibonacciReccursive(num - 1);
    }

    static uint FibonacciIterativeMem(uint num)
    {
        uint[] values = new uint[num];
        values[0] = 0;
        values[1] = 1;
        for ( int i = 2; i < num; i++ )
        {
            values[i] = values[i - 2] + values[i - 1];
        }
        return values[num - 1];
    }

    static uint FibonacciIterative(uint num)
    {
        uint tempCached = 0;
        uint FibA = 0;
        uint FibB = 1;

        for ( int i = 2; i < num; i++ )
        {
            tempCached = FibA + FibB;
            FibA = FibB;
            FibB = tempCached;
        }

        return FibB;
    }

}
