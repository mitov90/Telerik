using System;
using System.Text.RegularExpressions;

class BracketsCheck
{


     static void Main()
    {
        Console.Write("Enter an expression to check: ");
        string expression = Console.ReadLine();

        Console.WriteLine("This expression is{0} balanced.", IsBalanced(expression) ? String.Empty : " not");
    }


     public static bool IsBalanced(string expression)
    {
        string pattern = @"^(?x) (?: [^()] | (?<level> \( ) | (?<-level>) \) )*(?(level)(?!)) $";

        Match match = Regex.Match(expression, pattern);

        return match.Success;
    }


    private static int CountBrackets(string input)
    {
        int countBrackets = 0;

        for (int index = input.Length - 1; index >= 0; index--)
        {
            switch (input[index])
            {
                case ')':
                    countBrackets++;
                    break;
                case '(':
                    countBrackets--;
                    break;
                default:
                    break;
            }
        }
        return countBrackets;
    }

}
