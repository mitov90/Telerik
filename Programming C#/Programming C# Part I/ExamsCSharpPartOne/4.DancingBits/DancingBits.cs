using System;
using System.Text;
class DancingBits
{
    static void Main(string[] args)
    {
        int k = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();
        int counter = 0;

        for ( int i = 0; i < n; i++ )
        {
            sb.Append(Convert.ToString(int.Parse(Console.ReadLine()), 2));
        }

        char tempBit = sb[0];
        int tempLen = 0;

        for ( int i = 0; i < sb.Length; i++ ) //math
        {
            if ( sb[i] == tempBit )
            {
                tempLen++;
            }
            else
            {
                if ( tempLen == k )
                    counter++;
                tempLen = 1;
                tempBit = sb[i];
            }
        }
        if ( sb[sb.Length -1 ] == tempBit && tempLen == k )
            counter++;

        Console.WriteLine(counter);

    }
}
