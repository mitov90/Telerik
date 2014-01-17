using System;

class MaxOfValues
{
    static void Main()
    {
        int temp;
        int max = int.MinValue;;
        int numVariables = 5;

        for ( int i = 0; i < numVariables; i++ )
        {
            do
            {
                Console.Write("Enter value to compare: ");
            }
            while ( !int.TryParse(Console.ReadLine(), out temp) );
            if ( temp > max )
                max = temp;
        }

        if ( max == int.MinValue )
            Console.WriteLine("Some err");
        else
        {
            Console.WriteLine("Greatest number is {0}", max);
        }
    }
}

