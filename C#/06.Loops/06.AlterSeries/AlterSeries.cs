using System;

class AlterSeries
{
    static void Main()
    {
        #region variables
        int numN;
        int numX;
        double result=1;
        double tempVal=1;
        #endregion
        InputValues(out numN, out numX);
        CalcResult(numN, numX, ref result, ref tempVal);
        Console.WriteLine("Sum: " + result);
    }

    private static void CalcResult(int numN, int numX, ref double result, ref double tempVal)
    {
        for ( int i = 1; i <= numN; i++ )
        {
            tempVal *= (double)i / numX;
            result += tempVal;
        }
    }

    private static void InputValues(out int numN, out int numX)
    {
        do
        {
            Console.Write("Enter number of loop (cals) N: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out numN) || numN < 0 );
        do
        {
            Console.Write("Enter number (1/X) X: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out numX) );
    }
}
