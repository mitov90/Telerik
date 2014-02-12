using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class Brackets
{
    static void Main()
    {
        //if (Environment.CurrentDirectory.EndsWith("bin\\Debug"))
        //{
        //    Console.SetIn(new StreamReader("test.txt"));
        //}

        int numLines = int.Parse(Console.ReadLine());
        var input = new string[numLines];
        var indent = Console.ReadLine();
        int numIndents = 0;
        var result = new StringBuilder();
        
        for (int i = 0; i < numLines; i++)
        {
            input[i] = Regex.Replace(Console.ReadLine(), @"\s\s+", " ");
        }

        for (int line = 0; line < numLines; line++)
        {
            var tempResult = new StringBuilder();

            for (int charIndex = 0; charIndex < input[line].Length; charIndex++)
            {
                if (input[line][charIndex] == '{')
                {
                    if (!string.IsNullOrEmpty(tempResult.ToString().Trim()))
                    {
                        result.Append(AddLineIndent(indent, numIndents));
                        result.AppendLine(tempResult.ToString().Trim());
                    }
                    result.Append(AddLineIndent(indent, numIndents++));
                    result.AppendLine("{");
                    tempResult.Clear();

                }
                else if (input[line][charIndex] == '}')
                {
                    if (!string.IsNullOrEmpty(tempResult.ToString().Trim()))
                    {
                        result.Append(AddLineIndent(indent, numIndents));
                        result.AppendLine(tempResult.ToString().Trim());
                    }
                    result.Append(AddLineIndent(indent, --numIndents));
                    result.AppendLine("}");
                    tempResult.Clear();
                }
                else 
                {
                    tempResult.Append(input[line][charIndex]);
                }
            }
            if (!string.IsNullOrEmpty(tempResult.ToString().Trim()))
            {
                result.Append(AddLineIndent(indent, numIndents));
                result.AppendLine(tempResult.ToString().Trim());
                tempResult.Clear();
            }

        }
        Console.WriteLine(result);

    }

    private static string AddLineIndent(string indent, int num)
    {
        var result = new StringBuilder();

        for (int i = 0; i < num; i++)
        {
            result.Append(indent);
        }

        return result.ToString();
    }


}
