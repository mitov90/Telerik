using System;
class TestMatrix
{
    private static void Main()
    {
        Matrix myMatrix = new Matrix(new int[,] { { 3, 4, 5 }, { 5, 6, 5 } });

        Console.WriteLine(myMatrix + myMatrix);

    }
}

