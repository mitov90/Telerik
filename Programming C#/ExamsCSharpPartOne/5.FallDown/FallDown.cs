using System;

class FallDown
{
    static void Main()
    {
        const int numberSizeByte = 8;
        const int numberLines = 8;
        byte[] matrix = new byte[numberLines];

        for ( int i = 0; i < numberLines; i++ )
        {
            matrix[i] = byte.Parse(Console.ReadLine());
        }

        for ( int i = numberLines - 1; i >= 0; i-- )
        {
            for ( int j = numberLines-1; j >= 0; j-- )
            {
                for ( int k = 0; k < numberSizeByte; k++ )
                {
                    if ( j >= numberLines-1 )
                        continue;

                    if ( ReturnBitAtPosition(matrix[j], k) == 1 && ReturnBitAtPosition(matrix[j + 1], k) == 0 )
                    {
                        matrix[j]= (byte)SetBitAtPosition(matrix[j], 0, k);
                        matrix[j + 1] = (byte)SetBitAtPosition(matrix[j + 1], 1, k);
                    }
                }
            }
        }

        #region Print Matrix
        foreach ( var num in matrix )
        {
            //Console.WriteLine(Convert.ToString(num, 2).PadLeft(8, ' '));
            Console.WriteLine(num);
        }
        #endregion

    }

    static int ReturnBitAtPosition(int number, int position)
    {
        int mask = 1 << position;
        mask &= number;
        mask = mask >> position;
        return mask;
    }
    static int SetBitAtPosition(int number, int bit, int position)
    {
        int mask = 1 << position;
        int result;
        if (bit == 1)
        {
            result = number | mask;
        }
        else
        {
            result = number & ~mask;
        }
        return  result;
    }

}

