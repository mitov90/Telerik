using System;
using System.Collections.Generic;

internal static class ShortestSequenceOfOperations
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
                return number + 2;
            case Functions.Third:
                return number * 2;
            default:
                throw new ArgumentException("Wrong enum type");
        }
    }

    private static Stack<int> GetSequence(int initialTerm, int finalTerm)
    {
        var queue = new Queue<int>();
        queue.Enqueue(initialTerm);
        var transition = new Dictionary<int, int>();

        while (true)
        {
            var curTerm = queue.Dequeue();

            var firstTerm = Functions.First.GetNextTerm(curTerm);
            var secondTerm = Functions.Second.GetNextTerm(curTerm);
            var thirdTerm = Functions.Third.GetNextTerm(curTerm);

            if (!transition.ContainsKey(firstTerm))
            {
                transition.Add(firstTerm, curTerm);
                queue.Enqueue(firstTerm);
            }

            if (!transition.ContainsKey(secondTerm))
            {
                transition.Add(secondTerm, curTerm);
                queue.Enqueue(secondTerm);
            }

            if (!transition.ContainsKey(thirdTerm))
            {
                transition.Add(thirdTerm, curTerm);
                queue.Enqueue(thirdTerm);
            }

            if (firstTerm == finalTerm ||
                secondTerm == finalTerm ||
                thirdTerm == finalTerm)
            {
                return GetResult(finalTerm, transition);
            }
        }
    }

    private static Stack<int> GetResult(int finalTerm, IReadOnlyDictionary<int, int> transition)
    {
        var result = new Stack<int>();
        result.Push(finalTerm);
        var term = finalTerm;
        while (transition.ContainsKey(term))
        {
            result.Push(transition[term]);
            term = transition[term];
        }

        return result;
    }

    private static void Main()
    {
        const int InitialTerm = 5;
        const int FinalTerm = 16;

        Console.Write(
            "You are given the following operations:\n" + "N = N + 1;\n" + "N = N + 2;\n" + "N = N * 2;\n"
            + "These are the numbers between {0} and {1} obtained using\n" + "a minimum number of operations: ", 
            InitialTerm, 
            FinalTerm);

        var sequence = GetSequence(InitialTerm, FinalTerm);

        while (sequence.Count > 0)
        {
            Console.Write("{0} ", sequence.Pop());
        }

        Console.WriteLine();
    }
}