using System;

class GCD
{
    static void Main()
    {
        int firstNum;
        int secondNum;
        InputValues(out firstNum, out secondNum);

        Console.WriteLine("Greatest common divisor of {0} and {1} is {2}", firstNum, secondNum, GratestCommonDivisor2(firstNum,secondNum));
    }

    private static void InputValues(out int firstNum, out int secondNum)
    {
        do
        {
            Console.Write("Enter first number: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out firstNum) );
        do
        {
            Console.Write("Enter second number: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out secondNum) );
    }

    static int GCMrecursive(int a, int b)
    {
        if ( b == 0 )
            return a;
        return GCMrecursive(a, b % a);
    }

    static int GratestCommonDivisor2(int a, int b)
    {
        while (a!=b)
        {
            if ( a > b )
                a -= b;
            else
                b -= a;
        }
        return a;
    }

    static int GreatestCommonDivisor(int a, int b)
    {
        while ( b != 0 )
        {
            int temp = b;
            b =b% a;
            a = temp;
        }
        return a;
    }
}