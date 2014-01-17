using System;

class LastDigitAsString
{
    static void Main()
    {
        string[] ones = {
                     "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
                 };
        int tempValue;
        const int Ten = 10;
        do
        {
            tempValue = InputInteger();
            string result = GetLastDigit(ones, tempValue, Ten);
            Console.WriteLine("Last digit is " + result);
        }
        while ( tempValue != 0 );
    }

    private static string GetLastDigit(string[] ones, int tempValue, int ten)
    {
        return ones[tempValue % ten];
    }

    private static int InputInteger()
    {
        int tempValue;
        do
        {
            Console.Write("Enter number or zero to stop: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out tempValue) );
        return tempValue;
    }
}