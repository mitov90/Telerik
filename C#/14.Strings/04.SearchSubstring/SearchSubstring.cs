using System;
using System.Text.RegularExpressions;

class SearchSubstring
{
    static void Main()
    {
        string input = "We are living in an yellow submarine. We don't have anything else. " +
                       "Inside the submarine is very tight. So we are drinking all the day. " +
                       "We will move out of it in 5 days.";
        string word = "in";

        Console.WriteLine(CountWord(input,word));

    }

    private static int CountWord(string input, string word)
    {
        int counter = 0;
        Match match = (new Regex(String.Format("{0}", word),RegexOptions.IgnoreCase)).Match(input);

        while(match.Success)
        {
            counter++;
            match = match.NextMatch();
        }

        return counter;
    }

}
