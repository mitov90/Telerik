using System;

class RandomGen
{
    static readonly Random gen = new Random();
    static void Main()
    {
        for ( int i = 0; i < 10; i++ )
        {
            Console.WriteLine(100+ gen.Next(101));
        }
    }
}
