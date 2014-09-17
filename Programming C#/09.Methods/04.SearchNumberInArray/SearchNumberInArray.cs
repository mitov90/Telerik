using System;

public class SearchNumberInArray
{
    static void Main()
    {
        int[] arr;
        int position;
        Input(out arr, out position);

        Console.WriteLine(CountValue(arr, position));
    }

    private static void Input(out int[] arr, out int searchingValue)
    {
        int size = InputNumber("Enter array size: ");
        arr = new int[size];

        for ( int i = 0; i < arr.GetLength(0); i++ )
        {
            arr[i] = InputNumber(string.Format("Enter {0} number: ", i));
        }

        searchingValue = InputNumber("Enter searching value: ");
    }

    private static int InputNumber(string str)
    {
        int tempNumber;
        do
        {
            Console.Write(str);
        }
        while ( !int.TryParse(Console.ReadLine(), out tempNumber) );
        return tempNumber;
    }

    public static int CountValue(int[] arr, int value)
    {
        if ( arr == null )
            return 0;

        int count = 0;

        for ( int i = 0; i < arr.GetLength(0); i++ )
        {
            if ( arr[i] == value )
                count++;
        }

        return count;
    }
}