using System;

class PrintAgePlus10
{
    static void Main()
    {
        Console.WriteLine("Enter your age: ");
        int age = 0;
        if (int.TryParse(Console.ReadLine(), out age))
            Console.WriteLine("Your age after ten years: " + (age+10));
        else
            Console.WriteLine("Enter your age as number");
    }
}
