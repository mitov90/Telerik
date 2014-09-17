using System;

class PrintSequence
{
    static void Main()
    {
        for ( int i = 2; i <= 12; i++ )
        {
            int y = i;
            if ( i % 2 != 0 )
                y=-i;
            Console.WriteLine(y);
        }
    }
}
