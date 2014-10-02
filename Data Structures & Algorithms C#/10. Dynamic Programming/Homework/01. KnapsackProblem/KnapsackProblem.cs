using System;
using System.Collections.Generic;

internal class KnapsackProblem
{
    /// <summary>
    ///     Uses the algorithm described at
    ///     http://www.8bitavenue.com/2011/12/dynamic-programming-integer-knapsack/
    /// </summary>
    /// <param name="v"></param>
    /// <param name="s"></param>
    /// <param name="c"></param>
    private static void SolveKnapsackProblemDuplicatesAllowed(IList<int> v, IList<int> s, int c)
    {
        // Assume the array V[i] 
        // contains the values of the items
        // Assume the array S[i] 
        // contains the sizes of the items
        int n = v.Count;
        int[] m = new int[c + 1];
        int[] b = new int[c + 1];

        // Trivial case when (j=0) 
        // the value we get is also zero
        m[0] = 0;

        // For each slot (j) in the knapsack do
        for (int j = 1; j <= c; j++)
        {
            // M[j] will be max1 (or M[j-1]) 
            // if the jth slot is empty
            int max1 = m[j - 1];

            // M[j] will be max2 if the jth 
            // slot is occupied by some item
            // Initialize max2 to some small number
            int max2 = -999999;

            // This is used to mark the previous (j) 
            // slot if the jth slot is occupied
            int mark = 0;

            // Search for an item to occupy the jth 
            // slot such that it gives us maximum value
            for (int i = 0; i < n; i++)
            {
                // For each item (i) calculate (V[i] + M[j - S[i]]) 
                // then compare it to the current max. If it is greater 
                // then update the current max. Only those items satisfying 
                // the condition (j - S[i] >= 0) are checked because capacity 
                // should not be negative
                if (j - s[i] >= 0 && v[i] + m[j - s[i]] > max2)
                {
                    // Update the max
                    max2 = v[i] + m[j - s[i]];

                    // Save the previous (j) position 
                    // that gives us the maximum value
                    mark = j - s[i];
                }
            }

            // Case1: jth slot is empty
            if (max1 > max2)
            {
                m[j] = max1;
                b[j] = j - 1;
            }
            else
            {
                // Case 2: jth slot is occupied
                m[j] = max2;
                b[j] = mark;
            }
        }

        Console.WriteLine(
            "The maximum value we can get by filling\r\n" + "the knapsack with capacity {0} is {1}.", 
            c, 
            m[c]);
    }

    /// <summary>
    ///     Uses the algorithm described at
    ///     http://www.8bitavenue.com/2011/12/dynamic-programming-integer-knapsack/
    ///     However it is slightly changed since we are solving the "01 Knapsack Problem",
    ///     where duplicate items are not allowed.
    /// </summary>
    /// <param name="v"></param>
    /// <param name="s"></param>
    /// <param name="c"></param>
    private static void SolveKnapsackProblemNoDuplicatesAllowed(IList<int> v, IList<int> s, int c)
    {
        // Assume the array V[i] 
        // contains the values of the items
        // Assume the array S[i] 
        // contains the sizes of the items
        int n = v.Count;
        bool[,] used = new bool[c + 1, n];
        int[] m = new int[c + 1];

        // Trivial case when (j=0) 
        // the value we get is also zero
        m[0] = 0;

        // For each slot (j) in the knapsack do
        for (int j = 1; j <= c; j++)
        {
            // M[j] will be max1 (or M[j-1]) 
            // if the jth slot is empty
            int max1 = m[j - 1];

            // M[j] will be max2 if the jth 
            // slot is occupied by some item
            // Initialize max2 to some small number
            int max2 = -999999;

            // This is used to mark the previous (j) 
            // slot if the jth slot is occupied
            int mark = 0;

            // This is used to keep the index
            // of the last candidate which can be put
            // in the knapsack
            int candidateUsed = 0;

            // Search for an item to occupy the jth 
            // slot such that it gives us maximum value
            for (int i = 0; i < n; i++)
            {
                // For each item (i) calculate (V[i] + M[j - S[i]]) 
                // then compare it to the current max. If it is greater 
                // then update the current max. Only those items satisfying 
                // the condition (j - S[i] >= 0) are checked because capacity 
                // should not be negative
                if (j - s[i] >= 0 && !used[j - s[i], i] && v[i] + m[j - s[i]] > max2)
                {
                    // Update the max
                    max2 = v[i] + m[j - s[i]];

                    // Save the previous (j) position 
                    // that gives us the maximum value
                    mark = j - s[i];

                    // Update the candidate item which
                    // might be put in the knapsack
                    candidateUsed = i;
                }
            }

            // Case1: jth slot is empty
            if (max1 > max2)
            {
                m[j] = max1;

                for (int k = 0; k < n; k++)
                {
                    used[j, k] = used[j - 1, k];
                }
            }
            else
            {
                // Case 2: jth slot is occupied
                m[j] = max2;

                for (int k = 0; k < n; k++)
                {
                    used[j, k] = used[mark, k];
                }

                // mark the candidate as used, which will prevent us
                // from putting it again in the knapsack
                used[j, candidateUsed] = true;
            }
        }

        Console.WriteLine(
            "The maximum value we can get by filling\r\n" + "the knapsack with capacity {0} is {1}.", 
            c, 
            m[c]);

        for (int i = 0; i < n; i++)
        {
            if (used[c, i])
            {
                Console.WriteLine("Size: {0}, Value: {1}", s[i], v[i]);
            }
        }
    }

    private static void Main()
    {
        // int[] sizes = new int[] { 2, 3, 4 };
        // int[] values = new int[] { 3, 7, 1 };
        // int capacity = 4;

        // int[] sizes = new int[] { 30, 15, 50, 10, 20, 40, 5, 65 };
        // int[] values = new int[] { 5, 3, 9, 1, 2, 7, 1, 12 };
        // int capacity = 70;

        // int[] sizes = new int[] { 1, 2, 3, 5, 6, 7 };
        // int[] values = new int[] { 1, 10, 19, 22, 25, 30 };
        // int capacity = 15;

        // int[] sizes = new int[] { 6, 3, 10, 2, 4, 8, 1, 13, 3 };
        // int[] values = new int[] { 5, 3, 9, 1, 2, 7, 1, 12, 3 };
        // int capacity = 14;
        int[] sizes = { 3, 8, 4, 1, 2, 8 };
        int[] values = { 2, 12, 5, 4, 3, 13 };
        const int Capacity = 10;

        SolveKnapsackProblemNoDuplicatesAllowed(values, sizes, Capacity);
    }
}