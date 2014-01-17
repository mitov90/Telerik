using System;
using System.Globalization;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {

        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        double N = double.Parse(Console.ReadLine());
        double M = double.Parse(Console.ReadLine());
        double P = double.Parse(Console.ReadLine());

        double result =
           (  N * N  +  1 / ( M * P )  + 1337 ) /
           ( N - 128.523123123 * P ) +
           Math.Sin((int)(M % 180));

        Console.WriteLine("{0:0.000000}", result);
    }
}
