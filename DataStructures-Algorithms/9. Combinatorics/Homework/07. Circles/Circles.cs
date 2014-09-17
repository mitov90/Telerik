using System;
using System.Collections.Generic;

internal class Circles
{
    private static HashSet<string> allCircles;

    private static List<string> uniqueCircles;

    private static void Main()
    {
        string ballsStr = Console.ReadLine();
        char[] balls = ballsStr.ToCharArray();
        long circlesCount = CalculateCirclesCountSlowPerm(balls);
        Console.WriteLine(circlesCount);
    }

    #region Slow Solution - Permutations
    private static long CalculateCirclesCountSlowPerm(char[] balls)
    {
        if (balls.Length == 1)
        {
            return 1L;
        }

        allCircles = new HashSet<string>();
        uniqueCircles = new List<string>();
        GenerateAllPermutations(balls, 1);

        // Print the unique circles
        // foreach (var circle in uniqueCircles)
        // {
        // Console.WriteLine(circle);
        // }
        return uniqueCircles.Count;
    }

    private static void GenerateAllPermutations(char[] balls, int start)
    {
        if (start == balls.Length - 1)
        {
            AddCircle(balls);
            return;
        }

        GenerateAllPermutations(balls, start + 1);
        for (int i = start + 1; i < balls.Length; i++)
        {
            if (balls[start] != balls[i])
            {
                Swap(ref balls[start], ref balls[i]);
                GenerateAllPermutations(balls, start + 1);
                Swap(ref balls[start], ref balls[i]);
            }
        }
    }

    private static void AddCircle(char[] balls)
    {
        string circle = new string(balls);
        if (allCircles.Contains(circle))
        {
            return;
        }

        // The circle is unique --> remember all its variations
        char[] ballsVariation = (char[])balls.Clone();
        for (int rotateCount = 0; rotateCount < balls.Length; rotateCount++)
        {
            allCircles.Add(new string(ballsVariation));
            RotateChars(ballsVariation);
        }

        ReverseChars(ballsVariation);
        for (int rotateCount = 0; rotateCount < balls.Length; rotateCount++)
        {
            allCircles.Add(new string(ballsVariation));
            RotateChars(ballsVariation);
        }

        uniqueCircles.Add(circle);
    }

    private static void RotateChars(IList<char> sequence)
    {
        char first = sequence[0];
        for (int i = 1; i < sequence.Count; i++)
        {
            sequence[i - 1] = sequence[i];
        }

        sequence[sequence.Count - 1] = first;
    }

    private static void ReverseChars(char[] sequence)
    {
        for (int i = 0; i < sequence.Length / 2; i++)
        {
            Swap(ref sequence[sequence.Length - i - 1], ref sequence[i]);
        }
    }

    private static void Swap<T>(ref T first, ref T second)
    {
        T old = first;
        first = second;
        second = old;
    }

    #endregion Slow
}