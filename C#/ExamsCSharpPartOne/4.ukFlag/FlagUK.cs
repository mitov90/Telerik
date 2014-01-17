using System;
using System.Text;

class UKFlag
{
    static void Main()
    {
        int numLines = int.Parse(Console.ReadLine());
        char leftDash = '\\';
        char rightDash = '/';
        const char verticalDash = '|';
        const char horizontalDash = '-';
        const char asterisk = '*';
        const char dot = '.';
        int leadingDots = 0;
        int middleDots = ( numLines - 3 ) / 2;
        int direction = 1;
        StringBuilder sb = new StringBuilder();
        for ( int i = 0; i < numLines; i++ )
        {
            if (numLines/2==i)
            {
                sb.Append(horizontalDash, numLines / 2);
                sb.Append(asterisk);
                sb.Append(horizontalDash, numLines / 2);
                sb.Append(Environment.NewLine);
                direction = -1;
                leftDash = '/';
                rightDash = '\\';
                continue;
            }
            sb.Append(dot, leadingDots);
            sb.Append(leftDash);
            sb.Append(dot, middleDots);
            sb.Append(verticalDash);
            sb.Append(dot,middleDots);
            sb.Append(rightDash);
            sb.Append(dot,leadingDots);
            sb.Append(Environment.NewLine);
            if ( i != numLines / 2 - 1 )
            {
                leadingDots += direction;
                middleDots -= direction;
            }
        }
        

        Console.WriteLine(sb);
    }
}
