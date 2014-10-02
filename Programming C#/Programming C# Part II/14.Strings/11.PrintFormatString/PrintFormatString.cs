using System;

class PrintFormatString
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("Decimal: {0,15:D}", number);
        Console.WriteLine("Hex: {0,15:x}", number);
        Console.WriteLine("Percent: {0,15:P}", number);
        Console.WriteLine("Scientific: {0,15:E}", number);

    }
}
