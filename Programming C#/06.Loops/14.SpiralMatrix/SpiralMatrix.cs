using System;

class SpiralMatrix
{
    static void Main()
    {
        byte matrixSize = InputValue();
        int[,] matrix = new int[matrixSize, matrixSize];

        //PopulateMatrix(matrix);
        matrix = PopulateMatrixV2(matrixSize);

        PrintMatrix(matrix);

    }

    static int[,] PopulateMatrixV2(int n)
    {
        int[,] result = new int[n, n];

        int pos = 0;
        int count = n;
        int value = -n;
        int sum = -1;

        do
        {
            value = -1 * value / n;
            for ( int i = 0; i < count; i++ )
            {
                sum += value;
                result[sum / n, sum % n] = pos++;
            }
            value *= n;
            count--;
            for ( int i = 0; i < count; i++ )
            {
                sum += value;
                result[sum / n, sum % n] = pos++;
            }
        } while ( count > 0 );

        return result;
    }
    private static int PopulateMatrix(int[,] matrix)
    {
        int counter = 0;

        for ( int i = 0; i < matrix.GetLength(0) / 2 + 1; i++ )
        {
            //top
            for ( int j = i; j < matrix.GetLength(1) - i; j++ )
            {
                matrix[i, j] = counter++;
            }
            //right
            for ( int j = i + 1; j < matrix.GetLength(0) - i; j++ )
            {
                matrix[j, matrix.GetLength(0) - i - 1] = counter++;
            }
            //bottom
            for ( int j = matrix.GetLength(0) - i - 2; j > i; j-- )
            {
                matrix[matrix.GetLength(1) - i - 1, j] = counter++;
            }
            //left
            for ( int j = matrix.GetLength(0) - i - 1; j > i; j-- )
            {
                matrix[j, i] = counter++;
            }
        }
        return counter;
    }

    private static void PrintMatrix(int[,] matrix)
    {
        int n = ( matrix.GetLength(0) * matrix.GetLength(1) - 1 ).ToString().Length + 1;
        for ( int i = 0; i < matrix.GetLength(0); i++ )
        {
            for ( int j = 0; j < matrix.GetLength(1); j++ )
            {
                Console.Write(matrix[i, j].ToString().PadLeft(n, ' '));
            }
            Console.WriteLine();
        }
    }

    private static byte InputValue()
    {
        byte matrixSize;
        do
        {
            Console.Write("Enter matrix size: ");
        }
        while ( !byte.TryParse(Console.ReadLine(), out matrixSize) );
        return matrixSize;
    }
}
