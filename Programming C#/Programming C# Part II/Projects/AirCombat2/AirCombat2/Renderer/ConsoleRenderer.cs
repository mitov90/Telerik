using System;
using System.Text;

public class ConsoleRenderer : IRenderer // the ConsoleRenderer class inherits the properties of the IRenderer interface.
{
    readonly int _renderContextMatrixRows; // the size of the console:
    readonly int _renderContextMatrixCols;
    readonly char[,] _renderContextMatrix;
    readonly int _menuOffset; // defines the current info board throughout the game process

    public ConsoleRenderer(int visibleConsoleRows, int visibleConsoleCols, int rowsOffset) // constructor - we create a new object of the ConsoleRenderer class
    {
        _renderContextMatrix = new char[visibleConsoleRows, visibleConsoleCols];

        this._renderContextMatrixRows = _renderContextMatrix.GetLength(0);
        this._renderContextMatrixCols = _renderContextMatrix.GetLength(1);
        this._menuOffset = rowsOffset;
        this.ClearQueue();
    }

    public void EnqueueForRendering(IRenderable obj) // this method adds an object for visualization.
    {
        char[,] objImage = obj.GetImage();

        int imageRows = objImage.GetLength(0);
        int imageCols = objImage.GetLength(1);

        MatrixCoords objTopLeft = obj.GetTopLeft(); // we extract the top left point from the object itself.

        int lastRow = Math.Min(objTopLeft.Row + imageRows, this._renderContextMatrixRows); // prevents us from getting out of the console.
        int lastCol = Math.Min(objTopLeft.Col + imageCols, this._renderContextMatrixCols); // prevents us from getting out of the console.

        for ( int row = obj.GetTopLeft().Row; row < lastRow; row++ )
        {
            for ( int col = obj.GetTopLeft().Col; col < lastCol; col++ )
            {
                if ( row >= 0 && row < _renderContextMatrixRows &&
                     col >= 0 && col < _renderContextMatrixCols )
                {
                    _renderContextMatrix[row, col] = objImage[row - obj.GetTopLeft().Row, col - obj.GetTopLeft().Col];
                }
            }
        }
    }

    public void RenderAll() // this method visualizes all objects currently on the console by converting all their symbols into a StringBuilder which is printed on the console.
    {
        var scene = new StringBuilder();

        for ( int row = 0; row < this._renderContextMatrixRows; row++ )
        {
            for ( int col = 0; col < this._renderContextMatrixCols; col++ )
            {
                scene.Append(this._renderContextMatrix[row, col]);
            }
            if (row != _renderContextMatrixRows - 1)
                scene.Append(Environment.NewLine);
        }

        scene.Append(Ship.GetDetail()); // the addition of the information board.

        Console.SetCursorPosition(0,0); // placing the cursor at the top left position of the console for printing the next scene.
        Console.Write(scene); // the final printing on the console.

    }

    public void ClearQueue() // clearing the matrix which includes all the symbols of all objects.
    {
        for ( int row = 0; row < this._renderContextMatrixRows; row++ )
        {
            for ( int col = 0; col < this._renderContextMatrixCols; col++ )
            {
                this._renderContextMatrix[row, col] = ' ';
            }
        }
    }
}