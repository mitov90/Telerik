using System;
using System.Numerics;

class CatalanNumber
{
    static void Main()
    {
        int catNum;
        BigInteger result =1;
        catNum = InputValue();
        result = CalcCatalanNum(catNum, result);
        Console.WriteLine("{0} catalan's number is: {1}",catNum, result);
    }

    private static BigInteger CalcCatalanNum(int catNum, BigInteger result)
    {
        if ( catNum == 2 )
            return 1;

        for ( int i = 0; i < catNum; i++ )
        {
            result = ( 2 * ( 2 * i + 1 ) * result ) / ( i + 2 );
        }

        return result;
    }

    private static int InputValue()
    {
        int catNum;
        do
        {
            Console.Write("Enter n>0 (catalan number): ");
        }
        while ( !int.TryParse(Console.ReadLine(), out catNum) || catNum < 0 );
        return catNum;
    }
}