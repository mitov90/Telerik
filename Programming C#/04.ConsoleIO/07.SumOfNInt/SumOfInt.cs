using System;

class SumOfInt
{
    static void Main()
    {
        int numberOfSum;
        do
        {
            Console.Write("Enter number of sums: ");
        }
        while ( !int.TryParse(Console.ReadLine(), out numberOfSum) || numberOfSum < 0 );

        int tempNumber;
        int sum = 0;
        for ( int i = 0; i < numberOfSum; i++ )
        {
            do
            {
                Console.Write("Current sum: {0} Enter {1} to sum with: ", sum, i+1);
            }
            while ( !int.TryParse(Console.ReadLine(), out tempNumber) );
            sum += tempNumber;

        }
        Console.WriteLine("Final sum: "+ sum);
    }
}
