using System;

class Zerg
{
    private static string[] _numSystem ={ "Rawr","Rrrr","Hsst","Ssst","Grrr","Rarr","Mrrr","Psst","Uaah","Uaha","Zzzz","Bauu","Djav","Myau","Gruh"};

    static void Main()
    {
        var digits = Input;
        ulong result = 0;
        int length = digits.Length;

        for (int curDigit = length - 1; curDigit >= 0; curDigit--)
        {
            ulong num = StringToNumber(digits[curDigit]);
            result += num*(ulong)Math.Pow( 15,digits.Length - curDigit -1);
        }
        Console.WriteLine(result);

    }

    private static string[] Input
    {
        get
        {
            string input = Console.ReadLine();
            string[] digits = new string[input.Length/4];

            for (int i = 0, curDigit = 0; i < input.Length; i += 4,curDigit++)
            {
                digits[curDigit] = input.Substring(i, 4);
            }
            return digits;
        }
    }

    private static ulong  StringToNumber(string numer)
    {
        ulong numValue = 0;

        while (_numSystem[numValue] != numer)
        {
            numValue++;
        }
        return numValue;
    }
}
