using System;
using System.Text.RegularExpressions;

class ReverseWordOrder
{
    private static string ReverseWordsOrder(string input)
    {
        string pattern = @"[^\s\.;,?!]+";

        var regex = new Regex(pattern);

        MatchCollection matches = regex.Matches(input);
        string result = input;

        int numWords = matches.Count;
        int curIndex = 0;

        for (int curWord = numWords -1 ; curWord >= 0; curWord--)
        {
            string newWord = matches[curWord].Value;
            result = regex.Replace(result, newWord,1,curIndex);
            curIndex = result.IndexOf(newWord, curIndex, System.StringComparison.Ordinal) + newWord.Length;
        }
        
        return result;
    }

    static void Main()
    {
        Console.WriteLine("Enter a valid sentence:");
        string sentence = Console.ReadLine();

        string result = ReverseWordsOrder(sentence);

        Console.WriteLine("The sentence with words in reversed order:\n{0}", result);
    }
}