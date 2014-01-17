using System;

class AngryBits
{
    static int[] field = new int[8];

    static void Main()
    {
        int fieldRows = 8;
        int fieldCols = 16;
        int pigsCols = 8;

        for ( int i = 0; i < fieldRows; i++ )
        {
            field[i] = int.Parse(Console.ReadLine());
        }

        int scores = 0;
        #region gameEngine
        for ( int curCol = fieldCols - pigsCols; curCol < fieldCols; curCol++ )
        {
            for ( int curRow = 0; curRow < field.Length; curRow++ )
            {
                if ( BitAtPosition(field[curRow], curCol) == 1 ) //Birdie found
                {
                    int flyPath = 0;
                    int birdCol = curCol;
                    int birdRow = curRow;
                    int flyDirection = -1;
                    #region BirdFlyDiagonally
                    while ( true )
                    {
                        if ( birdRow == 0 )
                        {
                            flyDirection = -flyDirection;
                        }
                        birdCol--;
                        birdRow += flyDirection;
                        flyPath++;
                        if ( BitAtPosition(field[birdRow], birdCol) == 1 ) //Bird hits fatty pig
                        {
                            int pigsDestroyed = findPigsAroundAndDestroy(birdRow, birdCol);
                            scores += pigsDestroyed * flyPath;
                            field[curRow] = SetBitAtPositionToZero(field[curRow], curCol);
                            break;
                        }
                        else if ( birdCol == 0 )
                        {
                            field[curRow] = SetBitAtPositionToZero(field[curRow], curCol);
                            break;
                        }
                        else if (birdRow == field.Length-1)
                        {
                            flyDirection = -flyDirection;
                        }

                    }
                    #endregion
                }
            }
        }
        #endregion
        #region search Alive pigs
        bool isPigsDead = true;
        for ( int curRow = 0; curRow < fieldRows; curRow++ )
        {
            for ( int curCol = 0; curCol < fieldCols; curCol++ )
            {
                if ( BitAtPosition(field[curRow], curCol) == 1 )
                    isPigsDead = false;
            }
        }
        Console.Write(scores);
        Console.WriteLine(isPigsDead ? " Yes" : " No");
        #endregion
    }

    private static int findPigsAroundAndDestroy(int birdRow, int birdCol)
    {
        //count and remove pigs
        int pigsFound = 0;
        for ( int i = birdRow - 1; i <= birdRow + 1; i++ )
        {
            if ( i == 8 || i == -1 )
                continue;
            for ( int j = birdCol - 1; j <= birdCol + 1; j++ )
            {
                if ( j == -1 || j == 8 )
                    continue;
                if ( BitAtPosition(field[i], j) == 1 )
                {
                    pigsFound++;
                    field[i]=SetBitAtPositionToZero(field[i], j);
                }
            }
        }
        return pigsFound;
    }

    static int BitAtPosition(int value, int position)
    {
        int mask = 1 << position;
        mask = value & mask;
        mask >>= position;
        return mask;
    }

    static int SetBitAtPositionToZero(int value, int position)
    {
        return value & ~( 1 << position );
    }
}
