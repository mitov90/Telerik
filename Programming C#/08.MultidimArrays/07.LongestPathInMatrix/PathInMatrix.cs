using System;
using System.Drawing;

public class PathInMatrix
{
    #region fields
    
    private int maxLenght;
    private int maxValue;
    private readonly int[,] matrix;
    private readonly bool[,] visited;
    private readonly Point[] neighbourDeltas = {
                                 new Point(-1,0),
                                 new Point(1,0),
                                 new Point(0,-1), 
                                 new Point(0,1)
                             };
    #endregion
    
    public PathInMatrix(int[,] matrix)
    {
        this.matrix = matrix.Clone() as int[,];
        visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
    }
    
    public int Rows
    {
        get
        {
            return matrix.GetLength(0);
        }
    }
    
    public int Cols
    {
        get
        {
            return matrix.GetLength(1);
        }
    }
    
    public int FindLongestPath()
    {
        for ( int row = 0; row < Rows; row++ )
        {
            for ( int col = 0; col < Cols; col++ )
            {
                if ( visited[row, col] )
                    continue;
                int tempLenght = 1;
                FindPath(matrix[row, col], row, col, ref tempLenght);
                if ( tempLenght < maxLenght )
                    continue;
                maxLenght = tempLenght;
                maxValue = matrix[row, col];
            }
        }
    
        return maxLenght;
    }
    
    private void FindPath(int value, int row, int col, ref int tempLenght)
    {
        visited[row, col] = true;
        
        foreach ( var neighbourDelta in neighbourDeltas )
        {
            int tempRow = row + neighbourDelta.X;
            int tempCol = col + neighbourDelta.Y;
            if ( IsPossibeToVisit(tempRow, tempCol) && matrix[tempRow, tempCol] == value )
            {
                FindPath(value, tempRow, tempCol, ref tempLenght);
                tempLenght++;
            }
        }
    }
    
    private bool IsPossibeToVisit(int row, int col)
    {
        if ( row < 0 || row >= Rows ||
             col < 0 || col >= Cols ||
             visited[row, col] == true )
            return false;
        return true;
    }
    
    private static void Main()
    {
        PathInMatrix myMatrix = new PathInMatrix(new int[,] {
                                                     { 1, 1, 1, 1 },
                                                     { 0, 0, 0, 1 },
                                                     { 1, 0, 1, 0 },
                                                     { 0, 1, 3, 1 },
                                                     { 0, 1, 2, 1 },
                                                 });
    
        Console.WriteLine("Maximum path: " + myMatrix.FindLongestPath());
    }
}