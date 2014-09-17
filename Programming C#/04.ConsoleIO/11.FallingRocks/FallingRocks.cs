using System;
using System.Collections.Generic;
using System.Threading;

class FallingRocks
{
    static void Main()
    {
        #region gameOptions
        int gameSpeed = 150;
        int gameHight = 34;
        int gameWight = 60;
        uint scores = 0;
        #endregion

        SetWindowSize(gameHight, gameWight);
        ConsoleKeyInfo pressedKey = new ConsoleKeyInfo();
        Random rand = new Random();
        List<Rock> rocks = new List<Rock>();
        Dwarf myDwarf = new Dwarf(new Point(gameWight / 2, gameHight - 1), "<0>", ConsoleColor.DarkGreen);

        try
        {
            while ( true )
            {
                Console.Clear();
                UpdateDwarf(pressedKey, myDwarf);
                UpdateRocks(ref scores, ref rocks, rand, myDwarf);
                Thread.Sleep(gameSpeed);
            }
        }
        catch(Exception ex)
        {
            Console.ReadKey();
            Console.SetCursorPosition(0,gameHight/2);
            Console.WriteLine(ex.Message + " Your Score: " + scores);
        }
    }

    private static ConsoleKeyInfo UpdateDwarf(ConsoleKeyInfo pressedKey, Dwarf myDwarf)
    {
        UserInputForDwarf(pressedKey, myDwarf);
        myDwarf.Draw();
        return pressedKey;
    }

    private static void UpdateRocks(ref uint scores, ref List<Rock> rocks, Random rand, Dwarf myDwarf)
    {
        rocks.Add(new Rock(rand.Next()));
        List<Rock> newRocks = new List<Rock>();
        foreach ( var rock in rocks )
        {
            Rock newRock = rock.FallDown(myDwarf.location.x, myDwarf.symbol.Length);
            if ( newRock != null )
                newRocks.Add(newRock);
            rock.Draw();
            scores += 1;
        }
        rocks = newRocks;
    }

    private static ConsoleKeyInfo UserInputForDwarf(ConsoleKeyInfo pressedKey, Dwarf myDwarf)
    {
        if ( Console.KeyAvailable )
        {
            pressedKey = Console.ReadKey(true);
            while ( Console.KeyAvailable ) { Console.ReadKey(true); }
            if ( pressedKey.Key == ConsoleKey.LeftArrow )
                myDwarf.MoveLeft();
            if ( pressedKey.Key == ConsoleKey.RightArrow )
                myDwarf.MoveRight();
        }
        return pressedKey;
    }

    private static void SetWindowSize(int consoleHight, int consoleWidght)
    {
        Console.SetWindowSize(consoleWidght, consoleHight);
        Console.SetBufferSize(consoleWidght, consoleHight);
    }
}
