using System;
using System.Text;

class NumberToString
{
    static void Main()
    {
        short number;
        do
        {
            Console.Write("Enter number [0..999]: ");
        }
        while ( !short.TryParse(Console.ReadLine(), out number) || number > 999 || number < 0 );
        byte numDigits = CountDigits(number);
        string result = ConvertNumberToString(number, numDigits);
        result = UppercaseFirstLetterOfString(result);
        Console.WriteLine(result);
    }

    private static string UppercaseFirstLetterOfString(string result)
    {
        if ( string.IsNullOrEmpty(result) )
            return string.Empty;
        result = char.ToUpper(result[0]) + result.Substring(1);
        return result;
    }

    private static string ConvertNumberToString(short number, byte numDigits)
    {
        string[] ones = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        string[] tens = { "none", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        string[] teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        int result;
        StringBuilder numberAsText = new StringBuilder();
        bool isTeens = false;
        for ( int i = 1; i < numDigits + 1; i++ )
        {
            int tempDigit = numDigits - i;
            result = ( number / (int)Math.Pow(10, tempDigit) ) % 10;
            switch ( tempDigit )
            {
                case 0:
                    if ( isTeens )
                        numberAsText.Append(teens[result]);
                    else
                        numberAsText.Append(ones[result]);
                    break;
                case 1:
                    if ( result == 0 )
                        numberAsText.Append("and ");
                    else
                    {
                        if ( result == 1 )
                            isTeens = true;
                        else
                            numberAsText.Append(tens[result] + "and ");
                    }
                    break;
                case 2:
                    numberAsText.Append(ones[result] + " hundred ");
                    break;
                default:
                    break;
            }
        }
        return numberAsText.ToString();
    }

    private static byte CountDigits(short number)
    {
        byte numDigits = 0;
        int result = number;
        while ( true )
        {
            result /= 10;
            numDigits++;
            if ( result == 0 )
                break;
        }
        return numDigits;
    }
}

