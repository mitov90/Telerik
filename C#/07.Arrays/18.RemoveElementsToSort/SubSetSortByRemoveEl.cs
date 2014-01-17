using System;
using System.Collections.Generic;

class SubSetSortByRemoveEl
{
    static void Main()
    {
        
        int[] arr = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };

        List<int[]> myArr = new List<int[]>();
        CreateAscSubsets(arr, myArr);
        int max = FindMaxLenght(myArr);
        PrintResult(myArr, max);
        
    }

    private static void PrintResult(List<int[]> myArr, int max)
    {
        Console.WriteLine("Max lenght of sorted array: {0}", max);
        for ( int i = 0; i < myArr.Count; i++ )
        {
            if ( myArr[i].Length != max )
                continue;
            Console.Write("{ ");
            for ( int j = 0; j < myArr[i].Length; j++ )
            {
                Console.Write(myArr[i][j] + " ");
            }
            Console.WriteLine("}");
        }
    }

    private static int FindMaxLenght(List<int[]> myArr)
    {
        int max = 0;
        for ( int i = 0; i < myArr.Count; i++ )
        {
            if ( myArr[i].Length > max )
            {
                max = myArr[i].Length;
            }
        }
        return max;
    }

    private static void CreateAscSubsets(int[] arr, List<int[]> myArr)
    {
        for ( int i = 0; i < arr.Length; i++ )
        {
            int subsetCount = myArr.Count;

            for ( int j = 0; j < subsetCount; j++ )
            {
                if ( myArr[j][myArr[j].Length - 1] <= arr[i] )
                {
                    int[] temp = new int[myArr[j].Length + 1];
                    myArr[j].CopyTo(temp, 0);
                    temp[temp.Length - 1] = arr[i];
                    myArr.Add(temp);
                }
            }
            myArr.Add(new int[] { arr[i] });
        }
    }
}
