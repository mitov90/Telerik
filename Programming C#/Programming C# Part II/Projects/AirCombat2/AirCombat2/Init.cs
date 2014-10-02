using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;


public class Init
{
    public static Dictionary<string, int> Parameters = new Dictionary<string, int>(); 
    public static List<char[,]> Enemies=new List<char[,]>();
    public static List<char[,]> Friends = new List<char[,]>();
    public static List<string> FriendNames=new List<string>();
    public static char[,] Ship;
    public static char[,] Shoot;

    public static int[] ReadMatrixSize(string [] line)
    {
        var prop = new int[2];
        prop[0] = int.Parse(line[Array.IndexOf(line, "height") + 1]);
        prop[1] = int.Parse(line[Array.IndexOf(line, "width") + 1]);
        return prop;
    }
    public static string ReadMatrixName(string [] line)
    {
        var name = (line[Array.IndexOf(line, "name") + 1]);
        return name;
    }
    public static void ReadInitFile()
    {
        string[] listOfBlocks = { "ship", "enemie", "friend", "shoot", "titlePicture" };
        var separators = new[] { " ", "=", ";" ,"/"};
        Parameters.Clear();
        string endOfInit = "";
        const string inputFilePath = "../../AirCombatInit.txt";

        try
        {
            var iniFileRead = new StreamReader(inputFilePath);
            using (iniFileRead)
            {
                string startInit = iniFileRead.ReadLine();
                if (startInit != "initAircombat")
                {
                    throw new Exception("Initialisation file wrong start format.");
                }

                while (endOfInit != "endOfInit" && endOfInit!=null)
                {
                    string currentRow = iniFileRead.ReadLine();
                    if (currentRow == null) continue;
                    string[] parametersAsStrings = currentRow.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    //foreach (var value in parametersAsStrings) Console.WriteLine("{0} , {1}",parametersAsStrings);
                    
                    bool isBlock = false;
                    foreach (var item in listOfBlocks.Where(item => parametersAsStrings[0] == item))
                    {
                        isBlock = true;
                        //here add to list of char[,] - enemies or friends after reading properties line
                        int[] size;
                        switch (parametersAsStrings[0])
                        {
                            case "enemie":
                            {
                                //color here??? == line[Array.IndexOf(line, "color") + 1]
                                size=ReadMatrixSize(parametersAsStrings);
                                var matrix = new char[size[0], size[1]];
                                for (int x = 0; x < size[0]; x++)
                                {
                                    string line = iniFileRead.ReadLine();
                                    for (int y = 0; y < size[1]; y++)
                                        if (line != null) matrix[x, y] = line[y];
                                }
                                Enemies.Add(matrix);
                                break;
                            }
                            case "friend":
                            {
                                string friendName=ReadMatrixName(parametersAsStrings);
                                FriendNames.Add(friendName); // to find by name in initialisation of objects in Main(), including startup screen and end of game screen
                                size = ReadMatrixSize(parametersAsStrings);
                                var matrix = new char[size[0], size[1]];
                                for (int x = 0; x < size[0]; x++)
                                {
                                    string line = iniFileRead.ReadLine();
                                    for (int y = 0; y < size[1]; y++)
                                        if (line != null) matrix[x, y] = line[y];
                                }
                                Friends.Add(matrix);
                                break;
                            }
                            case "ship":
                            {
                                size = ReadMatrixSize(parametersAsStrings);
                                Ship = new char[size[0], size[1]];
                                for (int x = 0; x < size[0]; x++)
                                {
                                    string line = iniFileRead.ReadLine();
                                    for (int y = 0; y < size[1]; y++)
                                        if (line != null) Ship[x, y] = line[y];
                                }
                                //StartGame.ShipBody = Ship;
                                break;
                            }
                            case "shoot":
                            {
                                size = ReadMatrixSize(parametersAsStrings);
                                Shoot = new char[size[0], size[1]];
                                for (int x = 0; x < size[0]; x++)
                                {
                                    string line = iniFileRead.ReadLine();
                                    for (int y = 0; y < size[1]; y++)
                                    {
                                        Debug.Assert(line != null, "line != null");
                                        Shoot[x, y] = line[y];
                                    }
                                }
                                break;
                            }
                        }
                    }
                    endOfInit = parametersAsStrings[0]; // check for end of initialisation
                    if (endOfInit != "endOfInit" && !isBlock)
                    {
                        // add to dictionary all variables from ini file
                        Parameters.Add(parametersAsStrings[0], int.Parse(parametersAsStrings[1])); 
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("AirCombatInit.txt is missing.");//or other exeption action
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("AirCombatInit.txt is empty");//or other exeption action
        }
        catch (Exception e)
        {
            Console.WriteLine("Problems with reading from file AirCombatInit.txt - {0}", e.Message);//or other exeption action
        }
    }
}