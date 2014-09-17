namespace Portals
{
    using System;
    using System.Linq;

    internal class Solution
    {
        private static int[,] matrix;

        private static int maxPowers;

        private static void Main()
        {
            int[] startPos = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] cubeSize = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int curRow = startPos[0];
            int curCol = startPos[1];
            int rows = cubeSize[0];
            int cols = cubeSize[1];

            matrix = new int[rows, cols];

            ReadCube(rows, cols);

            Solve(curRow, curCol, 0);
            Console.WriteLine(maxPowers);
        }

        private static void Solve(int curRow, int curCol, int curSum)
        {
            if (matrix[curRow, curCol] == -1)
            {
                return;
            }

            if (matrix[curRow, curCol] > -1)
            {
                if (curSum > maxPowers)
                {
                    maxPowers = curSum;
                }
                if (matrix[curRow, curCol] == 0)
                    return;
            }

            int powerValue = matrix[curRow, curCol];
            curSum += powerValue;
            matrix[curRow, curCol] = 0;
            if (IsInBoundaries(curRow + powerValue, curCol))
            {
                Solve(curRow + powerValue, curCol, curSum);
            }

            if (IsInBoundaries(curRow - powerValue, curCol))
            {
                Solve(curRow - powerValue, curCol, curSum);
            }

            if (IsInBoundaries(curRow, curCol + powerValue))
            {
                Solve(curRow, curCol + powerValue, curSum);
            }

            if (IsInBoundaries(curRow, curCol - powerValue))
            {
                Solve(curRow, curCol - powerValue, curSum);
            }

            matrix[curRow, curCol] = powerValue;
        }

        private static bool IsInBoundaries(int curRow, int curCol)
        {
            return curRow >= 0 && curRow < matrix.GetLength(0) && curCol >= 0 && curCol < matrix.GetLength(1)
                   && matrix[curRow, curCol] != -1;
        }

        private static void ReadCube(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    if (line[2 * col] == '#')
                    {
                        matrix[row, col] = -1;
                    }
                    else
                    {
                        matrix[row, col] = line[2 * col] - '0';
                    }
                }
            }
        }
    }
}