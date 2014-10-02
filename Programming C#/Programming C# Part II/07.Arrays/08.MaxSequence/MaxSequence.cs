using System;

class MaxSequence
{
    static void Main(string[] args)
    {
        int[] myArray =InputValues();
        int maxSum;
        byte startIndex;
        byte endIndex;
        CalcMaxSum(myArray, out maxSum, out startIndex, out endIndex);
        PrintResult(myArray, maxSum, startIndex, endIndex);

    }

    private static void CalcMaxSum(int[] myArray, out int maxSum, out byte startIndex, out byte endIndex)
    {
        int tempSum = myArray[0];
        maxSum = myArray[0];
        startIndex = 0;
        endIndex = 0;
        for ( int i = 1; i < myArray.Length; i++ )
        {
            if ( tempSum < 0 )
            {
                startIndex = (byte)i;
                tempSum = myArray[i];
            }
            else
                tempSum += myArray[i];
            if ( maxSum < tempSum )
            {
                maxSum = tempSum;
                endIndex = (byte)i;
            }
        }
    }

    private static void PrintResult(int[] myArray, int maxSum, byte startIndex, byte endIndex)
    {
        Console.WriteLine("Max contiguous sum: " + maxSum);
        Console.Write("{ ");
        for ( int i = startIndex; i <= endIndex; i++ )
        {
            Console.Write(myArray[i] + " ");
        }
        Console.WriteLine("}");
    }

    private static int[] InputValues()
    {
        byte arrSize;
        do
        {
            Console.Write("Enter array size: ");
        }
        while ( !byte.TryParse(Console.ReadLine(), out arrSize) );
        int[] myArray = new int[arrSize];
        for ( int i = 0; i < myArray.Length; i++ )
        {
            do
            {
                Console.Write("Enter {0} element:", i + 1);
            }
            while ( !int.TryParse(Console.ReadLine(), out myArray[i]) );
        }
        return myArray;
    }
}
