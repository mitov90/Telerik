using System;

public class LargerThanNeighbours
{
    static void Main()
    {
        int[] arr;
        int position;
        Input(out arr, out position);

        CheckNeighbours(arr, position);
    }

    private static int CheckNeighbours(int[] arr, int position)
    {
        if ( position > 0 && position < arr.GetLength(0) - 1 )
        {
            if ( arr[position] > arr[position - 1] && arr[position] > arr[position + 1] )
            {
                Console.WriteLine("Bigger than neigbours!");
                return position;
            }
            else
            {
                Console.WriteLine("Neigbour is bigger or equal!");
            }
        }
        else
        {
            Console.WriteLine("Position has no two neigbours!");
        }
        return -1;
    }

    private static void Input(out int[] arr, out int searchingValue)
    {
        int size = InputNumber("Enter array size: ");
        arr = new int[size];

        for ( int i = 0; i < arr.GetLength(0); i++ )
        {
            arr[i] = InputNumber(string.Format("Enter {0} number: ", i));
        }

        searchingValue = InputNumber("Enter position: ");
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
}