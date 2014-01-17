using System;

class CompareNumbers
{
    static void Main()
    {
        int a;
        int b;
        InputValues(out a, out b);

        Console.WriteLine("{0} is greater.", ( a + b + Math.Abs(a - b) ) / 2);

        //int max = a - ( ( a - b ) & ( ( a - b ) >> 31 ) );
        //Console.WriteLine("{0} is greater.", max);

        //int diff = a - b;
        //int sign = ( diff >> 31 ) & 1; 
        //long maxVal = a - sign * diff;
        //Console.WriteLine("{0} is greater.", maxVal);
    }

    private static void InputValues(out int a, out int b)
    {
        do
        {
            Console.Write("Enter first number to compare with: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out a) );
        do
        {
            Console.Write("Enter second number to compare with: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out b) );
    }
}
