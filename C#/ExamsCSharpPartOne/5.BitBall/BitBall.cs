using System;

class BitBall
{
    static void Main()
    {
        const int fieldSize = 8;

        int topScores = 0;
        int bottomScores = 0;

        int[,] teamTop = new int[fieldSize, fieldSize];
        int[,] teamBottom = new int[fieldSize, fieldSize];

  

        GetOnTheField(fieldSize, teamTop, teamBottom);
        GetRedCard(fieldSize,ref teamTop,ref teamBottom);
        //for ( int i = 0; i < fieldSize; i++ )
        //{
        //    for ( int j = 0; j < fieldSize; j++ )
        //    {
        //        Console.Write(teamTop[i, j]);

        //    }
        //    Console.WriteLine();
        //}
        topScores = AttackDown(fieldSize, topScores, teamTop, teamBottom);
        bottomScores = AttackUp(fieldSize, bottomScores, teamTop, teamBottom);

        Console.WriteLine(topScores + ":" + bottomScores);

    }

    private static int AttackUp(int fieldSize, int bottomScores, int[,] teamTop, int[,] teamBottom)
    {
        for ( int curCol = 0; curCol < fieldSize; curCol++ )
        {
            bool goolCol = false;
            for ( int curRow = 0; curRow < fieldSize; curRow++ )
            {
                if ( teamBottom[curRow, curCol] == 1 )
                {
                    for ( int playerRow = curRow; playerRow >= 0; playerRow-- )
                    {
                        if ( teamTop[playerRow, curCol] == 1 )
                            break;
                        else if ( playerRow == 0 )
                        {
                            bottomScores++;
                            goolCol = true;
                        }
                    }
                    if (goolCol==true)
                    break;
                }
            }
        }
        return bottomScores;
    }

    private static int AttackDown(int fieldSize, int topScores, int[,] teamTop, int[,] teamBottom)
    {
        for ( int curCol = 0; curCol < fieldSize; curCol++ )
        {
            bool goolCol = false;
            for ( int curRow = 0; curRow < fieldSize; curRow++ )
            {
                if ( teamTop[curRow, curCol] == 1 )
                {
                    for ( int playerRow = curRow; playerRow < fieldSize; playerRow++ )
                    {
                        if ( teamBottom[playerRow, curCol] == 1 )
                            break;
                        else if ( playerRow == fieldSize - 1 )
                        {
                            goolCol = true;
                            topScores++;
                        }
                    }
                    if ( goolCol == true )
                        break;
                }

            }
        }
        return topScores;
    }

    private static void GetRedCard(int fieldSize,ref int[,] teamTop,ref int[,] teamBottom)
    {
        for ( int curRow = 0; curRow < fieldSize; curRow++ )
        {
            for ( int curCol = 0; curCol < fieldSize; curCol++ )
            {
                if ( teamTop[curRow, curCol] == 1 &&
                    teamBottom[curRow, curCol] == 1 )
                {
                    teamTop[curRow, curCol] = 0;
                    teamBottom[curRow, curCol] = 0;
                }
            }
        }
    }

    private static void GetOnTheField(int fieldSize, int[,] teamTop, int[,] teamBottom)
    {
        for ( int i = 0; i < 2 * fieldSize; i++ )
        {
            int inputRow = int.Parse(Console.ReadLine());

            for ( int curBit = 0; curBit < fieldSize; curBit++ )
            {
                if ( i < fieldSize )
                    teamTop[i, curBit] = 1 & ( inputRow >>  curBit );
                else
                    teamBottom[i % fieldSize, curBit] = 1 & ( inputRow >>  curBit  );
            }
        }
    }
}
