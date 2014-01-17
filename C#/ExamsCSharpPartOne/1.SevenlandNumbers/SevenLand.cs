using System;
using System.IO;
using System.Linq;
class Sevenland
{
    static void Main(string[] args)
    {
        if ( Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug") )
        {
            Console.SetIn(new StreamReader("test.txt"));
        }

        int input = int.Parse(Console.ReadLine());
        int valueDecimal = 0;
        ConvertFrom7To10(ref input, ref valueDecimal);

        valueDecimal += 1;
        int valueSepth = 0;
        for ( int i = 0; valueDecimal > 0; i++ )
        {
            valueSepth += valueDecimal % 7 * (int)Math.Pow(10,i);
            valueDecimal /= 7;
        }
        Console.WriteLine(valueSepth);

    }

    private static void ConvertFrom7To10(ref int input, ref int valueDecimal)
    {
        for ( int i = 0; input > 0; i++ )
        {
            valueDecimal += ( input % 10 ) * (int)Math.Pow(7, i);
            input /= 10;
        }
    }
}
