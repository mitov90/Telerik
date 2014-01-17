using System;
using System.Collections.Generic;

class SubSetSum
{
    static void Main()
    {
        int[] arr = { 2, 1, 2, 4, 3, 5, 2, 6 };
        int sum = 14;
        //too lazy to make proper input from console
        List<int[]> myArr = new List<int[]>();

        //create subsets
        for ( int i = 0; i < arr.Length; i++ )
        {
            int subSetCount = myArr.Count;
            for ( int j = 0; j < subSetCount; j++ )
            {
                int[] temp = new int[myArr[j].Length + 1];
                myArr[j].CopyTo(temp, 0);
                temp[temp.Length - 1] = arr[i];
                myArr.Add(temp);
            }
            myArr.Add(new int[] { arr[i] });
           
        }
        //print result
        for ( int i = 0; i < myArr.Count; i++ )
        {
            if ( SumArray(myArr[i], sum) )
            {
                Console.Write("Yes { ");
                for ( int z = 0; z < myArr[i].Length; z++ )
                {
                    Console.Write(myArr[i][z] + " ");
                }
                Console.WriteLine("}");
            }
        }
       
        //print all subsets
        //for ( int i = 0; i < myArr.Count; i++ )
        //{
        //    for ( int j = 0; j < myArr[i].Length; j++ )
        //    {
        //        Console.Write(myArr[i][j] + " ");
        //    }
        //    Console.WriteLine();
        //}
    }

    //take int[] and sum all members
    static bool SumArray(int[] arr, int sum)
    {
        for ( int i = 0; i < arr.Length; i++ )
        {
            sum -= arr[i];
            if ( sum < 0 )
                return false;
        }
        if ( sum == 0 )
            return true;
        else
            return false;
    }

    static List<T[]> CreateSubsets<T>(T[] originalArray)
    {
        List<T[]> subsets = new List<T[]>();
        for ( int i = 0; i < originalArray.Length; i++ )
        {
            int subsetCount = subsets.Count;
            subsets.Add(new T[] { originalArray[i] });
            for ( int j = 0; j < subsetCount; j++ )
            {
                T[] newSubset = new T[subsets[j].Length + 1];
                subsets[j].CopyTo(newSubset, 0);
                newSubset[newSubset.Length - 1] = originalArray[i];
                subsets.Add(newSubset);
            }
        }
        return subsets;
    }
}
