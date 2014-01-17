using System;
using System.Collections.Generic;

class SubSetSum
{
    static void Main()
    {
        long sum = long.Parse(Console.ReadLine());
        byte numValues = byte.Parse(Console.ReadLine());
        List<long[]> myList = new List<long[]>();
        int counter = 0;
        for ( byte i = 0; i < numValues; i++ )
        {
            long temp = long.Parse(Console.ReadLine());
            List<long[]> newList = new List<long[]>(myList);
            foreach ( var arr in myList )
            {
                long[] tempArr = new long[arr.Length + 1];
                arr.CopyTo(tempArr, 1);
                tempArr[0] = temp;
                newList.Add(tempArr);
            }
            myList = newList;
            myList.Add(new long[] { temp });
        }

        foreach ( var item in myList )
        {
            long tempSum = 0;
            foreach ( var value in item )
            {
                tempSum+=value;

            }
            if ( tempSum == sum )
                counter++;
        }
        Console.WriteLine(counter);
    }
}
