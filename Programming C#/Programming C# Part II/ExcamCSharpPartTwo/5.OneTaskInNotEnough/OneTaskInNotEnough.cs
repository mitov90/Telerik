using System;
using System.Data;

class OneTaskInNotEnough
{
    static void Main()
    {
        Console.WriteLine(LastLamp(int.Parse(Console.ReadLine())));
        Console.WriteLine(GoodJoro(Console.ReadLine()));
        Console.WriteLine(GoodJoro(Console.ReadLine()));
        
    }

    private static string GoodJoro(string commands)
    {
        int[,] directions =
        {
            {0, 1},
            {1, 0},
            {0, -1},
            {-1, 0}
        };

        int dir = 0, row=0, col = 0;

        for (int i = 0; i < 4; i++)
        {
            for (int command = 0; command < commands.Length; command++)
            {
                switch (commands[command])
                {
                    case 'L':
                        dir = (dir + 3)%4;
                        break;
                    case 'R':
                        dir = (dir + 1)%4;
                        break;
                    case 'S':
                        row += directions[dir, 0];
                        col += directions[dir, 1];
                        break;
                }
            }
        }

        if (row == 0 && col == 0)
            return "bounded";
        else
            return "unbounded";

    }

    static int LastLamp(int lampCount)
    {
        int[] lamps = new int[lampCount];

        for (int i = 0; i < lampCount; i++)
        {
            lamps[i] = i + 1;
        }

        int jump = 2;
        while (lampCount > 1)
        {

            for (int i = 0; i < lampCount; i += jump)
            {
                lamps[i] = 0;
            }

            int index = 0;

            for (int i = 0; i < lampCount; i++)
            {
                if (lamps[i] != 0)
                {
                    lamps[index++] = lamps[i];
                }
            }

            lampCount = index;
            jump++;
        }

        return lamps[0];

    }

}
