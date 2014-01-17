using System;

internal static class SortStringByLenght
{
    private static void Main()
    {
        Console.WriteLine("Enter your sentance: ");
        var mySentance = Console.ReadLine().Trim().Split();
        Array.Sort(mySentance, (a, b) => a.Length.CompareTo(b.Length));

        foreach (var word in mySentance)
            Console.WriteLine(word);
    }
}