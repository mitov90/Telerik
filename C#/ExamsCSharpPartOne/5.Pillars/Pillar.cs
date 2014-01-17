using System;

class Pillar
{
    static void Main(string[] args)
    {
        const int numLines = 8;
        const int bitsInByte = 8;
        short[] field = new short[numLines];
        
        for ( int i = 0; i < numLines; i++ )
        {
            field[i] = short.Parse(Console.ReadLine());
        }

        int counter = -1;
        int index = -1;
        for ( int currentCol = 0; currentCol < bitsInByte; currentCol++ )
        {
            int leftCounter = 0;
            int rightCounter = 0;

            for ( int leftCol = 7; leftCol > currentCol; leftCol-- )
            {
                for ( int curLine = 0; curLine < 8; curLine++ )
                {
                    leftCounter += ReturnBitAtPosition(field[curLine], leftCol);//todofield fo aliune 
                }
            }
            for ( int rightCol = 0; rightCol < currentCol; rightCol++ )
            {
                for ( int currLine = 0; currLine < 8; currLine++ )
                {
                    rightCounter += ReturnBitAtPosition(field[currLine], rightCol);//todo fuekd if line 
                }
            }

            if ( leftCounter == rightCounter )
            {
                index = currentCol;
                counter = leftCounter;
            }
        }
        if ( index == -1 )
            Console.WriteLine("No");
        else
        {
            Console.WriteLine(index);
            Console.WriteLine(counter);
        }
    }

    private static int ReturnBitAtPosition(short value, int postion)
    {
        int mask = 1 << postion;
        mask = mask & value;
        mask >>= postion;
        return mask;
    }
}
