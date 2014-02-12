#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

internal class VariableLengthCoding
{
    private static void Main()
    {
        string input = string.Join(string.Empty,
                                   Console.ReadLine()
                                          .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(byte.Parse)
                                          .Select(x => Convert.ToString(x, 2))
                                          .ToArray())
                             .TrimEnd('0');
        //c# linq expression , short one
        

        int numDictonary = int.Parse(Console.ReadLine());
        
        var dict = new Dictionary<int, char>();
        for (int cur = 0; cur < numDictonary; cur++)
        {
            string temp = Console.ReadLine();
            dict.Add(int.Parse(temp.Substring(1)), temp[0]);
        }

        var result = new StringBuilder();
        int charNumber = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '0')
            {
                result.Append(dict[charNumber]);
                charNumber = 0;
            }
            else
            {
                charNumber++;
                if (i == input.Length - 1)
                    result.Append(dict[charNumber]);
            }
        }

        Console.WriteLine(result);
    }
}
