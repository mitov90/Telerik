#region

using System;
using System.CodeDom;
using System.Collections.Generic;
using AirCombat2.GameLogic;

#endregion

public class StartGame
{
    #region GameSettings
    public static int WorldRows = 25; // the dimensions of the console.
    public static int WorldCols = 40;
    private static int ThreadSleep = 120; // delay
    private static int EnemiesChance = 9; // percentage
    private static int FuelChance = 1;
    private static int LifeChance = 2;
    public static int RacketDamage = 8; // the amount of damage/bonus caused.
    public static int LifeSupport = 50;
    public static int FuelBonus = 100;
    public static int ShootTimeout = 5; // the interval between two possible shootings = number of iterations.
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

    private static readonly Random RandGen = new Random(); // random generator.

    static public List<GameObject> RuntimeCreatedObjects() // creation of objects throughout a game.
    {
        var newObjects = new List<GameObject>();

        int racketIndex = RandGen.Next(Init.Enemies.Count);
        char[,] racketBody = Init.Enemies[racketIndex];

        if (RandGen.Next(100) < EnemiesChance) // torpedo
            newObjects.Add(new Racket(new MatrixCoords(0, RandGen.Next(WorldCols - RacketBody.GetLength(1) * 2) + RacketBody.GetLength(1) + 1), racketBody, new MatrixCoords(RandGen.Next(2) + 1, 0)));

        if (RandGen.Next(100) < FuelChance) // fuel
            newObjects.Add(new Fuel(new MatrixCoords(0, RandGen.Next(WorldCols) - FuelBody.GetLength(1) + 1), FuelBody, new MatrixCoords(1, 0)));

        if (RandGen.Next(100) < LifeChance) // life
            newObjects.Add(new Life(new MatrixCoords(0, RandGen.Next(WorldCols) - LifeBody.GetLength(1) + 1), LifeBody, new MatrixCoords(1, 0)));

        if (RandGen.Next(100) < 20) // star dust
            newObjects.Add(new Star(new MatrixCoords(WorldRows, RandGen.Next(WorldCols) - 1), new char[,] { { '.' } }, new MatrixCoords(-1, 0)));

        return newObjects;
    }

    private static void Main()
    {
        #region InitializeFromTextFile
        Init.ReadInitFile();
        MainMenu.consoleWidth = Init.Parameters["consoleWidth"];
        MainMenu.consoleHeight = Init.Parameters["consoleHeight"];
        MainMenu.offsetWidth = Init.Parameters["offsetWidth"];
        MainMenu.offsetHeight = Init.Parameters["offsetHeight"];
        WorldRows = Init.Parameters["WorldRows"];
        WorldCols = Init.Parameters["WorldCols"];
        ThreadSleep = Init.Parameters["ThreadSleep"];
        EnemiesChance = Init.Parameters["EnemiesChance"];
        FuelChance = Init.Parameters["FuelChance"];
        LifeChance = Init.Parameters["LifeChance"];
        RacketDamage = Init.Parameters["RacketDamage"];
        LifeSupport = Init.Parameters["LifeSupport"];
        FuelBonus = Init.Parameters["FuelBonus"];
        ShootTimeout = Init.Parameters["ShootTimeout"];
        ShipBody = Init.Ship;

        #endregion

        IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols, rowsOffset); // setting the dimensions of the scene for the printer to print on the console.
        IUserInterface keyboard = new KeyboardInterface(); // creation of an interface for using the keyboard.

        try
        {
            ResetBuffer();
            MainMenu.StartMainMenu(); // start the game
            var gameEngine = new Engine(renderer, keyboard);
            KeyboardBind(keyboard, gameEngine);
            gameEngine.Run(ThreadSleep);
        }
        catch (ArgumentException ex) // in case of wrong coordinates.
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    #region ConsoleSettings
    private static void ResetBuffer() // setting of the console dimensions
    {
        if (Console.LargestWindowHeight >= WorldRows && Console.LargestWindowWidth >= WorldCols)
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

    private static void KeyboardBind(IUserInterface keyboard, Engine gameEngine) // at each key pressing one of thefollowing methods is called. ...
    {
        keyboard.OnLeftPressed += (sender, eventInfo) => gameEngine.MovePlayerShipLeft();

        keyboard.OnRightPressed += (sender, eventInfo) => gameEngine.MovePlayerShipRight();

        keyboard.OnDownPressed += (sender, eventInfo) => gameEngine.MovePlayerShipDown();

        keyboard.OnUpPressed += (sender, eventInfo) => gameEngine.MovePlayerShipUp();

        keyboard.OnActionPressed += (sender, eventInfo) => gameEngine.PlayerShipAction(gameEngine);

        Ship theShip = new Ship(new MatrixCoords(WorldRows - ShipBody.GetLength(0) * 2, (WorldCols - ShipBody.GetLength(1)) / 2), ShipBody);
        gameEngine.AddObject(theShip);
    }
    #endregion
}