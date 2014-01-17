using System;

class FibonacciSum
{
    static void Main()
    {
        uint sum = 1;
        int numFib;

        do
        {
            Console.Write("Enter number to sum fib > 1: ");
        }
        while ( !int.TryParse(Console.ReadLine(),out numFib) || numFib<2 );

        uint[] fibValues = new uint[numFib + 1];
        fibValues[0] = 0;
        fibValues[1] = 1;
        for ( int i = 2; i < numFib; i++ )
        {
            fibValues[i] = fibValues[i - 1] + fibValues[i - 2];
            sum += fibValues[i];
        }

        Console.WriteLine("Sum fibonacci numbers to {0} : {1}",numFib,sum);
    }
}
