using System;

class PrintMatrixVarious
{
    static void Main()
    {
        int matrixSize = InputSize();
        int[,] matrix = new int[matrixSize, matrixSize];

        Columwise(matrixSize, matrix);
        SerpentColumwise(matrixSize, matrix);
        Diagonalwise(matrixSize, matrix);
        Spiralwise(matrixSize, matrix);

    }

    private static void Spiralwise(int matrixSize, int[,] matrix)
    {
        int counter = 1;
        for ( int i = 0; i < matrixSize / 2 + 1; i++ )
        {
            //down
            for ( int row = i; row < matrix.GetLength(0) - i; row++ )
            {
                matrix[row, i] = counter++;
            }
            //right
            for ( int col = i + 1; col < matrix.GetLength(1) - i; col++ )
            {
                matrix[matrix.GetLength(0) - i - 1, col] = counter++;
            }
            //up
            for ( int row = matrix.GetLength(0) - i - 2; row >= i; row-- )
            {
                matrix[row, matrix.GetLength(1) - i - 1] = counter++;
            }
            //left
            for ( int col = matrix.GetLength(1) - i - 2; col > i; col-- )
            {
                matrix[i, col] = counter++;
            }
        }
        PrintMatrix(matrix);
    }

    private static void SerpentColumwise(int matrixSize, int[,] matrix)
    {
        for ( int i = 0; i < matrixSize * matrixSize; i++ )
        {
            int row = ( ( i / matrixSize ) % 2 == 1 ) ?
                matrixSize - 1 - ( i % matrixSize ) : i % matrixSize;
            int col = i / matrixSize;
            matrix[row, col] = i + 1;
        }
        PrintMatrix(matrix);
    }

    private static void Columwise(int matrixSize, int[,] matrix)
    {
        //By colums
        for ( int i = 0; i < matrixSize * matrixSize; i++ )
        {
            matrix[i % matrixSize, i / matrixSize] = i + 1;
        }
        PrintMatrix(matrix);
    }

    private static void Diagonalwise(int matrixSize, int[,] matrix)
    {
        //Diaglonalwise
        int counter = 1;
        for ( int row = matrix.GetLength(0) - 1; row >= 0; row-- )
        {
            for ( int col = 0; col + row < matrixSize; col++ )
            {
                matrix[row + col, col] = counter++;
            }
        }
        for ( int col = 1; col < matrix.GetLength(1); col++ )
        {
            for ( int row = 0; row + col < matrixSize; row++ )
            {
                matrix[row, col + row] = counter++;
            }
        }
        PrintMatrix(matrix);
    }

    private static int InputSize()
    {
        int matrixSize;
        do
        {
            Console.Write("Enter matrix size: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out matrixSize) );
        return matrixSize;
    }

    private static void PrintMatrix(int[,] matrix)
    {
        int maxChars = matrix[matrix.GetLength(0) - 2, matrix.GetLength(1) - 1].ToString().Length + 1;

        for ( int row = 0; row < matrix.GetLength(0); row++ )
        {
            for ( int col = 0; col < matrix.GetLength(1); col++ )
            {
                Console.Write(( matrix[row, col] + " " ).PadLeft(maxChars, ' '));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
