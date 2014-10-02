using System;

class SumInt
{
    static void Main()
    {
        int counter=0;
        int numberSums = 3;
        int sum = 0;
        int num;

        for ( int i = 0; i < numberSums; i++ )
        {
            Console.Write("Enter {0} number to sum with: ", i+1);
            if ( int.TryParse(Console.ReadLine(), out num) )
            {
                counter++;
                sum += num;
            }
        }
        Console.WriteLine("Sum : {0}", sum);
    }
}
