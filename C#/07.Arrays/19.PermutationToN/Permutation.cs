using System;
using System.Collections.Generic;

class Permutation
{

    static void Main()
    {
        int[] arr;
        List<int[]> myList;

        Input(out arr, out myList);
        Permutate(ref arr, arr.Length, myList);
        PrintResult(myList);
    }

    private static void PrintResult(List<int[]> myList)
    {
        for ( int i = 0; i < myList.Count; i++ )
        {
            Console.Write("{ ");
            for ( int j = 0; j < myList[i].Length; j++ )
            {
                Console.Write(myList[i][j] + " ");
            }
            Console.WriteLine("}");
        }
    }

    private static void Input(out int[] arr, out List<int[]> myList)
    {
        int num;
        do
        {
            Console.Write("Enter number to permutate: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out num) );

        arr = new int[num];
        myList = new List<int[]>();

        for ( int i = 0; i < num; i++ )
        {
            arr[i] = i + 1;
        }
    }

    static void Permutate(ref int[] arr, int length, List<int[]> myList)
    {
        if ( length == 1 )
        {
            myList.Add((int[])arr.Clone());
        }
        else
        {
            for ( int i = 0; i < length; i++ )
            {
                Permutate(ref arr, length - 1, myList);
                if ( length % 2 == 1 )
                {
                    SwapDiffrentInt(ref arr[0], ref arr[length - 1]);
                }
                else
                {
                    SwapDiffrentInt(ref arr[i], ref arr[length - 1]);
                }
            }

        }

    }

    //DOES NOT WORK WITH EQUAL NUMBERS, but it's fast
    static void SwapDiffrentInt(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}
