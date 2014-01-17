using System;

class CheckBit
{
    //public static int CountBits(uint value)
    //{
    //    int count = 0;
    //    while ( value != 0 )
    //    {
    //        count++;
    //        value &= value - 1;
    //    }
    //    return count;
    //}

    static void Main()
    {
        int value;
        int bitPosition;
        const byte numberBitsInt = 31;
        Input(numberBitsInt, out value, out bitPosition);

        int mask = 1 << bitPosition;
        value &= mask;
        value >>= bitPosition;
        Console.WriteLine("p={0}->{1}",bitPosition,!(value==0));
    }

    private static void Input(byte numberBitsInt, out int value, out int bitPosition)
    {
        do
        {
            Console.Write("Enter integer:");
        }
        while ( !int.TryParse(Console.ReadLine(), out value) );
        do
        {
            Console.Write("Enter position of the bit:");
        }
        while ( !int.TryParse(Console.ReadLine(), out bitPosition) ||
            bitPosition < 0 || bitPosition > numberBitsInt );
    }
}
