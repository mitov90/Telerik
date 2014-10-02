using System;
using System.Collections.Generic;
using System.IO;

class ReadMatrix
{
    static void Main()
    {
        int checkSize = 2;
        List<string[]> lines = new List<string[]>();
        int[,] matrix = null;
        ReadFile(lines);

        matrix = FillMatrix(lines, matrix);


        int sum = GetMaxSum(matrix, checkSize);
        Console.WriteLine(sum);

    }

    private static int GetMaxSum(int[,] matrix, int checkSize)
    {
        if ( matrix.GetLength(0) < checkSize || matrix.GetLength(1) < checkSize )
            throw new ArgumentException("Matrix size is smaller than square of check!");

        int sum = matrix[0, 0] + matrix[0, 1] + matrix[1, 0] + matrix[1, 1];

        for ( int curLine = 0; curLine < matrix.GetLength(0) - checkSize + 1; curLine++ )
        {
            for ( int curNumber = 0; curNumber < matrix.GetLength(1) - checkSize + 1; curNumber++ )
            {
                int tempSum = FindSquareSum(matrix, checkSize, curLine, curNumber);
                if ( tempSum > sum )
                {
                    sum = tempSum;
                }
            }
        }
        return sum;
    }

    private static int FindSquareSum(int[,] matrix, int checkSize, int curLine, int curNumber)
    {
        int tempSum = 0;
        for ( int row = 0; row < checkSize; row++ )
        {
            tempSum += matrix[curLine, curNumber + row];
            for ( int col = 1; col < checkSize; col++ )
            {
                tempSum += matrix[curLine + col, curNumber + row];
            }
        }
        return tempSum;
    }

    private static int[,] FillMatrix(List<string[]> lines, int[,] matrix)
    {
        if ( lines.Count > 0 )
        {
            matrix = new int[lines.Count, lines[0].GetLength(0)];

            for ( int curLine = 0; curLine < lines.Count; curLine++ )
            {
                for ( int curNumber = 0; curNumber < matrix.GetLength(1); curNumber++ )
                {
                    int tempNumber = int.Parse(lines[curLine][curNumber]);
                    matrix[curLine, curNumber] = tempNumber;
                }
            }

        }
        return matrix;
    }

    private static void ReadFile(List<string[]> lines)
    {
        using ( StreamReader sr = new StreamReader("matrix.txt") )
        {
            string line = sr.ReadLine();
            while ( line != null )
            {
                var tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                lines.Add(tokens);
                line = sr.ReadLine();
            }
        }
    }
}