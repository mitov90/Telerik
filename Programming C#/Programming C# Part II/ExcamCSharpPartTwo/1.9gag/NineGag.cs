using System;
using System.Collections.Generic;
using System.Text;

internal class NineGag
{
    private static ulong powerfOfNine = 1;

    private static string[] nineGag =
    {
        "-!",
        "**",
        "!!!",
        "&&",
        "&-",
        "!-",
        "*!!!",
        "&*!",
        "!!**!-"
    };

    static void Main()
    {
        string input = Console.ReadLine();
        var listDigits = new List<int>();

        GetDigits(input, listDigits);

        ulong result = 0;


        for (int i = listDigits.Count - 1; i >= 0; i--)
        {
            result += (ulong)listDigits[i]*powerfOfNine;
            powerfOfNine *= 9;
        }

        Console.WriteLine(result);
    
    }

    private static void GetDigits(string input, List<int> listDigits)
    {
        int lenght = input.Length;
        var tempValue = new StringBuilder();

        for (int curIndex = 0; curIndex < lenght; curIndex++)
        {
            tempValue.Append(input[curIndex]);
            string tempDigi = tempValue.ToString();

            for (int i = 0; i < nineGag.Length; i++)
            {
                if (nineGag[i] == tempDigi)
                {
                    listDigits.Add(i);
                    tempValue.Clear();
                    break;
                }
            }
        }
    }
}
