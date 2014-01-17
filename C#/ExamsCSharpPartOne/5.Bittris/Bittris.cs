using System;
using System.Numerics;
using System.Linq;

class Bittris
{
    static void Main()
    {
        BigInteger numParts = BigInteger.Parse(Console.ReadLine());
        BigInteger scores = 0;
        int rows = 3;
        byte[] field = new byte[rows + 1];
        for ( uint partNum = 0; partNum < numParts; partNum++ ) //takes part
        {
            uint part = uint.Parse(Console.ReadLine());
            uint partScore = CountBitsInInt(part);
            byte shape = (byte)part;
            bool isDown = false;

            for ( int row = rows; row >= 0; row-- ) // part fall down to rows
            {
                shape = ReadDirectionAndMove(shape, row);

                if ( ( row == 0 || ( field[row - 1] & shape ) != 0 ) && !isDown )
                {
                    field[row] |= shape;
                    isDown = true;
                    if ( field[row] == byte.MaxValue )
                    {
                        scores += partScore * 10;
                        for ( int j = row; j < rows; j++ )
                        {
                            field[row] = field[j + 1];
                        }
                        field[rows] = 0;
                    }
                    else
                        scores += partScore;
                }

                if ((field[rows]&byte.MaxValue)!=0)
                {
                    Console.WriteLine(scores);
                    Environment.Exit(0);
                }

            }//end part fall down

          //  PrintField(field);
        }
        Console.WriteLine(scores);
    }

    private static byte ReadDirectionAndMove(byte shape, int row)
    {
        if ( row != 0 )
        {
            string direction = Console.ReadLine();
            shape = MoveShape(shape, direction); //change place after shape ==;
        }
        return shape;
    }

    private static byte MoveShape(byte shape, string direction)
    {
        switch ( direction )
        {
            case "L":
                if ( ( shape & ( 1 << 7 ) ) == 0 )
                    shape = (byte)( (int)shape << 1 );
                break;
            case "R":
                if ( ( shape & 1 ) == 0 )
                    shape = (byte)( shape >> 1 );
                break;
        }
        return shape;
    }

    static void PrintField(byte[] field)
    {
        Console.WriteLine();
        for ( int row = field.Length - 1; row >= 0; row-- )
        {
            Console.WriteLine(Convert.ToString(field[row], 2).PadLeft(8, '0'));
        }
    }

    static uint CountBitsInInt(uint b)
    {
        uint count = (uint)Convert.ToString(b, 2).ToCharArray().Count(c => c == '1');

        return count;
    }
}
