using System;
using System.Collections.Generic;

internal class SortNumbers
{
    private static void Main()
    {
        var numbers = new List<int>();

        Console.WriteLine("Enter a sequence of integers, empty line to finish input:");

        do
        {
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                break;
            }

            int number;
            if (int.TryParse(input, out number))
            {
                numbers.Add(number);
            }
        }
        while (true);

        numbers.Sort((p, q) => p.CompareTo(q));

        Console.WriteLine("The list sorted in ascending order: {0}.", string.Join(", ", numbers));
    }
}