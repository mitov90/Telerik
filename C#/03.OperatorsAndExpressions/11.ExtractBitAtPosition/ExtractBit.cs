using System;

class ExtractBit
{
     static void Main()
    {
        int value;
        int bitPosition;
        const byte numberBitsInt = 31;
        Input(numberBitsInt, out value, out bitPosition);

        int mask = 1 << bitPosition;
        value &= mask;
        value >>= bitPosition;
        Console.WriteLine("p={0}->{1}",bitPosition,value);
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

