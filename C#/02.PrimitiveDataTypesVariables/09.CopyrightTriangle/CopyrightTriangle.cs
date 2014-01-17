using System;
using System.Text;
class CopyrightTriangle
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;

        string buildingBlock;
        const char block = '\u00a9';
        const char pad = ' ';
        int numLines = 3;

        for ( int i = 0; i < numLines; i++ )
        {
            buildingBlock = new string(block, 2 * i + 1);
            Console.WriteLine(buildingBlock.PadLeft(numLines+i, pad));
        }

    }
}
