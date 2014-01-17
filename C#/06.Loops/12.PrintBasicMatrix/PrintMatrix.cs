using System;
using System.Text;

class PrintMatrix
{
    static void Main()
    {
        byte matrixSize;
        StringBuilder sb = new StringBuilder();        
        
        matrixSize = InputValue();
        CreateMatrix(matrixSize, sb);

        Console.WriteLine("Matrix:");
        Console.WriteLine(sb);
    }

    private static void CreateMatrix(byte matrixSize, StringBuilder sb)
    {
        for ( int i = 1; i <= matrixSize; i++ )
        {
            for ( int j = 0; j < matrixSize; j++ )
            {
                sb.Append(( i + j ).ToString().PadLeft(3, ' '));
            }
            sb.Append(Environment.NewLine);
        }
    }

    private static byte InputValue()
    {
        byte matrixSize;
        do
        {
            Console.Write("Enter matrix size: ");
        }
        while ( !byte.TryParse(Console.ReadLine(), out matrixSize) || matrixSize > 20 );
        return matrixSize;
    }
}

