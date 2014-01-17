using System;

class RectangleArea
{
    static void Main()
    {
        double widght;
        double hight;
        do
        {
            Console.WriteLine("Enter hight:");
        }
        while ( !double.TryParse(Console.ReadLine(), out hight) || hight <= 0);
        do
        {
            Console.WriteLine("Enter widght:");
        } while ( !double.TryParse(Console.ReadLine(), out widght) || widght <= 0);

        Console.WriteLine("Area is {0}", hight*widght);
    }
}

