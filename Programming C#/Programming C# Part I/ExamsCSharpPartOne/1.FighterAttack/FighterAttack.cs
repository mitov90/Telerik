using System;

class FighterAttack
{
    static void Main(string[] args)
    {
        int px1 = int.Parse(Console.ReadLine());
        int py1 = int.Parse(Console.ReadLine());
        int px2 = int.Parse(Console.ReadLine());
        int py2 = int.Parse(Console.ReadLine());
        int fx = int.Parse(Console.ReadLine());
        int fy = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());


        int minx1 = Math.Min(px1, px2);
        int maxx2 = Math.Max(px1, px2);
        int miny1 = Math.Min(py1, py2);
        int maxy2 = Math.Max(py1, py2);

        int resultDamage = 0;

        int centerBomb = fx + d;

        if ( centerBomb >= minx1 && centerBomb <= maxx2 &&
            fy >= miny1 && fy <= maxy2 )
            resultDamage += 100;
        if ( centerBomb + 1 >= minx1 && centerBomb + 1 <= maxx2 &&
           fy >= miny1 && fy <= maxy2 )
            resultDamage += 75;
        if ( centerBomb >= minx1 && centerBomb <= maxx2 &&
           fy+1 >= miny1 && fy+1 <= maxy2 )
            resultDamage += 50;
        if ( centerBomb >= minx1 && centerBomb <= maxx2 &&
          fy - 1 >= miny1 && fy - 1 <= maxy2 )
            resultDamage += 50;
        Console.WriteLine(resultDamage+"%");
    }
}
