using System;
using System.Text;

class Tower
{
    static void Main()
    {
        char leftSlash = '/';
        char rightSlash = '\\';
        char dot = '.';
        char dash = '-';
        int size = int.Parse(Console.ReadLine());
        int offset = 2;
        int dashLine = 1;
        StringBuilder sb = new StringBuilder();

        int leadEndDots = size - 1;
        int middleDots = 0;
        for ( int i = 0; i < size; i++ )
        {
            sb.Append(dot, leadEndDots);
            sb.Append(leftSlash);
            if (dashLine==i)
            {
                dashLine = dashLine + offset++;
                sb.Append(dash, middleDots);
            }
            else
            sb.Append(dot, middleDots);
            sb.Append(rightSlash);
            sb.Append(dot, leadEndDots);
            sb.Append(Environment.NewLine);
            leadEndDots -= 1;
            middleDots += 2;
        }

        Console.WriteLine(sb);
    }
}
