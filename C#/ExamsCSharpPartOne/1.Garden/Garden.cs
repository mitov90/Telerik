using System;

class Garden
{
    static void Main()
    {
        decimal tomatoCost = 0.5M;
        decimal carrotCost = 0.6M;
        decimal cucumbeCostr = 0.4M;
        decimal cabbageCost = 0.3M;
        decimal potatoCost = 0.25M;
        decimal beansCost = 0.4M;
        decimal tomatoSeeds = decimal.Parse(Console.ReadLine());
        decimal tomatoArea = decimal.Parse(Console.ReadLine());
        decimal cucumberSeeds = decimal.Parse(Console.ReadLine());
        decimal cucumberArea = decimal.Parse(Console.ReadLine());
        decimal potatoSeeds = decimal.Parse(Console.ReadLine());
        decimal potatoArea = decimal.Parse(Console.ReadLine());
        decimal carrotSeeds = decimal.Parse(Console.ReadLine());
        decimal carrotArea = decimal.Parse(Console.ReadLine());
        decimal cabbageSeeds = decimal.Parse(Console.ReadLine());
        decimal cabbageArea = decimal.Parse(Console.ReadLine());
        decimal beansSeeds = decimal.Parse(Console.ReadLine());
        decimal totalCost = tomatoSeeds * tomatoCost + cucumberSeeds * cucumbeCostr
            + potatoSeeds * potatoCost + carrotSeeds * carrotCost
            + cabbageSeeds * cabbageCost + beansSeeds * beansCost;
        Console.WriteLine("Total costs: " + totalCost);
        decimal beansArea = 250 - ( tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea );
        if ( beansArea > 0 )
            Console.WriteLine("Beans area: " + beansArea);
        else if ( beansArea < 0 )
            Console.WriteLine("Insufficient area");
        else
            Console.WriteLine("No area for beans");
    }
}
