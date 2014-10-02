using System;

internal class CombinationsGeneratorWithReps
{
    private const int n = 5;

    private const int k = 3;
    private  static  int ka = 0;

    private static readonly string[] objects = new[] { "banana", "apple", "orange", "strawberry", "raspberry" };

    private static readonly int[] arr = new int[k];

    private static void Main()
    {
        GenerateCombinationsNoRepetitions(0, 0);
    }

    private static void GenerateCombinationsNoRepetitions(int index, int start)
    {
        if (index >= k)
        {
            PrintVariations();
        }
        else
        {
            for (int i = start; i < n; i++)
            {
                arr[index] = i;
                GenerateCombinationsNoRepetitions(index + 1, i);
            }
        }
    }

    private static void PrintVariations()
    {
        Console.Write("(" + string.Join(", ", arr) + ") --> ( ");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(objects[arr[i]] + " ");
        }

        Console.WriteLine(ka++);
        Console.WriteLine(")");
    }
}