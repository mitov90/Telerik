using System;

class ThirdBit
{
    static void Main()
    {
        int p = 3;
        int mask = 1 << p;        
        int value;
        do
        {
            Console.WriteLine("Enter integer: ");
        }while(!int.TryParse(Console.ReadLine(), out value));           
        int nAndMask = value & mask;  
        int bit = nAndMask >> p;  
        Console.WriteLine(bit);   
    }
}

