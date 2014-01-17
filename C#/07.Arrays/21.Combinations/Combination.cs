using System;
using System.Linq;

class Combination
{
    static void Main()
    {
        Console.Write("Enter a number N: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter a number K: ");
        int k = int.Parse(Console.ReadLine());

        int[] elem = new int[k];

        for ( int i = 0; i < k; i++ )
        {
            elem[i]=i+1;
        }

        bool isEnd = false;
        do
        {
            PrintElements(elem);
            for ( int i = 0; i < k; i++ )
            {
                if ( elem[i] < n )
                {
                    elem[i] += 1;
                    isEnd = false;
                    break;
                }
                else if ( elem[i] >= n )
                {
                    elem[i] = 1;
                    isEnd = true;
                }

            }
        } while ( isEnd != true );

    }

    static void PrintElements(int[] arr)
    {
        for ( int i = arr.Length - 1; i >= 0; i-- )
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}