using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

class KaspichanNumbers
{
    private static char[] kaspichanSystem;

    private static string[] BuildDigits()
    {
        List<string> digits = new List<string>();
        for (char digit = 'A'; digit <= 'Z'; digit++)
        {
            digits.Add("" + digit);
        }
        for (char prefix = 'a'; prefix <= 'z'; prefix++)
        {
            for (char suffix = 'A'; suffix <= 'Z'; suffix++)
            {
                string digit = "" + prefix + suffix;
                digits.Add(digit);
            }
        }
        return digits.ToArray();
    }

    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());
        InitializationArrays();
        var result = new List<string>();
        var numberLength = number.ToString(CultureInfo.InvariantCulture).Length;

        do
        {
            int tempValue = (int) (number%256);
            number /= 256;
            result.Add(ConvertToKaspichan(tempValue));

        } while (number != 0);
        result.Reverse();
        foreach (var kasp in result)
        {
            Console.Write(kasp);
            
        }
    }

    private static void InitializationArrays()
    {
        kaspichanSystem = new char[26];
        for (int i = 0; i < 26; i++)
        {
            kaspichanSystem[i] = (char) ('a' + i);
        }
    }

    static string ConvertToKaspichan(int value)
    {
        var result = new StringBuilder();
        if (value == 26)
        {
            return "aA";
        }
        do
        {
            if (value/26 == 0)
            {
                result.Append(char.ToUpper(kaspichanSystem[value]));
                value /= 26;
            }
            else
            {
                result.Append(kaspichanSystem[value/26 - 1]);
                value %= 26;
            }
        } while (value != 0);

        return result.ToString();
    }
}
