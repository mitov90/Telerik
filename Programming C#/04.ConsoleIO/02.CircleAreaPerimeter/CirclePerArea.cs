using System;

class CirclePerArea
{
    static void Main()
    {
        double rad;
        do
        {
            Console.Write("Enter radius for circle: ");
        }
        while(!double.TryParse(Console.ReadLine(),out rad) || rad < 0);

        Circle myCirc = new Circle(0, 0, rad);
        Console.WriteLine("Perimeter: {0}",myCirc.Perimeter);
        Console.WriteLine("Area: {0}", myCirc.Area);
    }
}