using System;

class Modile5Distance
{
    static void Main()
    {
        uint first ;
        uint second;
        do
        {
            Console.Write("Enter start number: ");
        }
        while ( !uint.TryParse(Console.ReadLine(), out first) );
        do
        {
            Console.Write("Enter last number: ");
        }
        while ( !uint.TryParse(Console.ReadLine(), out second) );

        uint result = Mudule5FirstNum(first);
        if ( result > second )
            Console.WriteLine(" -> 0");
        else
        {
            uint counter = 1;
            for ( uint i = result; i < second; i+=5 )
            {
                counter++;
            }
            Console.WriteLine("-> {0}", counter);
        }
    }

    private static uint Mudule5FirstNum(uint result)
    {
        for ( int i = 0; i < 6; i++ )
        {
            if ( result % 5 == 0 )
                return result;
            else
                result++;
        }
        throw new InvalidOperationException();
    }
}

