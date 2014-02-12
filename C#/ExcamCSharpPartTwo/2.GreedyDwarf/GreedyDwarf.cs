using System;
using System.Linq;

class GreedyDwarf
{
    static void Main()
    {
        int numPatterns;
        int[][] patterns;
        var valley = ReadInput(out numPatterns, out patterns);

        long maxCoins = long.MinValue;

        for (int curPattern = 0; curPattern < numPatterns; curPattern++)
        {
            var visited = new bool[valley.Length];
            long coins = 0;
            int positionInValley = 0;
            int curStep = 0;

            while (!visited[positionInValley])
            {
                visited[positionInValley] = true;
                coins += valley[positionInValley];

                int newPos = positionInValley + patterns[curPattern][curStep%patterns[curPattern].Length];
                if (newPos >= valley.Length || newPos<0)
                {
                    break;
                }
                positionInValley = newPos;
                curStep++;

            }

            if (coins > maxCoins)
            {
                maxCoins = coins;
            }

        }
        Console.WriteLine(maxCoins);
    }

    private static int[] ReadInput(out int numPatterns, out int[][] patterns)
    {
        var valley = InputLineOfInts();
        numPatterns = int.Parse(Console.ReadLine());
        patterns = new int[numPatterns][];
        for (int pattern = 0; pattern < numPatterns; pattern++)
        {
            patterns[pattern] = InputLineOfInts();
        }
        return valley;
    }

    private static int[] InputLineOfInts()
    {
        var valley =
            Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        return valley;
    }
}
