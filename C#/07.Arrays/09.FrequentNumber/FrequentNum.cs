using System;
using System.Collections.Generic;
using System.Linq;

class FrequentNum
{
    static void Main()
    {
        int[] myArray = InputValues();
        Dictionary<int, byte> myDict = new Dictionary<int, byte>();

        for ( int i = 0; i < myArray.Length; i++ )
        {
            if ( myDict.ContainsKey(myArray[i]) )
                myDict[myArray[i]]++;
            else
                myDict.Add(myArray[i], 1);
        }
        if ( myDict.Count > 0 )
        {
            var result = from pair in myDict
                         orderby pair.Value descending
                         select pair;
            foreach ( var pair in result )
            {
                Console.WriteLine("Number " + pair.Key + " -> " + pair.Value);

            }
        }
    }

    private static int[] InputValues()
    {
        byte arrSize;
        do
        {
            Console.Write("Enter array size: ");
        }
        while ( !byte.TryParse(Console.ReadLine(), out arrSize) );
        int[] myArray = new int[arrSize];
        for ( int i = 0; i < myArray.Length; i++ )
        {
            do
            {
                Console.Write("Enter {0} element:", i + 1);
            }
            while ( !int.TryParse(Console.ReadLine(), out myArray[i]) );
        }
        return myArray;
    }
}

