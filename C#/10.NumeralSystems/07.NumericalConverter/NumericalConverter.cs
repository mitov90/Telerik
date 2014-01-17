using System;
using System.Text;

class NumericalConverter
{
    readonly static string symbols = "0123456789ABCDEF";
    static void Main()
    {
        Console.WriteLine(Converter("10010", 2, 10));
        Console.WriteLine(Converter("123", 3, 10));
        Console.WriteLine(Converter("11", 10, 2));
        Console.WriteLine(Converter("FF", 16, 2));
    }

    private static string Converter (string number, int fromBase, int toBase)
    {
        return ToOtherBase(ToDecimal(number, fromBase), toBase);
    }

    private static string ToOtherBase(string numberAsString, int toBase)
    {
        StringBuilder result = new StringBuilder();

        int number = int.Parse(numberAsString);
        while ( number != 0 )
        {
            result.Append(symbols[number % toBase]);
            number /= toBase;
        }
        char[] finalResult = result.ToString().ToCharArray();
            Array.Reverse(finalResult);
        return new string (finalResult);
    }

    private static string ToDecimal(string number, int fromBase)
    {
        int result = 0;
        
        int length = number.ToString().Length;

        for ( int i = 0; i < length; i++ )
        {
            result += GetDigit(number) * (int)Math.Pow(fromBase, i);
            number = number.Remove(number.Length - 1, 1);
        }

        return result.ToString();
    }
  
    private static int GetDigit(string number)
    {
        char hexDigit = number[number.Length - 1];
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
                return hexDigit - '0';
        }
    }
}