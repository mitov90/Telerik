using System;

class Program
{
    static void Main()
    {
        uint size;

        size = InputArraySize();
        int[] firstArray = new int[size];
        int[] secondArray = new int[size];
        InputArrays(size, firstArray, secondArray);

        if ( firstArray.Length != secondArray.Length )
            throw new InvalidOperationException("Diffrent size arrays");
        for ( int i = 0; i < firstArray.Length; i++ )
        {
            Console.WriteLine("{0}{1}{2}", firstArray[i], firstArray[i]==secondArray[i]?"==":"!=",secondArray[i]);
        }
    }

    private static void InputArrays(uint size, int[] firstArray, int[] secondArray)
    {
        for ( int i = 0; i < size; i++ )
        {
            do
            {
                Console.Write("Enter {0} element of first array: ", i);
            }
            while ( !int.TryParse(Console.ReadLine(), out firstArray[i]) );
        }
        for ( int i = 0; i < size; i++ )
        {
            do
            {
                Console.Write("Enter {0} element of second array: ", i);
            }
            while ( !int.TryParse(Console.ReadLine(), out secondArray[i]) );
        }
    }

    private static uint InputArraySize()
    {
        uint size;
        do
        {
            Console.Write("Enter size of arrays: ");
        }
        while ( !uint.TryParse(Console.ReadLine(), out size) );
        return size;
    }
}
