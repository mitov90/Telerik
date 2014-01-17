using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class ExtractSentace
{
    static void Main()
    {
        string input =
            "We are living in a yellow submarine. We don't have anything else. " +
            "Inside the submarine is very tight. So we are drinking all the day." +
            " We will move out of it in 5 days.";

        string searchingWord = "in";

         IEnumerable<string> sentences = GetSentencesContaining(input, searchingWord);

        Console.WriteLine(String.Join("\n", sentences));

    }
     private static IEnumerable<string> GetSentencesContaining(string input, string wordToFind)
    {
        string pattern = String.Format(@"[^.]*?\b{0}\b[^.?!]*[\.?!]", wordToFind);

        MatchCollection matches = Regex.Matches(input, pattern);

         return (from Match match in matches select match.Value.TrimStart()).ToList();
    }
}
