using System;
using System.Linq;

class HelpDoge
{
    static int pathFound = 0;
    static bool[,] field;
    static int[] foodPos;

    static void Main()
    {
        var fieldSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
        field = new bool[fieldSize[0], fieldSize[1]];

        foodPos = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int numEnemies = int.Parse(Console.ReadLine());

        for (int i = 0; i < numEnemies; i++)
        {
            var enemyPos = Console.ReadLine().Split().Select(int.Parse).ToArray();
            field[enemyPos[0], enemyPos[1]] = true;
        }

        GeneratePath();
        Console.WriteLine(pathFound);
    }

    public static void GeneratePath(int curX, int curY, int direction)
    {
        if (direction = 0) curX++;
        else curY++;
        
        if (curX > field.GetLength(0) - 1
            || curY > field.GetLength(1) - 1
            || field[curX, curY])
            return;
        else if (curX == foodPos[0] && curY == foodPos[1])
            pathFound++;

        GeneratePath(curX, curY, 0);
        GeneratePath(curX, curY, 1);
    }

    public static void GeneratePath()
    {
        GeneratePath(0, 0, 0);
        GeneratePath(0, 0, 1);
    }
}
