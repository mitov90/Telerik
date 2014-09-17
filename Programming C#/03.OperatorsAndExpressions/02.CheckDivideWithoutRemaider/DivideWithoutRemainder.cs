using System;

class DivideWithoutRemainder
{
    static void Main()
    {
        int value;
        Console.WriteLine("Enter number to check 0/char to exit: ");
        while ( int.TryParse(Console.ReadLine(), out value) )
        {
            if ( value != 0 )
            {
                Console.WriteLine("Number {0} is devided with{1} remaider by 5 and 7", value, (value % 5 == 0 && value % 7 == 0) ? "out" : string.Empty);
            }
        }
    }
}