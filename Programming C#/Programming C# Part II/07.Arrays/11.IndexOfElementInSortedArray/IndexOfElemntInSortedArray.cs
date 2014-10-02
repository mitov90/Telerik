using System;
using System.Linq;

class IndexOfElemntInSortedArray
{
    static void Main()
    {
        int key;
        int[] myArray = InputValues(out key);
        int[] sortedArray = myArray.OrderBy(( x => x )).ToArray();
        PrintArray(sortedArray);

        int ? result = MyBinarySearch(sortedArray, key);
        Console.WriteLine("{0} {1} {2}", key , result==null?"not found":"found on index:", result);
    }

    private static void PrintArray(int[] sortedArray)
    {
        Console.WriteLine("Sorted array:" + Environment.NewLine);
        foreach ( var num in sortedArray )
        {
            Console.Write(num + " ");
        }
        Console.WriteLine(Environment.NewLine);
    }

    static int? MyBinarySearch (int[] array, int key)
    {
        int tempMax=array.Length;
        int tempMin=0;
        int tempIndex = (tempMax+tempMin)/2;
        do
        {
            if ( array[( tempIndex )] == key )
                return tempIndex;
            else
            {
                if ( array[tempIndex] > key )
                {
                    tempMax = tempIndex - 1;
                    tempIndex = ( tempMax + tempMin ) / 2;
                }
                else
                {
                    tempMin = tempIndex + 1;
                    tempIndex = ( tempMax + tempMin ) / 2;
                }
            }
        }
        while ( tempMax >= tempMin && tempIndex<array.Length);
        return null;
    }

    private static int[] InputValues(out int key)
    {
        byte arrSize;
        do
        {
            Console.Write("Enter array size: ");
        }
        while ( !byte.TryParse(Console.ReadLine(), out arrSize) || arrSize<1 );
        int[] myArray = new int[arrSize];
        for ( int i = 0; i < myArray.Length; i++ )
        {
            do
            {
                Console.Write("Enter {0} element:", i );
            }
            while ( !int.TryParse(Console.ReadLine(), out myArray[i]) );
        }
        do
        {
            Console.Write("Enter search key value: ");
        }
        while (!int.TryParse(Console.ReadLine(), out key));
        return myArray;
    }
}
