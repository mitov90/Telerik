using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

class MagicWords
{
    static void Main()
    {
        if ( Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug") )
            Console.SetIn(new StreamReader("test.txt"));

        int numLines = int.Parse(Console.ReadLine());
        string[] words = new string[numLines];
        StringBuilder sb = new StringBuilder();
        int maxLenght = 0;
        for ( int i = 0; i < numLines; i++ )
        {
            words[i] = Console.ReadLine();
            if ( words[i].Length > maxLenght )
                maxLenght = words[i].Length;
        }

        List<string> myList = new List<string> {  };
        

       
        PrintMagicSentance(words, sb, maxLenght);

    }

    static void SwapIndex(ref string[] words, int firstIndex, int secondIndex)
    {
        string temp = words[firstIndex];
        words[firstIndex] = words[secondIndex];
        words[secondIndex] = temp;
    }

    private static void PrintMagicSentance(string[] words, StringBuilder sb, int maxLenght)
    {
        for ( int curLetter = 0; curLetter < maxLenght; curLetter++ )
        {
            for ( int word = 0; word < words.GetLength(0); word++ )
            {
                if ( words[word].Length > curLetter )
                    sb.Append(words[word][curLetter]);
            }
        }
        Console.WriteLine(sb);
    }
}