using System;

class Program
{
    static void Main()
    {
        ushort one = 52130;
        sbyte two = -115;
        int three = 4825932;
        sbyte four = 97;
        short five = -10000;

        Console.WriteLine("Min Value: {0}, Max Value: {1}, typeof({2})", byte.MinValue, byte.MaxValue, typeof(byte));
        Console.WriteLine(two.ToString());
        Console.WriteLine(four.ToString());
        Console.WriteLine("Min Value: {0}, Max Value: {1}, typeof({2})", short.MinValue, short.MaxValue, typeof(short));
        Console.WriteLine(five.ToString());
        Console.WriteLine("Min Value: {0}, Max Value: {1}, typeof({2})", ushort.MinValue, ushort.MaxValue, typeof(ushort));
        Console.WriteLine(one.ToString());
        Console.WriteLine("Min Value: {0}, Max Value: {1}, typeof({2})", int.MinValue, int.MaxValue, typeof(int));
        Console.WriteLine(three.ToString());
    }
}