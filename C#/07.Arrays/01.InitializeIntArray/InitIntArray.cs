using System;

class InitIntArray
{
    static void Main()
    {
        int[] myArray = new int[21];
        for ( int i = 0; i < myArray.Length; i++ )
        {
            myArray[i] = i * 5;
            Console.WriteLine(myArray[i]);
        }
    }
}
