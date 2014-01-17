using System;

class MaxSumOfKElem
{
    static void Main()
    {
        byte arrSize;
        byte subsetLenght;
        int[] myArray;
        InputValues(out arrSize, out subsetLenght, out myArray);

        int maxSum = MaxSumElem(subsetLenght, myArray);
        Console.WriteLine("Max sum " + maxSum);
    }

    private static int MaxSumElem(byte subsetLenght, int[] myArray)
    {
        int tempSum = 0;
        int maxSum = 0;
        for ( int j = 0; j < subsetLenght; j++ )
        {
            maxSum = tempSum += myArray[j];
        }

        for ( int i = subsetLenght; i < myArray.Length; i++ )
        {
            tempSum = tempSum - myArray[i - subsetLenght] + myArray[i];

            if ( tempSum > maxSum )
                maxSum = tempSum;
        }
        return maxSum;
    }

    private static void InputValues(out byte arrSize, out byte subsetLenght, out int[] myArray)
    {
        do
        {
            Console.Write("Enter array size: ");
        }
        while ( !byte.TryParse(Console.ReadLine(), out arrSize) );
        myArray = new int[arrSize];
        for ( int i = 0; i < myArray.Length; i++ )
        {
            do
            {
                Console.Write("Enter {0} element:", i+1);
            }
            while ( !int.TryParse(Console.ReadLine(), out myArray[i]) );
        }
        do
        {
            Console.Write("Enter subset lenght: ");
        }
        while ( !byte.TryParse(Console.ReadLine(), out subsetLenght) || subsetLenght > arrSize );
    }
}
