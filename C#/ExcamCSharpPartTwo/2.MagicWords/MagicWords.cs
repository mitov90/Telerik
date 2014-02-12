using System;
using System.Linq;
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
        var words = new string[numLines];
        int maxLenght = 0;
        for ( int i = 0; i < numLines; i++ )
        {
            words[i] = Console.ReadLine();
            if ( words[i].Length > maxLenght )
                maxLenght = words[i].Length;
        }

        List<string> myList = words.ToList();
       
        Reorder(myList);
        PrintMagic(myList, maxLenght);

    }

    private static void PrintMagic(List<string> myList, int maxLenght)
    {
        var result = new StringBuilder();
       
        for (int curChar = 0; curChar <= maxLenght; curChar++)
        {

            for (int curWord = 0; curWord < myList.Count; curWord++)
            {
                if (myList[curWord].Length > curChar)
                result.Append(myList[curWord][curChar]);
            }

        }
        Console.Write(result);
    }

    private static void Reorder(IList<string> words )
    {
      for (int i = 0; i < words.Count; i++)
            {
                int index = words[i].Length % (words.Count + 1);
                words.Insert(index, words[i]);
                if (i > index)
                {
                    words.RemoveAt(i + 1);
                }
                else
                {
                    words.RemoveAt(i);
                }
            }
       
    }
}