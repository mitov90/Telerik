using System;

internal class SumNaive
{
    private static int[] helperArray;

    private static int[] array;

    private static int chooseFrom;

    private static int sum;

    private static void Start()
    {
        int numSeries = int.Parse(Console.ReadLine());

        for (int curSeries = 0; curSeries < numSeries; curSeries++)
        {
            string[] inputParameters = Console.ReadLine().Split(' ');
            string[] numbers = Console.ReadLine().Split(' ');

            int numberCount = int.Parse(inputParameters[0]);
            chooseFrom = numberCount - int.Parse(inputParameters[1]);
            helperArray = new int[chooseFrom];
            array = new int[numberCount];

            for (int curNumber = 0; curNumber < numberCount; curNumber++)
            {
                array[curNumber] = int.Parse(numbers[curNumber]);
            }

            sum = 0;
            Comb(0, 0);
            Console.WriteLine(sum);
        }
    }

    private static void Comb(int index, int start)
    {
        if (index == chooseFrom)
        {
            PrintCombinations();
        }
        else
        {
            for (int i = start; i < array.Length; i++)
            {
                helperArray[index] = i;
                Comb(index + 1, i + 1);
            }
        }
    }

    private static void PrintCombinations()
    {
        for (int i = 0; i < chooseFrom; i++)
        {
            sum += array[helperArray[i]];
        }
    }
}