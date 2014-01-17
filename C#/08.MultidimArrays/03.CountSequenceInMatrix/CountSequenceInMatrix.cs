using System;

class CountSequenceInMatrix
{
    static void Main()
    {
        string[,] matrix = InputMatrix();
        string tempWord = null;
        string freqWord = null;
        int maxCount = 0;

        Diagonalwise(matrix, ref tempWord, ref maxCount, ref freqWord);
        Linewise(matrix, ref tempWord, ref freqWord, ref maxCount);
        Columwise(matrix, ref tempWord, ref freqWord, ref maxCount);

        Console.WriteLine(freqWord.ToString() + " -> " + maxCount);

    }

    private static void Linewise(string[,] matrix, ref string tempWord, ref string freqWord, ref int maxCount)
    {
        //Line
        for ( var row = 0; row < matrix.GetLength(0); row++ )
        {
            var tempCount = 0;
            tempWord = null;
            for ( var col = 0; col < matrix.GetLength(1); col++ )
            {
                if ( tempWord == matrix[row, col] )
                    tempCount++;
                else
                {
                    tempWord = matrix[row, col];
                    tempCount = 1;
                }
                if (tempCount <= maxCount) continue;
                maxCount = tempCount;
                freqWord = tempWord;
            }
        }
    }

    private static void Columwise(string[,] matrix, ref string tempWord, ref string freqWord, ref int maxCount)
    {
        //Columwise
        for ( int col = 0; col < matrix.GetLength(1); col++ )
        {
            int tempCount = 0;
            tempWord = null;
            for ( int row = 0; row < matrix.GetLength(0); row++ )
            {
                if ( tempWord == matrix[row, col] )
                    tempCount++;
                else
                {
                    tempWord = matrix[row, col];
                    tempCount = 1;
                }
                if ( tempCount > maxCount )
                {
                    freqWord = tempWord;
                    maxCount = tempCount;
                }
            }
        }
    }

    private static void Diagonalwise(string[,] matrix, ref string tempWord, ref int maxCount, ref string freqWord)
    {
        //Diagonalwise -> row
        for ( int row = matrix.GetLength(0); row >= 0; row-- )
        {
            int tempCount = 0;
            tempWord = null;
            for ( int col = 0; col + row < Math.Min(matrix.GetLength(0), matrix.GetLength(1)); col++ )
            {
                if ( matrix[row + col, col] == tempWord )
                    tempCount++;
                else
                {
                    tempWord = matrix[row + col, col];
                    tempCount = 1;
                }
                if ( tempCount > maxCount )
                {
                    maxCount = tempCount;
                    freqWord = tempWord;
                }
            }
        }

        for ( int col = 1; col < matrix.GetLength(1); col++ )
        {
            int tempCount = 0;
            tempWord = null;
            for ( int row = 0; row + col < Math.Min(matrix.GetLength(1), matrix.GetLength(0)); row++ )
            {
                if ( matrix[row, col + row] == tempWord )
                    tempCount++;
                else
                {
                    tempWord = matrix[row, col + row];
                    tempCount = 1;
                }
                if ( tempCount > maxCount )
                {
                    maxCount = tempCount;
                    freqWord = tempWord;
                }
            }
        }
    }

    private static string[,] InputMatrix()
    {
        int row;
        int col;

        do
        {
            Console.Write("Enter number of rows: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out row) );
        do
        {
            Console.Write("Enter number of cols: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out col) );

        string[,] matrix = new string[row, col];

        for ( int i = 0; i < row; i++ )
        {
            for ( int j = 0; j < col; j++ )
            {

                Console.Write("Enter row: {0}, col: {1} -> ", i + 1, j + 1);
                matrix[i, j] = Console.ReadLine();
            }
        }
        return matrix;
    }
}
