using System;
using System.Text;
using System.IO;

class Carpet
{
    static void Main()
    {
        //if ( Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug") )
        //    Console.SetIn(new StreamReader("test.txt"));
        const char dot = '.';
        const char space = ' ';
        char leftDash = '/';
        char rightDash = '\\';
        int size = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();
        for ( int i = 1; i <= size/2; i++ )
        {
            bool first = true;
            int j = i;
            char lastChar= leftDash;
            sb.Append(dot, size/2 - j );
            //print carpet
            for ( int k = 0; k < j; k++ )
            {
                if ( k % 2 == 0 || first)
                {
                    sb.Append(leftDash);
                    lastChar = leftDash;
                    first = false;
                }
                else
                {
                    sb.Append(space);
                    lastChar = space;
                }
            }
            if ( lastChar == leftDash )
                lastChar = rightDash;
               
            for ( int k = 0; k <j; k++ )
            {
                sb.Append(lastChar);
                if ( lastChar == space )
                    lastChar = rightDash;
                else
                    lastChar = space;
            }

            sb.Append(dot, size/2 - j );
            sb.Append(Environment.NewLine);
        }

        for ( int i = 0; i < size/2; i++ )
        {
            char lastChar=space;
            bool first = true;
            sb.Append(dot, i);

            for ( int j = 0; j < size/2 - i; j++ )
            {
                if ( first )
                {
                    sb.Append(rightDash);
                    lastChar = rightDash;
                    first = false;
                }
                else
                {
                    lastChar = space;
                    sb.Append(space);
                    first = true;
                }
            }
            if ( lastChar == rightDash )
                lastChar = leftDash;
            for ( int j = 0; j < size/2-i; j++ )
            {
                sb.Append(lastChar);

                if ( lastChar == space )
                    lastChar = leftDash;
                else
                    lastChar = space;
            }

            sb.Append(dot, i);
            sb.Append(Environment.NewLine);
        }

        Console.WriteLine(sb);
    }
}
