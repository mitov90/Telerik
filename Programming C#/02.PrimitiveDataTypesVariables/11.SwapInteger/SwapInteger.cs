using System;

class SwapInteger
{
    static void SwapInt (ref int a,ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    static void Main()
    {
        int firstVal = 5;
        int secondVal = 10;
        Console.WriteLine("First: {0}, Second: {1}", firstVal, secondVal);
        SwapInt(ref firstVal,ref secondVal);
        Console.WriteLine("First: {0}, Second: {1}", firstVal, secondVal);
    }
}

