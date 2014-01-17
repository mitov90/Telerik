using System;
using System.Collections.Generic;

class FloatPointDescOrder
{
    static void Main()
    {
        double first;
        double second;
        double third;

        ValuesInput(out first, out second, out third);
        List<double> values = new List<double>();

        if (first>second)
        {
            if (first>third)
            {
                values.Add(first);
                if ( second > third )
                {
                    values.Add(second);
                    values.Add(third);
                }
                else
                {
                    values.Add(third);
                    values.Add(second);
                }
            }
            else
            {
                values.Add(third);
                values.Add(first);
                values.Add(second);
            }
        }
        else
        {
            if (second > third)
            {
                values.Add(second);
                if (first>third)
                {
                    values.Add(first);
                    values.Add(third);
                }
                else
                {
                    values.Add(third);
                    values.Add(first);
                }
            }
            else
            {
                if (third>first)
                {
                    values.Add(third);
                    values.Add(second);
                    values.Add(first);
                }
                else
                {
                    values.Add(third);
                    values.Add(first);
                    values.Add(second);
                }
            }
        }

        PrintNumbers(values);

    }

    private static void PrintNumbers(List<double> values)
    {
        Console.WriteLine("Values in desc order");
        foreach ( var value in values )
        {
            Console.WriteLine(value);
        }
    }

     private static void ValuesInput(out double first, out double second, out double third)
    {
        do
        {
            Console.Write("Enter first num: ");
        }
        while ( !double.TryParse(Console.ReadLine(), out first) );
        do
        {
            Console.Write("Enter second num: ");
        }
        while ( !double.TryParse(Console.ReadLine(), out second) );
        do
        {
            Console.Write("Enter third num: ");
        }
        while ( !double.TryParse(Console.ReadLine(), out third) );
    }
}
