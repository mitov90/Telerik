using System;
using System.Collections.Generic;

internal class RemoveNegativeNumbers
{
    private static void Main()
    {
        var numbers = new List<int>(new[] { 19, -10, 12, -6, -3, 34, -2, 5 });

        numbers.RemoveAll(p => p < 0);

        Console.WriteLine("The list with the negative elements removed: {0}.", string.Join(", ", numbers));
    }
}