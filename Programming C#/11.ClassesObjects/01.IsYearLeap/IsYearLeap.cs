using System;

class IsYearLeap
{
    static void Main()
    {
        int value = Utilities.InputInteger("Enter year (ex. 1990): ");
        bool leapYear = DateTime.IsLeapYear(value);
        Console.WriteLine("{0} is {1}leap year!",value, leapYear?"":"not ");
    }

    
}