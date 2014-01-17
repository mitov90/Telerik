using System;

class ExchangeBits
{
    static void Main()
    {
        int value;
        byte positionFirst;
        byte positionSecond;
        byte offset;
        InputValues(out value, out positionFirst, out positionSecond, out offset);
        
        int maskFirst;
        int maskSecond;

        CreateMask(value, positionFirst, positionSecond, offset, out maskFirst, out maskSecond);
        Console.WriteLine(Convert.ToString(maskFirst, 2).PadLeft(32).Replace('0', ' ') + " -> First mask");
        Console.WriteLine(Convert.ToString(maskSecond, 2).PadLeft(32).Replace('0', ' ') + " -> Second mask");

        value = SwapNumberWIthMask(value, positionFirst, positionSecond, maskFirst, maskSecond);
        Console.WriteLine(Convert.ToString(value, 2).PadLeft(32, '0') + " -> After exchange " + value);


    }

    private static int SwapNumberWIthMask(int value, byte positionFirst, byte positionSecond, int maskFirst, int maskSecond)
    {
        ClearValueFromMask(ref value, maskFirst, positionFirst);
        ClearValueFromMask(ref value, maskSecond, positionSecond);

        SetBitsFromMask(ref value, maskFirst, positionFirst, positionSecond);

        SetBitsFromMask(ref value, maskSecond, positionSecond, positionFirst);
        return value;
    }

    private static void CreateMask(int value, byte positionFirst, byte positionSecond, byte offset, out int maskFirst, out int maskSecond)
    {
        GetMask(out maskFirst, positionFirst, offset);
        GetMask(out maskSecond, positionSecond, offset);
        maskFirst = GetBitsFromMask(value, maskFirst);
        maskSecond = GetBitsFromMask(value, maskSecond);
    }

    private static void InputValues(out int value, out byte positionFirst, out byte positionSecond, out byte offset)
    {


        do
        {
            Console.Write("Enter value: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out value) );
        Console.WriteLine(Convert.ToString(value, 2).PadLeft(32, '0') + " -> This number as binary");

        do
        {
            Console.Write("Enter first position p: ");
        }
        while ( !byte.TryParse(Console.ReadLine(), out positionFirst) || positionFirst > 31 );

        do
        {
            Console.Write("Enter second position q: ");
        }
        while ( !byte.TryParse(Console.ReadLine(), out positionSecond) || positionSecond > 31 );

        do
        {
            Console.Write("Enter offset k: ");
        }
        while ( !byte.TryParse(Console.ReadLine(), out offset) || offset > 31 );
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
        value &= ~mask;
    }

    static int GetBitsFromMask(int value, int mask)
    {
        mask &= value;
        return mask;
    }

    static int GetMask(out int mask, byte position, byte offset)
    {
        mask = 0;
        for ( int i = 0; i < offset; i++ )
        {
            mask = mask | ( 1 << ( position + i ) );
        }
        return mask;
    }

}

