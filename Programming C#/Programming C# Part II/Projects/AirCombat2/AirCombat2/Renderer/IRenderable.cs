using System;

public interface IRenderable // this interface defines methods which will afterwards be overridden.
{
    MatrixCoords GetTopLeft();

    char[,] GetImage();
}
