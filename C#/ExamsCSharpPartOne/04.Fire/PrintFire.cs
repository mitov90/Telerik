using System;
using System.Text;

class PrintFire
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();
        char dot = '.';

        int leadEndDots = 0;
        int middleDots = 0;
        for ( int i = 0; i < size/2; i++ )
        {
            leadEndDots = size / 2 -1 -i ;
            middleDots = i*2;
            AddLineFire(sb, dot, leadEndDots, middleDots);
        }
        for ( int i = 0; i < size/4; i++ )
        {
            AddLineFire(sb, dot, leadEndDots, middleDots);
            leadEndDots++;

            middleDots -=  2;
        }
        sb.Append('-', size);
        sb.Append(Environment.NewLine);
        for ( int j = 0; j < size / 2; j++ )
        {
            sb.Append(dot, j);

            for ( int i = 0; i < size-j*2; i++ )
            {
                sb.Append(i >= ( (size-j*2) / 2 ) ? '/' : '\\');
            }
            sb.Append(dot, j);
            sb.Append(Environment.NewLine);
        }

        Console.WriteLine(sb);
    }

    private static void AddLineFire(StringBuilder sb, char dot, int leadEndDots, int middleDots)
    {
        sb.Append(dot, leadEndDots);
        sb.Append('#');
        sb.Append(dot, middleDots);
        sb.Append('#');
        sb.Append(dot, leadEndDots);
        sb.Append(Environment.NewLine);
    }
}

