using System;

class SortAndSearchInteger
{
    static void Main()
    {
        int arraySize=EnterNumber("Enter array size: ");
        int[] myArray = new int[arraySize];

        for ( int i = 0; i < myArray.Length; i++ )
        {
            myArray[i] = EnterNumber(String.Format("Enter {0} number: ",i+1));
        }
        int pivot;
        pivot = EnterNumber("Enter pivot: ");

        Array.Sort(myArray);
        int index = Array.BinarySearch(myArray, pivot);
        PrintResult(myArray, index);
    }

    private static void PrintResult(int[] myArray, int index)
    {
        if ( index < 0 )
        {
            if ( index == -1 )
            {
                Console.WriteLine("All integer are greater!");
            }
            else
            {
                Console.WriteLine("Result: " + myArray[~index - 1]);
            }
        }
        else
        {
            Console.WriteLine("The ingeger is in the array!");
        }
    }

    private static int EnterNumber(string text)
    {
        int pivot;
        do
        {
            Console.Write(text);
        }
        while ( !int.TryParse(Console.ReadLine(), out pivot) );
        return pivot;
    }
}
