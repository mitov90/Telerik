using System;

public class MatrixCoords
{
    public int Row { get; set; } // we create a property to which we will add a value on a later stage.

    public int Col { get; set; }

    public MatrixCoords(int row, int col) // constructor (template) - we create initial values for the rows and the columns.
    {
        this.Row = row;
        this.Col = col;
    }

    public static MatrixCoords operator +(MatrixCoords a, MatrixCoords b) // this method sums the coordinates (x + x, y + y) of the respective object.
    {
        return new MatrixCoords(a.Row + b.Row, a.Col + b.Col);
    }

    public static MatrixCoords operator -(MatrixCoords a, MatrixCoords b) // this method extracts the coordinates (x - x, y - y) of the respective object.
    {
        return new MatrixCoords(a.Row - b.Row, a.Col - b.Col);
    }

    public override bool Equals(object obj) // this method returns an answer to the question whether two cordinates are equal.
    {
        MatrixCoords objAsMatrixCoords = obj as MatrixCoords;

        return objAsMatrixCoords.Row == this.Row && objAsMatrixCoords.Col == this.Col;
    }

    public override int GetHashCode() // this method is always written when the "Equals" boolean method exists.
    {
        return this.Row.GetHashCode() * 7 + this.Col;
    }
}
