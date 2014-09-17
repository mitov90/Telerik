using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Dwarf
{
    public Point location;
    public ConsoleColor color;
    public string symbol;

    public Dwarf (Point loc,string sym, ConsoleColor col)
    {
        this.location = loc;
        this.symbol = sym;
        this.color = col;
    }

    public void MoveLeft()
    {
        if (location.x != 0)
        location.x--;
    }

    public void MoveRight ()
    {
        if (location.x+symbol.Length < Console.BufferWidth)
        location.x++;
    }
    public void Draw()
    {
        Console.SetCursorPosition(location.x, location.y);
        Console.ForegroundColor = color;
        Console.Write(symbol);
    }
}