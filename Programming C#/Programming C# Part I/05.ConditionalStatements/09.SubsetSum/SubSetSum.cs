using System;
using System.Collections.Generic;

class SubSetSum
{
    static void Main()
    {
        int numValues = 5;
        int sum = 0;
        int[] values = new int[numValues];
        List<int[]> subsets = new List<int[]>();

        for ( int i = 0; i < numValues; i++ )
        {
            do
            {
                Console.Write("Enter {0} value: ", i);
            }
            while ( !int.TryParse(Console.ReadLine(), out values[i]) );
        }

        CreateSubsets(values, subsets);
        foreach ( var subset in subsets )
        {
            int tempSum = SumSubset(subset);
            if (tempSum==sum)
            {
                PrintSubset(sum, subset);
            }
        }
    }

    private static int SumSubset(int[] subset)
    {
        int tempSum = 0;
        for ( int i = 0; i < subset.Length; i++ )
        {
            tempSum += subset[i];
        }
        return tempSum;
    }

    private static void PrintSubset(int sum, int[] subset)
    {
        Console.Write("Subset has sum of {0} ", sum);
        Console.Write("{");
        foreach ( var num in subset )
        {
            Console.Write(" {0}", num);
        }
        Console.WriteLine("}");
    }

    private static void CreateSubsets(int[] values, List<int[]> subsets)
    {
        for ( int i = 0; i < values.Length; i++ )
        {
            subsets.Add(new int[] { values[i] });
            int subsetCount = subsets.Count;

            for ( int j = 0; j < subsetCount; j++ )
            {
                int[] newSubset = new int[subsets[j].Length + 1];
                subsets[j].CopyTo(newSubset, 0);
                newSubset[newSubset.Length - 1] = values[i];
                subsets.Add(newSubset);
            }
        }
    }
}