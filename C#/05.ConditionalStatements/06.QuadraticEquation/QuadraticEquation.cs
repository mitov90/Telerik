using System;

class QuadraticEquation
{
    static void Main()
    {
        double a;
        double b;
        double c;
        double d;
        const byte precision = 10;
        InputValues(out a, out b, out c);

        d = b * b - 4 * a * c;

        if (Math.Round(d,precision) < 0.0)
        {
            double sqrtOfD = Math.Sqrt(-d);
            double rez1 = -b / ( 2 * a );
            double imz1 = sqrtOfD / ( 2 * a );
            double imz2 = -imz1;

            Console.WriteLine("The quadratic equation has two complex roots: ({0:F2}, {1:F2}) and ({2:F2}, {3:F2}).", rez1, imz1, rez1, imz2);
      
        }
        else
        {
            double sqrtOfD = Math.Sqrt(d);
            double x1 = ( -b + sqrtOfD ) / ( 2 * a );
            double x2 = ( -b - sqrtOfD ) / ( 2 * a );

            Console.WriteLine("The quadratic equation has two distinct real roots: {0:F2} and {1:F2}.", x1, x2);
        }
            
    }

    private static void InputValues(out double a, out double b, out double c)
    {
        do
        {
            Console.Write("Enter the quadratic coefficient (a): ");
        }
        while ( !Double.TryParse(Console.ReadLine(), out a) );

        do
        {
            Console.Write("Enter the linear coefficient (b): ");
        }
        while ( !Double.TryParse(Console.ReadLine(), out b) );

        do
        {
            Console.Write("Enter the free term (c): ");
        }
        while ( !Double.TryParse(Console.ReadLine(), out c) );
    }
}
