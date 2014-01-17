using System;
using System.Text;

class TelerikLogo
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int lineLenght = 3 * x - 2;
        const char asterisk = '*';
        const char dot = '.';
        StringBuilder sb = new StringBuilder();
        int hornLenght = x / 2;
        int leadingDots = hornLenght - 1;
        int middleDots = lineLenght - ( 6 + 2 * leadingDots );

        // first line
        sb.Append(dot, hornLenght);
        sb.Append(asterisk);
        sb.Append(dot, middleDots + 2);
        sb.Append(asterisk);
        sb.Append(dot, hornLenght);
        sb.Append(Environment.NewLine);
        int middleHordMain = 0;
        //to end of hord
        for ( int i = 0; i < hornLenght; i++ )
        {
            middleHordMain = 2 * i + 1;
            sb.Append(dot, leadingDots);
            sb.Append(asterisk);
            sb.Append(dot, middleHordMain);
            sb.Append(asterisk);
            sb.Append(dot, middleDots);
            sb.Append(asterisk);
            sb.Append(dot, middleHordMain);
            sb.Append(asterisk);
            sb.Append(dot, leadingDots);
            sb.Append(Environment.NewLine);
            leadingDots--;
            middleDots -= 2;
        }
        int y = x;
        for ( int i = hornLenght; middleDots >= 1; middleDots -= 2 )
        {
            sb.Append(dot, x);
            sb.Append(asterisk);
            sb.Append(dot, middleDots);
            sb.Append(asterisk);
            sb.Append(dot, x);
            sb.Append(Environment.NewLine);
            x++;
        }
        sb.Append(dot, x);
        sb.Append(asterisk);
        sb.Append(dot, x);
        sb.Append(Environment.NewLine);

        //get some rombe
        int rombeMiddleDots=0;
        for ( int i = 0; i < y-1; i++ )
        {
            rombeMiddleDots = 2 * i+1;
            sb.Append(dot, lineLenght/2 -1 - i);
            sb.Append(asterisk);
            sb.Append(dot,rombeMiddleDots);
            sb.Append(asterisk);
            sb.Append(dot, lineLenght / 2 - 1 - i);
            sb.Append(Environment.NewLine);
            
        }
        for ( int i = 0; i < y-2; i++ )
        {
            rombeMiddleDots -= 2;
            sb.Append(dot, hornLenght+i+1);
            sb.Append(asterisk);
            sb.Append(dot, rombeMiddleDots);
            sb.Append(asterisk);
            sb.Append(dot, hornLenght + i+1);
            sb.Append(Environment.NewLine);

        }


        sb.Append(dot, x);
        sb.Append(asterisk);
        sb.Append(dot, x);
        sb.Append(Environment.NewLine);
        Console.WriteLine(sb);

    }
}