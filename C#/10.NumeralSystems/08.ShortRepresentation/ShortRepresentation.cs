using System;
using System.Text;

class ShortRepresentation
{
    const byte BitsInByte = 8;
    static void Main()
    {
        short testNumber = 0x7FFF;
        
        int mask;
        int sizeShort = sizeof( short ) * BitsInByte;

        StringBuilder sb = new StringBuilder();
        for ( int i = sizeShort-1; i >= 0; i-- )
        {
            mask = 1 << i;
            sb.Append((testNumber & mask)>>i);
        }
        Console.WriteLine(sb);
    }
}
