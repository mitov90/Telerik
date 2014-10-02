using System;

class ShipDamage
{
    static void Main(string[] args)
    {
        int sx1 = int.Parse(Console.ReadLine());
        int sy1 = int.Parse(Console.ReadLine());
        int sx2 = int.Parse(Console.ReadLine());
        int sy2 = int.Parse(Console.ReadLine());

        int sminx = Math.Min(sx1, sx2);
        int sminy = Math.Min(sy1, sy2);
        int smaxx = Math.Max(sx1, sx2);
        int smaxy = Math.Max(sy1, sy2);

        int h = int.Parse(Console.ReadLine());

        const int numberCatapult = 3;
        int[,] catapults = new int[numberCatapult,2];

        for ( int i = 0; i < numberCatapult; i++ )
        {
            catapults[i,0] = int.Parse(Console.ReadLine());
            catapults[i,1] = 2 * h - int.Parse(Console.ReadLine());
        }

        int damageResult = 0;

        for ( int i = 0; i < numberCatapult; i++ )
        {
            if ( catapults[i, 0] > sminx && smaxx > catapults[i, 0] &&
                catapults[i, 1] > sminy && smaxy > catapults[i, 1] )
                damageResult += 100;
            else if ( ( sminx == catapults[i, 0] || smaxx == catapults[i, 0] ) &&
            ( smaxy == catapults[i, 1] || sminy == catapults[i, 1] ) )
                damageResult += 25;
            else if ( ( ( sminy < catapults[i, 1] && smaxy > catapults[i, 1] ) && 
                ( sminx == catapults[i, 0] || smaxx == catapults[i, 0] ) ) ||
                ( ( sminx < catapults[i, 0] && smaxx > catapults[i, 0] ) && 
                ( sminy == catapults[i, 1] || smaxy == catapults[i, 1] ) ) )
                damageResult += 50;
        }

        Console.WriteLine(damageResult + "%");


     


    }
}
