using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Rock
{
    private char[] symbols = new char[] { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };
    private char mySymb;
    private ConsoleColor color;
    private Point location;

    public Rock(int randNum)
    {
        mySymb = symbols[randNum % symbols.Length];
        color = (ConsoleColor)( randNum % (int)ConsoleColor.Yellow );
        location = new Point(randNum%Console.BufferWidth, 0);
    }

    public void Draw()
    {
        Console.SetCursorPosition(location.x, location.y);
        Console.ForegroundColor = color;
        Console.Write(mySymb);
    }

    public Rock FallDown(int dwarfPosition, int dwarfSize)
    {
        if (location.y<Console.BufferHeight-1)
        {
            location.y++;
            return this;
        }
        else
        {
            if ( location.x >= dwarfPosition && 
                location.x <= dwarfPosition+dwarfSize )
                throw new Exception("Game Over!");
            return null;
        }
    }
   
}
