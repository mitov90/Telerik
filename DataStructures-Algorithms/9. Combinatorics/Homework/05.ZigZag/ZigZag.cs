using System;

internal class ZigZag
{
    private static bool[] used;

    private static int count;

    private static int n;

    private static int k;

    private static int[] arr;

    private static void Main()
    {
        string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        n = int.Parse(input[0]);
        k = int.Parse(input[1]);
        used = new bool[n];
        arr = new int[k];

        PutBigger(0, -1);
        Console.WriteLine(count);
    }

    private static void PutBigger(int position, int curNum)
    {
        if (position >= k)
        {
            count++;
            return;
        }

        for (int nextNumber = curNum + 1; nextNumber < n; nextNumber++)
        {
            if (used[nextNumber])
            {
                continue;
            }

            used[nextNumber] = true;
            arr[position] = nextNumber;
            PutSmaller(position + 1, nextNumber);
            used[nextNumber] = false;
        }
    }

    private static void PutSmaller(int position, int curNum)
    {
        if (position >= k)
        {
            count++;
            return;
        }

        for (int nextNumber = curNum - 1; nextNumber >= 0; nextNumber--)
        {
            if (used[nextNumber])
            {
                continue;
            }

            used[nextNumber] = true;
            arr[position] = nextNumber;
            PutBigger(position + 1, nextNumber);
            used[nextNumber] = false;
        }
    }
}