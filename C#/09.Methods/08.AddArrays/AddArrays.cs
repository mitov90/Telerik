using System;

class AddArrays
{
    static void Main()
    {
        int[] a = { 0,9,9,9,8,9,9,9 };
        int[] b = { 1 };

        int[] result = AddPositiveIntegers(a, b);

        foreach ( var item in result )
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }

    public static int[] AddPositiveIntegers(int[] a, int[] b)
    {
        if ( a == null || b == null )
            throw new ArgumentException("Array is null");

        int aLength = a.Length;
        int bLength = b.Length;
        int max = Math.Max(aLength, bLength);
        int[] result = new int[max + 1];
        int transfer = 0;

        for ( int i = 0; i <= max; i++ )
        {
            int tempA = aLength - i -1 >= 0 ? a[aLength - i -1] : 0;
            int tempB = bLength - i -1 >= 0 ? b[bLength - i -1] : 0;
            int tempResult = tempA + tempB + transfer;

            result[max - i] = tempResult % 10;
            transfer = tempResult / 10;
        }

        return result;
    }
}