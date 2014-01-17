using System;

class NumbersToN
{
    static void Main()
    {
        int numberToN;
        do
        {
            Console.Write("Enter last number : ");
        }
        while ( !int.TryParse(Console.ReadLine(), out numberToN) || numberToN < 1 );

        for ( int i = 1; i <= numberToN; i++ )
        {
            Console.WriteLine(i);
        }
    }
}
