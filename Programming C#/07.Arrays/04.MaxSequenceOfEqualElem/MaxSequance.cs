using System;

class MaxSequance
{
    static void Main()
    {
        uint size;
        int numEquals = 0;
        int index = 0;
        int[] myArray;
        
        InputValues(out size, out myArray);
        CountSequance(myArray, ref numEquals,ref index);
        Console.WriteLine("Sequence of equal element ({0}) -> {1}", myArray[index],numEquals);

    }

    private static void InputValues(out uint size, out int[] myArray)
    {
        do
        {
            Console.Write("Enter size of array: ");
        } while ( !uint.TryParse(Console.ReadLine(), out size) );

        myArray = new int[size];

        for ( int i = 0; i < myArray.Length; i++ )
        {
            do
            {
                Console.WriteLine("Enter {0} element: ", i);
            }
            while ( !int.TryParse(Console.ReadLine(), out myArray[i]) );
        }
    }

    private static void CountSequance(int[] myArray, ref int numEquals,ref int index)
    {
        int tempCount = 1;

        for ( int i = 0; i < myArray.Length; i++ )
        {
            if ( tempCount > numEquals )
            {
                numEquals = tempCount;
                index = i;
            }
            if ( i + 1 < myArray.Length && myArray[i] == myArray[i + 1] )
                tempCount++;
            else
                tempCount = 1;
        }
    }
}
