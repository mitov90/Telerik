using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;

class ReverseString
{
    static void Main()
    {
        string str ="example";

        //var reverseStr = string.Concat(str.Reverse());

        //var reverseStr = str.Aggregate("", (acc, c) => c + acc);

        //var reverseStr = ReverseExpression(str);

        var reverseStr = ReverseIter(str);

        Console.WriteLine(reverseStr);
    }

    private static string ReverseExpression(string str)
    {
        string reverseStr = new string(str.Select((c, index) => new {c, index})
            .OrderByDescending(x => x.index)
            .Select(x => x.c)
            .ToArray());
        return reverseStr;

        //var reverseStr = str.ToCharArray()
        //                 .Select(ch => ch.ToString())
        //                 .Aggregate<string>((xs, x) => x + xs);

    }

    private static StringBuilder ReverseIter(string str)
    {
        StringBuilder reverseStr = new StringBuilder();

        for (int index = str.Length - 1; index >= 0; index--)
        {
            reverseStr.Append(str[index]);
        }
        return reverseStr;
    }
}
