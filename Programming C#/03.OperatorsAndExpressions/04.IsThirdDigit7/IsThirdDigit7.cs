using System;

class IsThirdDigit7
{
    static void Main()
    {
        int value;
        do
        {
            Console.Write("Enter number to check third digit: ");
        } while ( !int.TryParse(Console.ReadLine(), out value) );
        if ( value < 100 )
            Console.WriteLine("Not enought digits");
        const byte digitToSearch = 7;
        const byte numDigit = 3;
        for ( int i = 1; i < numDigit; i++ )
        {
            value /= 10;
        }
        if ( value % 10 == digitToSearch )
            Console.WriteLine(true);
        else
            Console.WriteLine(false);
    }
}

