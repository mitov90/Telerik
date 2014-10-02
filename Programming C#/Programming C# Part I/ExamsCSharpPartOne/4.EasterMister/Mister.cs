using System;
using System.Text;

class Mister
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        const char dot = '.';
        const char asterisk = '*';
        const char hash = '#';
        int numLines = int.Parse(Console.ReadLine());
        int height = 2 * numLines;
        int widht = 3 * numLines - 1;

        //top row
        int asteriskCount = numLines - 1;
        int leadingDots = numLines % 2 == 0 ? 
            ( widht - asteriskCount ) / 2 + 1 : 
            ( widht - asteriskCount ) / 2;


        sb.Append(dot, leadingDots);
        sb.Append(asterisk, asteriskCount);
        sb.Append(dot, leadingDots);
        sb.Append(Environment.NewLine);

        //middle rows
        asteriskCount += 2;

        int numMiddleRow = ( numLines - 2 ) / 2;
        for ( int i = 0; i < numMiddleRow; i++ )
        {
            if ( leadingDots - 2 < 1 )
                leadingDots = 1;
            else
                leadingDots -= 2;

            sb.Append(dot, leadingDots);
            sb.Append(asterisk);
            sb.Append(dot, asteriskCount);
            sb.Append(asterisk);
            sb.Append(dot, leadingDots);
            sb.Append(Environment.NewLine);
            asteriskCount += 4;
        }

        //over center rows
        for ( int i = 0; i < numMiddleRow; i++ )
        {
            sb.Append(dot);
            sb.Append(asterisk);
            sb.Append(dot, asteriskCount);
            sb.Append(asterisk);
            sb.Append(dot);
            sb.Append(Environment.NewLine);
        }

        //two center rows
        for ( int i = 0; i < 2; i++ )
        {
            sb.Append(dot);
            sb.Append(asterisk);

            #region hash line
            for ( int j = 1; j <= asteriskCount; j++ )
            {
                if ( i % 2 == 0 )
                {
                    if ( j % 2 == 1 )
                        sb.Append(dot);
                    else
                        sb.Append(hash);
                }
                else
                {
                    if ( j % 2 == 0 )
                        sb.Append(dot);
                    else
                        sb.Append(hash);
                }

            }
            #endregion

            sb.Append(asterisk);
            sb.Append(dot);
            sb.Append(Environment.NewLine);
        }

        //under center rows
        for ( int i = 0; i < numMiddleRow; i++ )
        {
            sb.Append(dot);
            sb.Append(asterisk);
            sb.Append(dot, asteriskCount);
            sb.Append(asterisk);
            sb.Append(dot);
            sb.Append(Environment.NewLine);
        }
        //middle rows
        leadingDots = 1;
        for ( int i = 0; i < numMiddleRow; i++ )
        {
            leadingDots += 2;
            asteriskCount -= 4;

            sb.Append(dot, leadingDots);
            sb.Append(asterisk);
            sb.Append(dot, asteriskCount);
            sb.Append(asterisk);
            sb.Append(dot, leadingDots);
            sb.Append(Environment.NewLine);
        }

        //bottom row
        asteriskCount = numLines - 1;
        leadingDots = numLines % 2 == 0 ? 
            ( widht - asteriskCount ) / 2 + 1 : 
            ( widht - asteriskCount ) / 2;

        asteriskCount = numLines - 1;
        sb.Append(dot, leadingDots);
        sb.Append(asterisk, asteriskCount);
        sb.Append(dot, leadingDots);
        sb.Append(Environment.NewLine);

        Console.WriteLine(sb);
    }
}

