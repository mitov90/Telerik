using System;

class NestedComparison
{
    static void Main()
    {
        int first;
        int second;
        int third;
        int max=0;

        InputValues(out first, out second, out third);

        if (first>second)
        {
            if ( first > third )
                max = first;
            else
                max = third;
        }
        else
        {
            if ( second > third )
                max = second;
            else
                max = third;
        }
        Console.WriteLine("Max number: {0}",max);
    }

    private static void InputValues(out int first, out int second, out int third)
    {
        do
        {
            Console.Write("Enter fist value:");
        }
        while ( !int.TryParse(Console.ReadLine(), out first) );
        do
        {
            Console.Write("Enter second value:");
        }
        while ( !int.TryParse(Console.ReadLine(), out second) );
        do
        {
            Console.Write("Enter third value:");
        }
        while ( !int.TryParse(Console.ReadLine(), out third) );
    }
}

