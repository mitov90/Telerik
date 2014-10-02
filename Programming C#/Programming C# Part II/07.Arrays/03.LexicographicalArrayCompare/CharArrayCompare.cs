using System;

class Program
{
    static void Main()
    {
        uint size;

        size = InputArraySize();
        char[] firstArray = new char[size];
        char[] secondArray = new char[size];
        InputArrays(size, firstArray, secondArray);
        try
        {
            if ( firstArray.Length != secondArray.Length )
                throw new InvalidOperationException("Diffrent size arrays");
            for ( int i = 0; i < firstArray.Length; i++ )
            {
                Console.WriteLine("{0}{1}{2}", firstArray[i], firstArray[i] == secondArray[i] ? "==" : "!=", secondArray[i]);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void InputArrays(uint size, char[] firstArray, char[] secondArray)
    {
        for ( int i = 0; i < size; i++ )
        {
            do
            {
                Console.Write("Enter {0} element of first array: ", i);
            }
            while ( !char.TryParse(Console.ReadLine(), out firstArray[i]) );
        }
        for ( int i = 0; i < size; i++ )
        {
            do
            {
                Console.Write("Enter {0} element of second array: ", i);
            }
            while ( !char.TryParse(Console.ReadLine(), out secondArray[i]) );
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
