using System;
using System.Collections.Generic;
using System.Text;

class Quadronacci
{
    static void Main()
    {
        long first = long.Parse(Console.ReadLine());
        long second = long.Parse(Console.ReadLine());
        long third = long.Parse(Console.ReadLine());
        long fourth = long.Parse(Console.ReadLine());
        byte rows = byte.Parse(Console.ReadLine());
        byte cols = byte.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();

        long[] quadValues = new long[rows * cols + 1];
        quadValues[0] = first;
        quadValues[1] = second;
        quadValues[2] = third;
        quadValues[3] = fourth;
        long curValue = 0;

        for ( int curRow = 0; curRow < rows; curRow++ )
        {
            for ( int curCol = 0; curCol < cols; curCol++ )
            {
                int curNum = curRow * cols + curCol;
                
                if ( curNum == 0 )
                    curValue = first;
                else if ( curNum == 1 )
                    curValue = second;
                else if ( curNum == 2 )
                    curValue = third;
                else if ( curNum == 3 )
                    curValue = fourth;
                else
                {
                    curValue = first + second + third + fourth;
                    first = second;
                    second = third;
                    third = fourth;
                    fourth = curValue;
                }

                sb.Append(curValue);
                if ( curCol != cols - 1 )
                    sb.Append(' ');
            }
            if ( curRow != rows - 1 )
                sb.Append(Environment.NewLine);
        }
        Console.WriteLine(sb);
    }
}
