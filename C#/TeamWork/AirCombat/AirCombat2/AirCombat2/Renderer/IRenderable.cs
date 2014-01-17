using System;

public interface IRenderable
{
    MatrixCoords GetTopLeft();

    char[,] GetImage();
}
