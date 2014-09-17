using System;
using System.Text;

class TribonacciTriangle
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        long first = long.Parse(Console.ReadLine());
        long second = long.Parse(Console.ReadLine());
        long third = long.Parse(Console.ReadLine());
        long result;
        int lines = int.Parse(Console.ReadLine());

        sb.Append(first);
        sb.Append(Environment.NewLine);
        sb.Append(second + " " + third);
        sb.Append(Environment.NewLine);

        for ( int line = 2; line < lines; line++ )
        {
            for ( int col = 0; col < line+1; col++ )
            {
                result = first + second + third;
                first = second;
                second = third;
                third = result;
                sb.Append(result+" ");
            }
            sb.Append(Environment.NewLine);
        }

        Console.WriteLine(sb);
    }
}
