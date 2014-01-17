using System;

class HexToDec
{
    static void Main()
    {
        Console.Write("Enter hex number: ");
        string input = Console.ReadLine();

        int result = 0;
        int length = input.Length;
        for ( int i = 0; i < length; i++ )
        {
            result += GetHexDigit(input) * (int)Math.Pow(16, i);
        }
        Console.WriteLine(result);
    }
  


    private static int GetHexDigit(string input)
    {
        char hexDigit = input[input.Length - 1];
        switch ( hexDigit )
        {
            case 'A':
                return 10;
            case 'B':
                return 11;
            case 'C':
                return 12;
            case 'D':
                return 13;
            case 'E':
                return 14;
            case 'F':
                return 15;
            default:
                return hexDigit-'0';
        }
    }
}
