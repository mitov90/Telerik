using System;
using System.Text;

class ReverseDigits
{
    static void Main()
    {
        int value;
        do
        {
            value = InputValue("Enter number or zero to stop: ");
            Console.WriteLine("Reverse: " + CountDigits(value));
        }
        while ( value!=0 );
    }

    private static string CountDigits(int value)
    {
        StringBuilder sb = new StringBuilder();

        while ( value != 0 )
        {
            int tempDigit = value % 10;
            sb.Append(tempDigit);
            value /= 10;
        }
        return sb.ToString();
    }

    private static int InputValue(string str)
    {
        int tempNumber;
        do
        {
            Console.Write(str);
        }
        while ( !int.TryParse(Console.ReadLine(), out tempNumber) );
        return tempNumber;
    }
}