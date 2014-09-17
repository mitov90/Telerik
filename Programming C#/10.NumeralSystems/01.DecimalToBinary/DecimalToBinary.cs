using System;

class DecimalToBinary
{
    static void Main()
    {
        int tempNumber;
        do
        {
            tempNumber = InputNumber();

            string numberBinary = Convert.ToString(tempNumber, 2);
            Console.WriteLine("Number in Binary: " + numberBinary);
        }
        while ( tempNumber != 0 );
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