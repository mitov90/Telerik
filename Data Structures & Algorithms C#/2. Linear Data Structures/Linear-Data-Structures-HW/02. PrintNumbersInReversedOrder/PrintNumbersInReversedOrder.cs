using System;
using System.Collections.Generic;

internal class PrintNumbersInReversedOrder
{
    private static void Main()
    {
        int numbersCount;
        string countAsString;

        do
        {
            Console.WriteLine("Enter the number of integers which will be printed in reversed order:");
            countAsString = Console.ReadLine();
        }
        while (!int.TryParse(countAsString, out numbersCount) || numbersCount <= 0);

        var stack = new Stack<int>();

        for (var i = 0; i < numbersCount; i++)
        {
            int number;
            string numberAsString;
            do
            {
                Console.Write("Enter number {0}: ", i + 1);
                numberAsString = Console.ReadLine();
            }
            while (!int.TryParse(numberAsString, out number));

            stack.Push(number);
        }

        Console.WriteLine("Your numbers in reversed order:");

        while (stack.Count != 0)
        {
            Console.WriteLine(stack.Pop());
        }
    }
}