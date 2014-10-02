using System;
using System.IO;

public class MainMenu
{
    public static int consoleWidth; // can be read from the file
    public static int consoleHeight; // can be read from the file
    public static int offsetWidth; // can be read from the file
    public static int offsetHeight; // can be read from the file

    public static int Menu()
    {

        int choice = 0;
        int lastI = 0;
        int selector = 0;
        bool selected = false;

        // these arrays must be passed to the menu strings via the file
        string[] titlePicture = new string[]
            {
                @"       #  ### ##       ",
                @"      # #  #  # #      ",
                @"      ###  #  ##       ",
                @"      # #  #  # #      ",
                @"      # # ### # #      ",
                @"                       ",
                @" ##  #  # # ##   #  ###",
                @"#   # # ### # # # #  # ",
                @"#   # # ### ##  ###  # ",
                @"#   # # # # # # # #  # ",
                @" ##  #  # # ##  # #  # ",
                @"                       ",
                @"                       ",
                @"  __|__                ",
                @"  \___/                ",
                @"   | |                 ",
                @"   | |                 ",
                @"  _|_|______________   ",
                @"          /|\          ",
                @"        */ | \*        ",
                @"        / -+- \        ",
                @"    ---o--(_)--o---    ",
                @"      /  0 ' 0  \      ",
                @"    */     |     \*    ",
                @"    /      |      \    ",
                @"  */       |       \*  "
            };
        //select from given options
        string[] titleSelection = new string[]
            {
                @"         START         ",
                @"         HELP          ",
                @"         EXIT          "
            };

        while ( selected != true )
        {
            // draw plane
            for ( int i = 0; i < titlePicture.GetLength(0); i++ )
            {
                Console.SetCursorPosition(consoleWidth / 2 - offsetWidth, consoleHeight / 2 - offsetHeight + i);
                Console.Write(titlePicture[i]);
                lastI = i + 2;
            }

            Console.WriteLine();

            // draw menu
            for ( int i = 0; i < titleSelection.GetLength(0); i++ )
            {
                if ( selector == i )
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.CursorVisible = false; // fixes cursor blinking
                Console.SetCursorPosition(consoleWidth / 2 - offsetWidth, consoleHeight / 2 - offsetHeight + i + lastI);
                Console.Write(titleSelection[i]);

                // fix possible bug with color
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }

            // check key
            while ( Console.KeyAvailable )
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                if ( Console.KeyAvailable )
                {
                    Console.ReadKey();
                }

                if ( pressedKey.Key == ConsoleKey.UpArrow )
                {
                    if ( selector > 0 )
                    {
                        selector--;
                    }
                }
                else if ( pressedKey.Key == ConsoleKey.DownArrow )
                {
                    if ( selector < 2 )
                    {
                        selector++;
                    }
                }
                else if ( pressedKey.Key == ConsoleKey.Enter )
                {
                    // assign selected choice
                    choice = selector;
                    selected = true;
                }
            }
        }

        return choice; // will return 1=start, 2=help, 3=exit, all must point to other methods for continuation of the process
    }

    public static void StartMainMenu()
    {
        
        switch ( Menu() )
        {
            case 0:
                Console.Clear();
                return;
            case 1:
                Console.Clear();
                try
                {
                    string pathFile = @"..\..\help.txt";
                    StreamReader reader = new StreamReader(pathFile);
                    using (reader)
                    {
                        string help = reader.ReadToEnd();
                        Console.WriteLine(help);
                    }

                }
                    //In there are missing files the game ends
                catch (FileNotFoundException fe)
                {
                    Console.WriteLine(fe.Message);
                    System.Environment.Exit(0);
                }
                catch (ArgumentException fe)
                {
                    Console.WriteLine(fe.Message);
                    System.Environment.Exit(0);
                }
                catch (DirectoryNotFoundException fe)
                {
                    Console.WriteLine(fe.Message);
                    System.Environment.Exit(0);
                }
                catch (IOException fe)
                {
                    Console.WriteLine(fe.Message);
                    System.Environment.Exit(0);
                }
                Console.ReadLine();
                Console.Clear();
                break;
            case 2:
                System.Environment.Exit(0);
                break;
            default:
                throw new ExecutionEngineException();
        }

    }
}
