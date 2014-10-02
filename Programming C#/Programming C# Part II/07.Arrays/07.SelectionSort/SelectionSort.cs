using System;

class SelectionSort
{
    static void Main()
    {
        byte arrSize;
        int[] myArray;
        InputValues(out arrSize, out myArray);

        SortSelection(myArray);

        foreach ( var element in myArray )
        {
            Console.WriteLine(element);
        }
    }

    private static void InputValues(out byte arrSize, out int[] myArray)
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
                Console.Write("Enter {0} element:", i + 1);
            }
            while ( !int.TryParse(Console.ReadLine(), out myArray[i]) );
        }
    }

    private static void SortSelection(int[] myArray)
    {
        for ( int i = 0; i < myArray.Length; i++ )
        {
            int tempMin = i;
            for ( int j = i; j < myArray.Length; j++ )
            {
                if ( myArray[j] < myArray[tempMin] )
                {
                    SwapInt(ref myArray[j], ref myArray[i]);
                }
            }
        }
    }
    static void SwapInt(ref int a,ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}
