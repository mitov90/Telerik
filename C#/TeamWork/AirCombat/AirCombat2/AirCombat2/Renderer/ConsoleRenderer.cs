using System;
using System.Text;

public class ConsoleRenderer : IRenderer
{
    readonly int _renderContextMatrixRows;
    readonly int _renderContextMatrixCols;
    readonly char[,] _renderContextMatrix;
    readonly int _menuOffset;

    public ConsoleRenderer(int visibleConsoleRows, int visibleConsoleCols, int rowsOffset)
    {
        _renderContextMatrix = new char[visibleConsoleRows, visibleConsoleCols];

        this._renderContextMatrixRows = _renderContextMatrix.GetLength(0);
        this._renderContextMatrixCols = _renderContextMatrix.GetLength(1);
        this._menuOffset = rowsOffset;
        this.ClearQueue();
    }

    public void EnqueueForRendering(IRenderable obj)
    {
        char[,] objImage = obj.GetImage();

        int imageRows = objImage.GetLength(0);
        int imageCols = objImage.GetLength(1);

        MatrixCoords objTopLeft = obj.GetTopLeft();

        int lastRow = Math.Min(objTopLeft.Row + imageRows, this._renderContextMatrixRows);
        int lastCol = Math.Min(objTopLeft.Col + imageCols, this._renderContextMatrixCols);

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

    public void RenderAll()
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

        //Draw Menu
        scene.Append(Ship.GetDetail());

        //Print
        Console.SetCursorPosition(0,0);
        Console.Write(scene);

    }



    public void ClearQueue()
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