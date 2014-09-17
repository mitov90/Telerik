using System;

class Program
{
    static void Main()
    {
        double first;
        double second;
        double third;
        bool isNegative = false;

        ValuesInput(out first, out second, out third);
        if ( first == 0 || second == 0 || third == 0 )
            Console.WriteLine("Zero.. no sign!");
        else
        {
            if ( first < 0 )
            {
                if ( second < 0 )
                {
                    if ( third < 0 )
                        isNegative = true;
                }
                else
                {
                    if ( !( third < 0 ) )
                        isNegative = true;
                }
            }
            else
            {
                if ( second < 0 )
                {
                    if ( !( third < 0 ) )
                        isNegative = true;
                }
                else
                {
                    if ( third < 0 )
                        isNegative = true;
                }
            }
            Console.WriteLine("The sign of product is {0}", isNegative ? "-" : "+");
        }
    }

    private static void ValuesInput(out double first, out double second, out double third)
    {
        do
        {
            Console.WriteLine("Enter first num: ");
        }
        while ( !double.TryParse(Console.ReadLine(), out first) );
        do
        {
            Console.WriteLine("Enter second num: ");
        }
        while ( !double.TryParse(Console.ReadLine(), out second) );
        do
        {
            Console.WriteLine("Enter third num: ");
        }
        while ( !double.TryParse(Console.ReadLine(), out third) );
    }
}
