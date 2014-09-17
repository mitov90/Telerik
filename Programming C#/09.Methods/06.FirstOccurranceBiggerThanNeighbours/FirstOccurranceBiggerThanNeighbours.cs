using System;

class FirstOccurranceBiggerThanNeighbours
{
    static void Main()
    {
        int[] arr = { 1, 3, 3, 4, 5, 6, 3, 2, 6, 5, 8, 4, 2, 4, 7, 43, 2, 5, 7, 3, 2, 1 };
        int index = FindBiggerThanNeighbours(arr);
        Console.WriteLine(index!=-1?"Position: " + index:"No such number!");
    }

    private static int FindBiggerThanNeighbours(int[] arr)
    {
        if ( arr.Length > 3 )
            for ( int i = 1; i < arr.Length - 1; i++ )
            {
                if ( arr[i] > arr[i - 1] && arr[i] > arr[i + 1] )
                {
                    return i;
                }
            }
        return -1;
    }
}