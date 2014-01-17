using System;
using System.IO;

class BuildTrack
{
    static void Main()
    {
        //if ( Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug") )
        //    Console.SetIn(new StreamReader("test.txt"));

        const int trackSize = 8;
        int[,] track = new int[trackSize, trackSize];



        InputTrack(trackSize, track);
        //for ( int i = 0; i < trackSize; i++ )
        //{
        //    for ( int j = 0; j < trackSize; j++ )
        //    {
        //        Console.Write(track[i, j] + " ");
        //    }
        //    Console.WriteLine();
        //}
        string direction = "down";
        int curCol = trackSize-1;
        int curRow = 0;
        int counter = 0;
        int directionChange = 0;
        bool directionDown = true;
        int totalDirectionChange = 0;

        if (track[0,7]==1)
        {
            Console.WriteLine("No 0");
            Environment.Exit(0);
        }

        for ( int i = 0; !(curCol == 0 && curRow == trackSize-1) ; i++ ) //condition loop
        {
           
            if ( NextBitInDirection(direction, ref curRow, ref curCol, ref track) == 1 )
            {
                directionChange++;
                totalDirectionChange++;
                direction = ChangeDirection(direction, ref directionDown);
            }
            else
            {
                directionChange = 0;
                counter++;
            }
            if ( directionChange == 2 )
                break;
        }
        if ( curCol == 0 && curRow == trackSize - 1 )
            Console.WriteLine(counter + 1 + " " + totalDirectionChange);
        else
        {
            Console.Write("No " );
            Console.WriteLine(counter+1);
        }
    }

    private static string ChangeDirection(string direction, ref bool directionDown)
    {
        switch ( direction )
        {
            case "down":
                return "left";
            case "up":
                return "left";
            case "left":
                if ( directionDown )
                {
                    directionDown = false;
                    return "up";
                }
                else
                {
                    directionDown = true;
                    return "down";
                }
        }
        return "DEADBEEF";
    }

    private static void InputTrack(int trackSize, int[,] track)
    {
        for ( int i = 0; i < trackSize; i++ )
        {
            byte inputRow = byte.Parse(Console.ReadLine());

            for ( int curBit = 0; curBit < 8; curBit++ )
            {
                track[i, trackSize - 1 - curBit] = 1 & ( inputRow >> curBit );
            }
        }
    }

    private static int NextBitInDirection(string direciton, ref int curRow, ref int curCol, ref int[,] track)
    {
        switch ( direciton )
        {
            case "up":
                if ( curRow == 0 || track[curRow - 1, curCol] == 1 )
                    return 1;
                else
                {
                    curRow--;
                    return 0;
                }
            case "down":
                if ( curRow == track.GetLength(0) - 1 || track[curRow + 1, curCol] == 1 )
                    return 1;
                else
                {
                    curRow++;
                    return 0;
                }
            case "left":
                if ( curCol == 0 || track[curRow, curCol - 1] == 1 )
                    return 1;
                else
                {
                    curCol--;
                    return 0;
                }
        }
        return 0;
    }
}
