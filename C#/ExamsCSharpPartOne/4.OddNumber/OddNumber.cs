using System;
using System.Collections.Generic;
using System.Text;

namespace _4.OddNumber
{
    class OddNumber
    {
        static void Main(string[] args)
        {
            Dictionary<long, int> myDict = new Dictionary<long, int>();
            int numLines = int.Parse(Console.ReadLine());

            for ( int i = 0; i < numLines; i++ )
            {
                long tempNum = long.Parse(Console.ReadLine());

                if ( myDict.ContainsKey(tempNum) )
                {
                    myDict[tempNum]++;
                }
                else
                {
                    myDict.Add(tempNum, 1);
                }
            }
            foreach ( var pair in myDict )
            {
                if (pair.Value%2!=0)
                {
                    Console.WriteLine(pair.Key);
                }
            }
        }
    }
}
