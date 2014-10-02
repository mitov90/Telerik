using System;
using System.Text;

class Eratosthenes
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        Console.WriteLine("Up to (primes)? : ");
        int num = int.Parse(Console.ReadLine());
        bool[] matrix = new bool[num];

        //Eratosthenes
        int p = 2;
        while ( p<matrix.Length/2 )
        {
            for ( int j = 2; j * p < matrix.Length; j++ )
            {
                matrix[j * p] = true;
            }

            while ( p<matrix.Length/2 )
            {
                p++;
                if ( matrix[p] == false )
                    break; 
            }
        }
        //print
        for ( int i = 1; i < matrix.Length; i++ )
        {
            if (matrix[i]==false)
                sb.AppendLine(i.ToString());
        }
        Console.WriteLine(sb);
    }
}
