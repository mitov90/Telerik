using System;
using System.Text.RegularExpressions;

class ExecuteRegionInString
{
    static void Main()
    {
        string input = "We are living in a <upcase>yellow submarine</upcase>. " +
                       "We don't have <upcase>anything</upcase> else.";
        Console.WriteLine(  ExecuteRegion(input, "upcase"));

    }

    private static string ExecuteRegion(string input, string region)
    {
        string result = String.Empty;
        string pattern = string.Format(@"<{0}>(.*?)</{0}>",region);
        var matches = Regex.Matches(input, pattern);

        foreach (var match in matches)
        {
           result =  Regex.Replace(input, pattern, m => m.Groups[1].Value.ToUpper());
        }

        return result;
    }

}
