using System;
using System.Collections.Generic;

internal static class RecurrentSequence
{
    internal enum Functions
    {
        First,

        Second,

        Third
    }

    public static int GetNextTerm(this Functions functions, int number)
    {
        switch (functions)
        {
            case Functions.First:
                return number + 1;
            case Functions.Second:
                return (number * 2) + 1;
            case Functions.Third:
                return number + 2;
            default:
                throw new ArgumentException("Wrong enum type");
        }
    }

    private static IEnumerable<int> GetSequence(int initialTerm, int count)
    {
        var queue = new Queue<int>();
        queue.Enqueue(initialTerm);

        var index = 0;
        var result = new int[count + 1];

        while (true)
        {
            var curTerm = queue.Dequeue();
            result[index] = curTerm;

            if (index == count)
            {
                return result;
            }

            var firstTerm = Functions.First.GetNextTerm(curTerm);
            var secondTerm = Functions.Second.GetNextTerm(curTerm);
            var thirdTerm = Functions.Third.GetNextTerm(curTerm);

            queue.Enqueue(firstTerm);
            queue.Enqueue(secondTerm);
            queue.Enqueue(thirdTerm);

            index++;
        }
    }

    private static void Main()
    {
        const int InitialTerm = 2;
        const int ItemsCount = 50;
        var textPrint = string.Format(
            @"You are given the following recurrent sequence:
            S1 = N;
            S2 = S1 + 1;
            S3 = 2 * S1 + 1;
            S4 = S1 + 2;
            S5 = S2 + 1;
            S6 = 2 * S2 + 1;
            S7 = S2 + 2;
            ... 
            These are the first {0} elements if N = {1}:",
                                                         ItemsCount,
                                                         InitialTerm);

        Console.WriteLine(textPrint);
        var sequence = GetSequence(InitialTerm, ItemsCount);
        Console.WriteLine(string.Join(", ", sequence));
    }
}