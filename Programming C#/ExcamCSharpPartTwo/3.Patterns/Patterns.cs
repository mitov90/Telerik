#region

using System;
using System.Linq;

#endregion

internal class Patterns
{
    private static void Main()
    {
        int[,] matrix;
        int dim = ReadInput(out matrix);

        long maxSum = long.MinValue;

        for (int row = 0; row <= dim - 3; row++)
        {
            for (int col = 0; col <= dim - 5; col++)
            {
                long tempSum = GetPatternSum(matrix, row, col);

                if (tempSum > maxSum)
                {
                    maxSum = tempSum;
                }
            }
        }

        PrintResult(maxSum, matrix);
    }

    private static int ReadInput(out int[,] matrix)
    {
        int dim = int.Parse(Console.ReadLine());
        matrix = new int[dim, dim];

        for (int row = 0; row < dim; row++)
        {
            int[] line = Console.ReadLine()
                                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            for (int number = 0; number < line.Length; number++)
            {
                matrix[row, number] = line[number];
            }
        }
        return dim;
    }

    private static void PrintResult(long maxSum, int[,] matrix)
    {
        if (maxSum == long.MinValue)
        {
            long diagonalResult = 0;

            for (int row = 0, col = 0; row < matrix.GetLength(0); row++,col++)
            {
                diagonalResult += matrix[row, col];
            }

            Console.WriteLine("NO " + diagonalResult);
        }
        else
        {
            Console.WriteLine("YES " + maxSum);
        }
    }

    private static long GetPatternSum(int[,] matrix, int row, int col)
    {
        long tempSum = matrix[row, col];
        int previous = matrix[row, col];

        for (int direction = 1, stop = 1; stop <= 3; direction *= -1,stop++)
        {
            for (int pos = 0; pos < 2; pos++)
            {
                if (direction < 0)
                    row++;
                else
                {
                    col++;
                }

                if (matrix[row, col] > previous)
                {
                    tempSum += matrix[row, col];
                    previous = matrix[row, col];
                }
                else
                {
                    return long.MinValue;
                }
            }
        }
        return tempSum;
    }
}
