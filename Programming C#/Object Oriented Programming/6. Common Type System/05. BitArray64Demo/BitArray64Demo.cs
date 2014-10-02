using System;

internal class BitArray64Demo
{
    private static void Main()
    {
        var bitArray = new BitArray64();

        bitArray[63] = 1;
        bitArray[62] = 1;

        int index = 0;
        foreach (int bit in bitArray)
        {
            Console.WriteLine("Bit {0,2}: {1}", index, bit);
            index++;
        }

        Console.WriteLine(bitArray);
    }
}
