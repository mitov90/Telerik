using System;

class OddOrEven
{
    static void Main()
    {
        int value;
        Console.WriteLine("Enter number to check or 0/char to exit: ");
        while(int.TryParse(Console.ReadLine(), out value))
        {
            if (value != 0)
            {
                Console.WriteLine("Number {0} is {1}",value, value%2==0?"even":"odd");
            }
        }
    }
}