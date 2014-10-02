using System;

class ReverseBits
{
    static void Main(string[] args)
    {
        int numLines = int.Parse(Console.ReadLine());

        for ( int i = 0; i < numLines; i++ )
        {
            int value = int.Parse(Console.ReadLine());
            int valueNew = 0;

            while ( value > 0)
            {
                valueNew <<= 1;
                if ( ( value & 1 ) == 1 )
                    valueNew |= 1;
                value >>= 1;
            }

            Console.WriteLine(valueNew);
        }
    }
}
