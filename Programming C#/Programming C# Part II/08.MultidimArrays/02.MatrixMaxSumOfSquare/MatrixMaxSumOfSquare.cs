using System;

class MatrixMaxSumOfSquare
{
    static void Main()
    {
        const int SquareSize = 3;

        int[,] matrix = InputMatrix(SquareSize);

        int maxSum = int.MinValue;
        for ( int row = 0; row <= matrix.GetLength(0)-SquareSize; row++ )
        {
            for ( int col = 0; col <= matrix.GetLength(1)-SquareSize; col++ )
            {
               int tempSum = matrix[row, col] +
                         matrix[row + 1, col] +
                         matrix[row + 2, col] +
                         matrix[row, col + 1] +
                         matrix[row + 1, col + 1] +
                         matrix[row + 2, col + 1] +
                         matrix[row, col + 2] +
                         matrix[row + 1, col + 2] +
                         matrix[row + 2, col + 2];

                if ( tempSum > maxSum )
                    maxSum = tempSum;
            }
        }
        Console.WriteLine(maxSum);
       
    }

    private static int[,] InputMatrix(int squareSize)
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

        if ( col < squareSize || row < squareSize )
        {
            Console.WriteLine("Matrix does not have at least {0} rows or cols!", squareSize);
            Environment.Exit(0);
        }

        int[,] matrix = new int[row, col];

        for ( int i = 0; i < row; i++ )
        {
            for ( int j = 0; j < col; j++ )
            {
                do
                {
                    Console.Write("Enter row: {0}, col: {1} -> ", i+1, j+1);
                }
                while ( !int.TryParse(Console.ReadLine(), out matrix[i, j]) );
            }
        }
        return matrix;
    }
}
