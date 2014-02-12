using System;
using System.Text;
using System.Text.RegularExpressions;

class FTML
{
    private static string ReadInput()
    {
        int lines = int.Parse(Console.ReadLine());
        StringBuilder input = new StringBuilder();

        for (int line = 0; line < lines; line++)
        {
            input.AppendLine(Console.ReadLine());
        }
        return input.ToString();
    }

    private static void Main()
    {
        var input = ReadInput();

        string upperPattern = string.Format(@"(?m)<{0}>(?<group>[^<>]*?)</{0}>", "upper");
        string lowerPattern = string.Format(@"(?m)<{0}>(?<group>[^<>]*?)</{0}>", "lower");
        string reversePattern = string.Format(@"(?m)<{0}>(?<group>[^<>]*?)</{0}>", "rev");
        string toglePattern = string.Format(@"(?m)<{0}>(?<group>[^<>]*?)</{0}>", "toggle");
        string delPattern = string.Format(@"(?m)<{0}>(?<group>[^<>]*?)</{0}>", "del");

        int matches = 0;

        do
        {
            matches = 0;

            if (Regex.Match(input, delPattern).Success)
            {
                matches++;
                input = Regex.Replace(input, delPattern, string.Empty);
            }
            if (Regex.Match(input, reversePattern).Success)
            {
                matches++;
                input = Regex.Replace(input, reversePattern, ReverseString);
            }
            if (Regex.Match(input, upperPattern).Success)
            {
                matches++;
                input = Regex.Replace(input, upperPattern, m => (m.Groups[1].Value.ToUpper()));
            }
            if (Regex.Match(input, lowerPattern).Success)
            {
                matches++;
                input = Regex.Replace(input, lowerPattern, m => (m.Groups[1].Value.ToLower()));
            }
            if (Regex.Match(input, toglePattern).Success)
            {
                matches++;
                input = Regex.Replace(input, toglePattern, ToggleString);
            }


        }
        while (matches > 0);


        Console.Write(input);
    }

    private static string ToggleString(Match match)
    {
        var result = new StringBuilder();
        string orig = match.Groups[1].Value;
        int length = orig.Length;

        for (int index = 0; index < length; index++)
        {
            if (char.IsLower(orig[index]))
            {
                result.Append(char.ToUpper(orig[index]));
            }
            else if (char.IsUpper(orig[index]))
            {
                result.Append(char.ToLower(orig[index]));
            }
            else
            {
                result.Append(orig[index]); //CHECK NEW LINE
            }
        }

        return result.ToString();
    }

    private static string ReverseString(Match match)
    {
        var result = new StringBuilder();
        string orig = match.Groups[1].Value;
        int length = orig.Length;

        for (int i = length - 1; i >= 0; i--)
        {
            if (orig[i] == '\r') 
               continue;
            result.Append(orig[i]); //CHECK NEW LINE
        }

        return result.ToString();
    }



}
