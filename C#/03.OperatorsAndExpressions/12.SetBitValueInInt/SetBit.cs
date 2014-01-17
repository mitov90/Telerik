using System;

class SetBit
{
    static void Main()
    {
        int num;
        byte value;
        byte positionBit;
        const byte numBitsInInt=31;
        Input(numBitsInInt, out num, out positionBit, out value);

        if ( value == 1 )
        {
            int mask = value << positionBit;
            num |= mask;
        }
        else
        {
            int mask = ~( 1 << positionBit );
            num &= mask;
        }
        Console.WriteLine("After change bit at positon {0}, value is: {1}",positionBit,num);

    }
    private static void Input(byte numberBitsInt, out int num, out byte bitPosition, out byte value)
    {
        do
        {
            Console.Write("Enter integer:");
        }
        while ( !int.TryParse(Console.ReadLine(), out num) );
        Console.WriteLine("Int as binary: {0}", IntAsBinaryStr(num));
        //stirng.PadLeft(32, '0') to fill with 0 to 32bit

        do
        {
            Console.Write("Enter position of the bit:");
        }
        while ( !byte.TryParse(Console.ReadLine(), out bitPosition) ||
            bitPosition < 0 || bitPosition > numberBitsInt );

        do
        {
            Console.Write("Enter value of the bit:");
        }
        while ( !byte.TryParse(Console.ReadLine(), out value) ||
            !(value==0 || value==1));
    }

    static string IntAsBinaryStr (int num)
    {
        return Convert.ToString(num,2);
    }
}