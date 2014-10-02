namespace ShortestPathInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    internal class ShortestPath
    {
        private const int DirectionsCount = 4;

        private static readonly int[] DeltaRow = { -1, 0, 1, 0 };

        private static readonly int[] DeltaCol = { 0, 1, 0, -1 };

        private static void Main()
        {
            string[,] matrix =
                {
                    { "0", "0", "0", "x", "0", "x" }, 
                    { "0", "x", "0", "x", "0", "x" }, 
                    { "0", "*", "x", "0", "x", "0" },
                    { "0", "x", "0", "0", "0", "0" }, 
                    { "0", "0", "0", "x", "x", "0" }, 
                    { "0", "0", "0", "x", "0", "x" }
                };

            var startCell = new Cell(2, 1, 0);
            GetPathInMatrix(matrix, startCell);

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void GetPathInMatrix(string[,] matrix, Cell startCell)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            var queue = new Queue<Cell>();
            queue.Enqueue(startCell);

            while (true)
            {
                if (queue.Count == 0)
                {
                    break;
                }

                var curCell = queue.Dequeue();

                for (var i = 0; i < DirectionsCount; i++)
                {
                    var nextCell = new Cell(curCell.Row + DeltaRow[i], curCell.Col + DeltaCol[i], curCell.Level + 1);

                    if (ValidateBoundaries(nextCell, rows, cols) && matrix[nextCell.Row, nextCell.Col] == "0")
                    {
                        matrix[nextCell.Row, nextCell.Col] = nextCell.Level.ToString(CultureInfo.InvariantCulture);
                        queue.Enqueue(nextCell);
                    }
                }
            }
        }

        private static bool ValidateBoundaries(Cell cell, int row, int col)
        {
            return cell.Col >= 0 && cell.Row >= 0 && cell.Row < row && cell.Col < col;
        }
    }
}