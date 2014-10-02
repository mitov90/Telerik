using System;
using System.Linq;
using System.Text;

class DecimalToHex
{
    static readonly char[] hexNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' }; 
    static void Main()
    {
        int tempNumber;
        StringBuilder tempResult = new StringBuilder();
        
        tempNumber = InputNumber();
        tempResult.Clear();

        do
        {
            int digit = tempNumber % 16;
            tempNumber /= 16;
            tempResult.Append(hexNumbers[digit]);
        }
        while ( tempNumber != 0 );

        var result =  tempResult.ToString().ToCharArray();
        Array.Reverse(result);
        Console.WriteLine("Number in Binary: " + new string (result));
    }

    private static int InputNumber()
    {
        int tempNumber;
        do
        {
            Console.Write("Enter number / 0 to exit: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out tempNumber) );
        return tempNumber;
    }
}