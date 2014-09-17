using System;

class BinaryToDecimal
{
    static void Main()
    {
        int tempNumber;
        int result;
        
        tempNumber = InputNumber();

        result = 0;
        int length = tempNumber.ToString().Length;
        for ( int i = 0; i < length; i++ )
        {
            result += tempNumber % 10 * (int)Math.Pow(2, i);
            tempNumber /= 10;
        }

        Console.WriteLine("Number in decimal: " + result);
    }

    private static int InputNumber()
    {
        int tempNumber;
        string input;
        do
        {
            Console.Write("Enter number: ");
            input = Console.ReadLine();
        }
        while ( !int.TryParse(input, out tempNumber) );
        return tempNumber;
    }
}