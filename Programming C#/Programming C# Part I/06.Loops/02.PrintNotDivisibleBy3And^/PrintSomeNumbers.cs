using System;

class PrintSomeNumbers
{
    static void Main()
    {
        int num;
        do
        {
            Console.Write("Enter last number: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out num) || num < 1 );

        for ( int i = 1; i <= num; i++ )
        {
            if (!(i%3 == 0 && i%7 == 0))
            Console.Write("{0,5} ", i);
            if ( i % 8 == 0 )
                Console.WriteLine();
        }
    }
}
