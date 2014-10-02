using System;

class MaxNumber
{
    static void Main()
    {
        const int NumValues = 3;
        int[] values = InputValues(NumValues);

        Console.WriteLine(GetMax(values[0],values[1],values[2]));
    }

    private static int[] InputValues(int numValues)
    {
        int tempValue;
        int[] values = new int[numValues];
        for ( int i = 0; i < numValues; i++ )
        {
            do
            {
                Console.Write("Enter {0} number: ", i + 1);
            }
            while ( !int.TryParse(Console.ReadLine(), out tempValue) );
            values[i] = tempValue;
        }
        return values;
    }

    static int GetMax(int a, int b)
    {
        return a>b?a:b;
    }
    
    static int GetMax(int a,int b, int c)
    {
        return GetMax(GetMax(a, b), c);
    }
}
