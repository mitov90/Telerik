using System;
using System.Collections.Generic;

internal class Crossword

{
    private static void Main()
    {
        var words = new List<string>();
        int N = int.Parse(Console.ReadLine());
        for (int i = 1; i <= N + N; i++)
        {
            string word = Console.ReadLine();
            words.Add(word);
        }
        //Stopwatch sw = new Stopwatch();
        //sw.Start();
        var crosswordGenerator = new CrosswordGenerator(words, N);
        string[] crossword = crosswordGenerator.GenerateCrossword();
        if (crossword == null)
        {
            Console.WriteLine("NO SOLUTION!");
        }
        else
        {
            foreach (string line in crossword)
            {
                Console.WriteLine(line);
            }
        }
        //sw.Stop();
        //Console.WriteLine(sw.Elapsed);
    }
}