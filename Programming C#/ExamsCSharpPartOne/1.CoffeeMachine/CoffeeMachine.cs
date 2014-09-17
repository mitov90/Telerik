using System;
using System.Threading;
class CoffeeMachine
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        uint coins5 = uint.Parse(Console.ReadLine());
        uint coins10 = uint.Parse(Console.ReadLine());
        uint coins20 = uint.Parse(Console.ReadLine());
        uint coins50 = uint.Parse(Console.ReadLine());
        uint coins100 = uint.Parse(Console.ReadLine());
        decimal cachedMoney = decimal.Parse(Console.ReadLine());
        decimal price = decimal.Parse(Console.ReadLine());
        decimal totalSum = coins5 * 0.05M + coins10 * 0.10M + coins20 * 0.2M + coins50 * 0.5M + coins100 * 1M;

        if (price-cachedMoney>0)
            Console.WriteLine("More " + (price-cachedMoney));
        else if (cachedMoney-price > totalSum)
        {
            Console.WriteLine("No " + (cachedMoney-(totalSum+price)));
        }else if (cachedMoney-price <= totalSum)
        {
            Console.WriteLine("Yes " + (totalSum - (cachedMoney-price)));
        }
    }
}
