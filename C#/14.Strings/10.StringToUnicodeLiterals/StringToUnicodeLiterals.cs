using System;

class StringToUnicodeLiterals
{
    static void Main()
    {
        string inputData = "Hi!";

        foreach (char ch in inputData)
        {
            Console.Write("\\u{0:x4}", (short) ch);
        }

    }
}
