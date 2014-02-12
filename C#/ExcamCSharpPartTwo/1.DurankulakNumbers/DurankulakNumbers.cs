using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class DurankulakNumbers
{
    public static char[] numSystem = new char[26];

    static void Main()
    {
        var input = Input();

        var numberList = new List<int>();
        
        var numberBuilder = new StringBuilder();

        for (int curIndex = 0; curIndex < input.Length; curIndex++)
        {
            numberBuilder.Append(input[curIndex]);

            if (char.IsUpper(input[curIndex]))
            {
                numberList.Add(ExtractNumber(numberBuilder.ToString().ToLower()));
                numberBuilder.Clear();
            }

        }
        ulong result = 0;
        for (int index = 0; index < numberList.Count; index++)
        {
            result += (ulong) numberList[index]*(ulong) Math.Pow(168, numberList.Count-1-index);
        }
        Console.WriteLine(result);
    }

    private static string Input()
    {
        for (int i = 0; i < numSystem.Length; i++)
        {
            numSystem[i] = (char) ('a' + i);
        }

        string input = Console.ReadLine();
        return input;
    }

    private static int ExtractNumber(string toString)
    {
        int result = 0;
        int length = toString.Length;

        for (int i = length - 1; i >= 0; i--)
        {
            int curValue = GetValueFromChar(toString[i]);
            curValue = i == length - 1 ? curValue : curValue+1;
            result += curValue*(int)Math.Pow(26, length - 1 - i);
        }

        return result;
    }

    private static int GetValueFromChar(char c)
    {
        for (int i = 0; i < numSystem.Length; i++)
        {
            if (c==numSystem[i])
                return i;
        }
        return -1;
    }
}
