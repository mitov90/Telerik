using System;

class CompareAndExchange
{
    static void Main()
    {
        int a;
        int b;

        do
        {
            Console.WriteLine("Enter first value a: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out a) );
        do
        {
            Console.WriteLine("Enter second value b: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out b) );

        if ( a > b )
        {
            SwapInt(ref a, ref b);
            Console.WriteLine("Num a greater than b and swapped");
            Console.WriteLine("a= {0}, b= {1}",a,b);
        }
        else
        {
            Console.WriteLine("Num b smaller or equal to a. No swap");
            Console.WriteLine("a= {0}, b= {1}", a, b);
        }
    }

    static void SwapInt(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}
