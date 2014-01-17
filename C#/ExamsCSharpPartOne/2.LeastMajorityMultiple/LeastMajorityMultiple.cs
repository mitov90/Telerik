using System;
using System.Collections.Generic;
using System.Linq;

class LeastMajorityMultiple
{
    static void Main(string[] args)
    {
        #region Values
        int[] values = {
                           int.Parse(Console.ReadLine()),
                           int.Parse(Console.ReadLine()),
                           int.Parse(Console.ReadLine()),
                           int.Parse(Console.ReadLine()),
                           int.Parse(Console.ReadLine())
                       };
        #endregion

        for ( int i = 1;i <int.MaxValue ; i++ )
        {
            int count = 0;
            if ( i % values[0] == 0 )
                count++;
            if ( i % values[1] == 0 )
                count++;
            if ( i % values[2] == 0 )
                count++;
            if ( i % values[3] == 0 )
                count++;
            if ( i % values[4] == 0 )
                count++;
            if ( count >= 3 )
            {
                Console.WriteLine(i);
                break;
            }
        }

    }

   
}
