using System;

class TtrapezoidArea
{
    static void InputTrapezoid(out double a, out double b, out double h)
    {
        do
        {
            Console.WriteLine("Enter value for side a:");
        }
        while (! double.TryParse(Console.ReadLine(), out a) || a <= 0 );
        
        do
        {
            Console.WriteLine("Enter value for side b:");
        }
        while (! double.TryParse(Console.ReadLine(), out b) || b <= 0  );
        
        do
        {
            Console.WriteLine("Enter value for hight:");
        }
        while (! double.TryParse(Console.ReadLine(), out h) || h <= 0 );

    }
    static void Main()
    {
        double a,b,h;
        InputTrapezoid(out a,out b,out h);

        Console.WriteLine("Trapezoid's area is: {0} messure units", ((a+b)/2)*h);
    }
}
