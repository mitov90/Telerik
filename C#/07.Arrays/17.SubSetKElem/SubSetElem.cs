using System;
using System.Collections.Generic;

class SubSetElem
{
    static void Main()
    {
        List<int[]> myArr = new List<int[]>();
        int[] arr;
        int sum;
        int k;
        Input(out arr, out sum, out k);
        myArr = CreateSubsetsOfKElements(arr, k);
        PrintResult(sum, k, myArr);
    }

    private static void Input(out int[] arr, out int sum, out int k)
    {
        int numArray;
        do
        {
            Console.Write("Enter number of array's elem: ");

        } while ( !int.TryParse(Console.ReadLine(), out numArray) );
        arr = new int[numArray];
        for ( int i = 0; i < numArray; i++ )
        {
            do
            {
                Console.Write("Enter {0} elem: ", i);
            } while ( !int.TryParse(Console.ReadLine(), out arr[i]) );
        }


        do
        {
            Console.Write("Enter searching sum: ");

        } while ( !int.TryParse(Console.ReadLine(), out sum) );
        do
        {
            Console.Write("Enter number of elem in subset: ");

        } while ( !int.TryParse(Console.ReadLine(), out k) );
    }

    private static void PrintResult(int sum, int k, List<int[]> myArr)
    {
        for ( int i = 0; i < myArr.Count; i++ )
        {
            if ( myArr[i].Length != k )
                continue;
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
    }

    static List<T[]> CreateSubsetsOfKElements<T>(T[] originalArray, int k)
    {
        List<T[]> subsets = new List<T[]>();
        for ( int i = 0; i < originalArray.Length; i++ )
        {
            int subsetCount = subsets.Count;
            subsets.Add(new T[] { originalArray[i] });
            for ( int j = 0; j < subsetCount; j++ )
            {
                if ( subsets[j].Length >= k )
                    continue;
                T[] newSubset = new T[subsets[j].Length + 1];
                subsets[j].CopyTo(newSubset, 0);
                newSubset[newSubset.Length - 1] = originalArray[i];
                subsets.Add(newSubset);
            }
        }
        return subsets;
    }

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

}
