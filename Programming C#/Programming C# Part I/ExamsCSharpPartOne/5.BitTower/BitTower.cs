using System;
using System.IO;
class BitTower
{
    static void Main()
    {
        if ( Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug") )
            Console.SetIn(new StreamReader("test.txt"));
        int enteredBits;
        int[,] tower = InputTower(out enteredBits);
        int aliveBits = enteredBits;
        int selectedRow = 0;

        while ( true )
        {
            string inputComand = Console.ReadLine();
            if ( inputComand == "end" )
                break;
            int commandRow = int.Parse(Console.ReadLine()); // see 8-commandRow
            int commandCol = int.Parse(Console.ReadLine()); // 8-commandCol
            
            switch ( inputComand )
            {
                case "select":
                    tower[commandRow, commandCol] = 0;
                    break;
                case "kill":
                    aliveBits = CommandKill(tower, aliveBits, commandRow, commandCol);
                    break;
                case "move":
                    aliveBits = CommandMove(tower, aliveBits, commandRow, commandCol);

                    break;
            }

        }
        Console.WriteLine(enteredBits);
        Console.WriteLine(aliveBits);
        int result = 0;
        for ( int i = 0; i < tower.GetLength(0); i++ )
        {
            int temp = 0;
            for ( int j = 0; j < tower.GetLength(1); j++ )
            {
                temp += tower[i, j] * (int)Math.Pow(2, 7 - j);
            }
            result += temp;
        }
        Console.WriteLine(result);
    }

    private static int CommandMove(int[,] tower, int aliveBits, int commandRow, int commandCol)
    {
        if ( commandCol < 0 || commandCol > 7 )
        {
            if ( commandRow > 3 )
                return aliveBits;
            else
                return aliveBits-1;
        }
        int resultMove = 0;
        if ( commandCol > 0 && tower[commandRow, commandCol - 1] == 1 )
            resultMove++;
        if ( commandCol < 7 && tower[commandRow, commandCol + 1] == 1 )
            resultMove++;
        if ( tower[commandRow, commandCol] == 1 )
            resultMove++;
        if ( resultMove == 0 )
            tower[commandRow, commandCol] = 1;
        else
            aliveBits--;
        return aliveBits;
    }

    private static int CommandKill(int[,] tower, int aliveBits, int commandRow, int commandCol)
    {
        if ( commandCol < 0 || commandCol>7)
        {
            return CommandMove(tower, aliveBits, commandRow, commandCol);
        }
        if ( tower[commandRow, commandCol] == 1 )
            aliveBits--;
        else
        {
            int result = 0;
            if ( commandCol > 0 && tower[commandRow, commandCol - 1] == 1 )
                result++;
            if ( commandCol < 7 && tower[commandRow, commandCol + 1] == 1 )
                result++;
            if ( result == 1 )
            {
                if ( commandCol < 7 && tower[commandRow, commandCol + 1] == 1 )
                {
                    tower[commandRow, commandCol + 1] = 0;
                    aliveBits--;
                    aliveBits--;
                }
                if ( commandCol > 0 && tower[commandRow, commandCol - 1] == 1 )
                {
                    tower[commandRow, commandCol - 1] = 0;
                    aliveBits--;
                    aliveBits--;
                }

            }
            else if ( result == 2 )
            {
                tower[commandRow, commandCol] = 0;
                aliveBits--;
            }
            else
            {
                tower[commandRow, commandCol] = 1;
            }
        }
        return aliveBits;
    }


    private static void PrintTower(int[,] tower)
    {
        for ( int i = 0; i < tower.GetLength(0); i++ )
        {
            for ( int j = 0; j < tower.GetLength(1); j++ )
            {
                Console.Write(tower[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    private static int[,] InputTower(out int enteredBits)
    {
        int[,] tower = new int[8, 8];
        enteredBits = 0;

        for ( int i = 0; i < 8; i++ )
        {
            int temp = int.Parse(Console.ReadLine());
            for ( int j = 0; j < 8; j++ )
            {
                int curBit = ( temp >> j ) & 1;
                if ( curBit == 1 )
                    enteredBits++;
                tower[i, 7 - j] = curBit;
            }
        }
        return tower;
    }
}