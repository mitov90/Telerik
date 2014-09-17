using System;

class ContiguousSum
{
    static void Main()
    {
        int searchingSum;
        int[] myArray = InputValues(out searchingSum);
        int tempSum;

        for ( int i = 0; i < myArray.Length; i++ )
        {
            tempSum = 0;

            for ( int j = i; j < myArray.Length; j++ )
            {
                tempSum += myArray[j];
                if ( tempSum == searchingSum )
                    PrintSubset(i, j, myArray);
            }
        }
    }

    private static void PrintSubset(int start, int end, int[] myArray)
    {
        Console.Write("{ ");
        for ( int i = start; i <= end; i++ )
        {
            Console.Write(myArray[i] + " ");
        }
        Console.WriteLine("}");
    }

    private static int[] InputValues(out int searchingSum)
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
        do
        {
            Console.Write("Enter searching sum: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out searchingSum) );
        return myArray;
    }
}
