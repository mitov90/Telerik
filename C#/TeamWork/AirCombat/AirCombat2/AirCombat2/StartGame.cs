#region

using System;
using System.CodeDom;
using System.Collections.Generic;
using AirCombat2.GameLogic;

#endregion

public class StartGame
{
    #region GameSettings
    public const int WorldRows = 25;
    public const int WorldCols = 40;
    private const int ThreadSleep = 100;
    private const int EnemiesChance = 9;
    private const int FuelChance = 1;
    private const int LifeChance = 2;
    public const int RacketDamage = 8;
    public const int LifeSupport = 50;
    public const int FuelBonus = 100;
    public const int ShootTimeout = 5;
    #endregion

    #region StatsMenuOffset
    public static int rowsOffset = 3;
    #endregion

    #region VisualObjects

    public static char[,] ShipBody;

    public static char[,] RacketBody =
    {
      {'\\','*','*','/'},
      {' ','|','|',' '},
      {' ','|','|',' '},
      {' ','\\','/',' '}
    };

    public static char[,] FuelBody =
    {
       {'/','-','-','\\'},
       {'|','F','U','|'},
       {'|','E','L','|'},
       {'\\','-','-','/'}
    };

    public static char[,] LifeBody =
    {
       {'/','*','*','\\'},
       {'|','L','I','|'},
       {'|','F','E','|'},
       {'\\','*','*','/'}
    };

    #endregion

    private static readonly Random RandGen = new Random();

    static public List<GameObject> RuntimeCreatedObjects()
    {
        var newObjects = new List<GameObject>();

        if ( RandGen.Next(100) < EnemiesChance )
            newObjects.Add(new Racket(new MatrixCoords(0, RandGen.Next(WorldCols-RacketBody.GetLength(1)*2) + RacketBody.GetLength(1)), RacketBody, new MatrixCoords(RandGen.Next(2) + 1, 0)));

        if ( RandGen.Next(100) < FuelChance )
            newObjects.Add(new Fuel(new MatrixCoords(0, RandGen.Next(WorldCols) - FuelBody.GetLength(1) +1), FuelBody, new MatrixCoords(1, 0)));

        if ( RandGen.Next(100) < LifeChance )
            newObjects.Add(new Life(new MatrixCoords(0, RandGen.Next(WorldCols) - LifeBody.GetLength(1)+1), LifeBody, new MatrixCoords(1, 0)));

        if ( RandGen.Next(100) < 20 )
            newObjects.Add(new Star(new MatrixCoords(WorldRows, RandGen.Next(WorldCols) - 1), new char[,] { { '.' } }, new MatrixCoords(-1, 0)));

        return newObjects;
    }

    private static void Main()
    {
        IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols, rowsOffset);
        IUserInterface keyboard = new KeyboardInterface();

        try
        {
            ResetBuffer();
            MainMenu.StartMainMenu();
            var gameEngine = new Engine(renderer, keyboard);
            KeyboardBind(keyboard, gameEngine);
            gameEngine.Run(ThreadSleep);
        }
        catch ( ArgumentException ex )
        {
            Console.WriteLine(ex.Message);
        }
        catch ( Exception ex )
        {
            Console.WriteLine(ex.Message);
        }

    }

    #region ConsoleSettings
    private static void ResetBuffer()
    {
        if ( Console.LargestWindowHeight >= WorldRows && Console.LargestWindowWidth >= WorldCols )
        {
            Console.WindowWidth = WorldCols;
            Console.WindowHeight = WorldRows * 2 + rowsOffset;

            Console.BufferWidth = WorldCols;
            Console.BufferHeight = WorldRows * 2 + rowsOffset;

            Console.CursorVisible = false;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Invalid world size!");
        }
    }

    private static void KeyboardBind(IUserInterface keyboard, Engine gameEngine)
    {
        keyboard.OnLeftPressed += (sender, eventInfo) => gameEngine.MovePlayerShipLeft();

        keyboard.OnRightPressed += (sender, eventInfo) => gameEngine.MovePlayerShipRight();

        keyboard.OnDownPressed += (sender, eventInfo) => gameEngine.MovePlayerShipDown();

        keyboard.OnUpPressed += (sender, eventInfo) => gameEngine.MovePlayerShipUp();

        keyboard.OnActionPressed += (sender, eventInfo) => gameEngine.PlayerShipAction(gameEngine);

        Ship theShip = new Ship(new MatrixCoords(WorldRows-ShipBody.GetLength(0)*2, ( WorldCols - ShipBody.GetLength(1) ) / 2), ShipBody);
        gameEngine.AddObject(theShip);
    }
    #endregion
}