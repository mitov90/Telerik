using System;

class Lines
{
    static void Main(string[] args)
    {
        const int numberLines = 8;
        short[] matrix = new short[numberLines];

        for ( int i = 0; i < numberLines; i++ )
        {
            matrix[i] = short.Parse(Console.ReadLine());
        }

        #region Print Matrix
        //foreach ( var value in matrix )
        //{
        //    Console.WriteLine(Convert.ToString(value,2).PadLeft(8,' ').Replace('0',' '));
        //}
        #endregion

        int maxLen = 0;
        int counter = 0;

        #region Horizontal
        for ( int i = 0; i < numberLines; i++ ) // horizontal
        {
            int tempCounter = 0;
            for ( int j = 0; j < 8; j++ )
            {
                if ( ReturnBitAtPosition(matrix[i], j) == 1 )
                {
                    tempCounter++;
                    if ( tempCounter == maxLen )
                    {
                        counter++;
                    }
                    else if(tempCounter>maxLen)
                    {
                        maxLen = tempCounter;
                        counter = 1;
                    }
                }
                else
                {
                    tempCounter = 0;
                }
            }

        } 
        #endregion
        #region Vertical
        for ( int i = 0; i < numberLines; i++ )
        {
            int tempCounter = 0;
            for ( int j = 0; j < 8; j++ )
            {
                if ( ReturnBitAtPosition(matrix[j],i) == 1 )
                {
                    tempCounter++;
                    if ( tempCounter == maxLen )
                    {
                        counter++;
                    }
                    else if (maxLen<tempCounter)
                    {
                        maxLen = tempCounter;
                        counter = 1;
                    }
                }
                else
                {
                    tempCounter = 0;
                }
            }
        }
        #endregion
        if ( maxLen == 1 )
            counter /= 2;
        Console.WriteLine(maxLen);
        Console.WriteLine(counter);
    }
    static int ReturnBitAtPosition(int number, int position)
    {
        int mask = 1 << position;
        mask &= number;
        mask = mask >> position;
        return mask;
    }
}
