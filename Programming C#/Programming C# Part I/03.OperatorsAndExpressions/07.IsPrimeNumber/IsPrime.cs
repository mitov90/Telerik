using System;
using System.Collections;

class IsPrime
{
    static bool isNumPrime(ulong num)
    {
    if(num == 1) return false;
    if(num == 2 || num == 3) return true;
    if((num & 1)== 0 ) return false;
    if(!(((num + 1) % 6 !=0 ) ||
        (num-1) % 6 != 0))
        return false;
    ulong q = (ulong) Math.Sqrt(num) + 1;
    for(ulong v = 3; v < q; v += 2)
        if(num % v == 0)
            return false;
    return true;
    }

    static void Main()
    {
        ulong value;
        do
        {
            Console.WriteLine("Enter value to check:");
        } 
        while ( !ulong.TryParse(Console.ReadLine(), out value) || value < 0 );

        bool isPrime = isNumPrime(value);

        Console.WriteLine("Number {0} is {1}prime", value,
            isPrime ? string.Empty : "not ");
    }
}
