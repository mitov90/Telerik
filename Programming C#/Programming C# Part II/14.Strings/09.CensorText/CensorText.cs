using System;
using System.Linq;
using System.Text.RegularExpressions;

class CensorText
{
    static void Main()
    {
           string input = "Microsoft announced its next generation PHP compiler today." +
                       " It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";

        string forbWords = "PHP, CLR, Microsoft";

        char symbolCensor = '*';
        string[] words = forbWords.Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);

        //input = words.Aggregate(input, (current, word) => current.Replace(word, new string(symbolCensor, word.Length)));

        input = words.Aggregate(input, ReplaceForbiddenWord);

        Console.WriteLine(input);
    }

    private static string ReplaceForbiddenWord(string input, string word)
    {
        string pattern = String.Format(@"\b{0}\b", word);

        string result = Regex.Replace(input, pattern, new String('*', word.Length));

        return result;
    }
}
