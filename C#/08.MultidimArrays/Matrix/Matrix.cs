using System;
using System.Text;

public class Matrix
{
    #region  fields and prop

    public int this[int row, int col]
    {
        get
        {
            if ( row <= Rows && col <= Cols )
                return data[row, col];
            else
                throw new MatrixException("Invalid rows,cols!");
        }
        set
        {
            if ( row <= Rows && col <= Cols )
                data[row, col] = value;
            else
            {
                throw new MatrixException("Invalid row,col!");
            }
        }
    }

    private readonly int[,] data;

    public int Rows { get; private set; }
    public int Cols { get; private set; }
    #endregion

    #region Constructors

    public Matrix(int rows, int cols)
    {
        Cols = cols;
        Rows = rows;
        data = new int[rows, cols];
    }

    public Matrix(int[,] array)
    {
        Rows = array.GetLength(0);
        Cols = array.GetLength(1);
        data = new int[Rows, Cols];
        data = array.Clone() as int[,];
    }
    #endregion

    #region operators
    static public Matrix operator +(Matrix first, Matrix second)
    {
        if (first.Cols!=second.Cols||first.Rows!=second.Rows)
            throw new MatrixException("Diffrent size matrices!");
        var resultMatrix = new Matrix(first.Rows,first.Cols);

        for (var row = 0; row < first.Rows; row++)
        {
            for (var col = 0; col < first.Cols; col++)
            {
                resultMatrix[row, col] = first[row, col] + second[row, col];
            }
        }

        return resultMatrix;
    }

    static public Matrix operator -(Matrix first, Matrix second)
    {
          if (first.Cols!=second.Cols||first.Rows!=second.Rows)
            throw new MatrixException("Diffrent size matrices!");
        var resultMatrix = new Matrix(first.Rows,first.Cols);
         for (var row = 0; row < first.Rows; row++)
        {
            for (var col = 0; col < first.Cols; col++)
            {
                resultMatrix[row, col] = first[row, col] - second[row, col];
            }
        }

        return resultMatrix;
    }

    static public Matrix operator *(Matrix first, Matrix second)
    {
        if (first.Rows != second.Cols)
            throw new MatrixException("Invalid row and col!");

        Matrix resultMatrix = new Matrix(first.Rows,second.Cols);
        for ( int row = 0; row < resultMatrix.Rows; row++ )
        {
            for ( int col = 0; col < resultMatrix.Cols; col++ )
            {
                resultMatrix[row,col]=0;
                for ( int i = 0; i < first.Cols; i++ )
                {
                    resultMatrix[row,col]+=first[row,i]*second[i,col];
                }
            }
        }

        return resultMatrix;
    }
    #endregion

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        for ( int row = 0; row < Rows; row++ )
        {
            sb.Append("{ ");
            for ( int col = 0; col < Cols; col++ )
            {
                sb.Append(data[row,col]+ " ");
            }
            sb.Append("}"+Environment.NewLine);
        }

        return sb.ToString();
    }
}
