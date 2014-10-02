using System;

class MaxAndMinOfSequance
{
    static void Main()
    {
        int num;
        bool isFirstNum = true;
        int maxVal=int.MinValue;
        int minVal= int.MinValue;

        do
        {
            Console.Write("Enter last number: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out num) || num < 0 );

        for ( int i = 0; i < num; i++ )
        {
            int tempNum= InputNumber(i);
            if (isFirstNum)
            {
                Initilize(tempNum, ref isFirstNum, ref maxVal, ref minVal);
            }
            else
            {
                CheckMinMax(tempNum, ref maxVal, ref minVal);
            }
        }
        Console.WriteLine("Max value: " + maxVal);
        Console.WriteLine("Min value: " + minVal);
    }

    private static int InputNumber(int i)
    {
        int tempNum;
        do
        {
            Console.Write("Enter {0} value:", i);
        }
        while ( !int.TryParse(Console.ReadLine(), out tempNum) );
        return tempNum;
    }

    private static void Initilize(int tempNum, ref bool isFirstNum, ref int maxVal, ref int minVal)
    {

        isFirstNum = false;
        maxVal = tempNum;
        minVal = tempNum;
    }

    private static void CheckMinMax(int tempNum, ref int maxVal, ref int minVal)
    {
        if ( tempNum > maxVal )
            maxVal = tempNum;
        if ( tempNum < minVal )
            minVal = tempNum;
    }
}

