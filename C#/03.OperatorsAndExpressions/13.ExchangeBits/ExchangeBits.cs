using System;

class ExchangeBits
{
    static void Main()
    {
        int value;

        do
        {
            Console.Write("Enter value: ");
        }
        while(!int.TryParse(Console.ReadLine(), out value));
        int maskFirst;
        int maskSecond;
        byte positionFirst=3;
        byte positionSecond = 24;        
        byte offset=3;
        
        Console.WriteLine(Convert.ToString(value,2).PadLeft(32,'0') + " -> This number as binary");
        
        GetMask(out maskFirst, positionFirst, offset);
        GetMask(out maskSecond, positionSecond, offset);
        maskFirst = GetBitsFromMask(value, maskFirst);
        maskSecond = GetBitsFromMask(value, maskSecond);
        Console.WriteLine(Convert.ToString(maskFirst, 2).PadLeft(32).Replace('0', ' ') + " -> First mask");
        Console.WriteLine(Convert.ToString(maskSecond, 2).PadLeft(32).Replace('0', ' ') + " -> Second mask");

        ClearValueFromMask(ref value, maskFirst, positionFirst);
        ClearValueFromMask(ref value, maskSecond, positionSecond);

        SetBitsFromMask(ref value, maskFirst, positionFirst, positionSecond);

        SetBitsFromMask(ref value, maskSecond, positionSecond, positionFirst);
        Console.WriteLine(Convert.ToString(value, 2).PadLeft(32, '0') + " -> After exchange " + value);


    }

    private static void SetBitsFromMask(ref int value, int mask, byte thisPosition, byte gotoPosition)
    {
        if ( gotoPosition - thisPosition > 0 )
            value |= mask << gotoPosition - thisPosition;
        else
            value |= mask >> Math.Abs(gotoPosition - thisPosition);
         
    }
    private static void ClearValueFromMask(ref int value, int mask, byte position)
    {
        value &=  ~mask;
    }
    static int GetBitsFromMask (int value, int mask)
    {
        mask &= value;
        return mask;
    }
    static int GetMask (out int mask, byte position, byte offset)
    {
        mask = 0;
        for ( int i = 0; i < offset; i++ )
        {
            mask = mask | ( 1 << ( position + i ) );
        }
        return mask;
    }
}

