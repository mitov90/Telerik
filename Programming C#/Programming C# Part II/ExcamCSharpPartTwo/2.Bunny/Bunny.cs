using System;
using System.Collections.Generic;
using System.Linq;

class Bunny
{
    static void Main()
    {
        var cages = new List<string>();

        GetCages(cages);

        for (int cycle = 0; cycle < cages.Count; cycle++)
        {
            int sumCages = GetSum(cages, 0,cycle);
            if (sumCages > cages.Count)
            {
                break;
            }
            uint productCages = GetProduct(cages, cycle+1, cycle+sumCages);
            int sumAllCages = GetSum(cages, cycle+1, cycle + sumCages);
            cages.RemoveRange(0,sumCages+cycle +1);

            var sumAsString = sumAllCages.ToString();
            var productAsString = productCages.ToString();

            for (int i = productAsString.Length - 1; i >= 0; i--)
            {
                cages.Insert(0,productAsString[i].ToString());
            }
            for (int i = sumAsString.Length - 1; i >= 0; i--)
            {
                cages.Insert(0, sumAsString[i].ToString());
            }

            cages.RemoveAll(t => t == "1" || t=="0");

        }
        Console.WriteLine(string.Join(" ",cages));
    }

    private static uint GetProduct(IReadOnlyList<string> cages, int start,int end)
    {
        uint product = 1;

        for (int i = start; i <= end; i++)
        {
            product *= uint.Parse(cages[i]);
        }

        return product;
    }

    private static int GetSum(IReadOnlyList<string> cages, int start, int end)
    {
        int sum = 0;

        for (int i = start; i <= end; i++)
        {
            sum += int.Parse(cages[i]);
        }

        return sum;
    }

    private static void GetCages(ICollection<string> cages)
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            else
            {
                cages.Add(input);
            }
        }
    }

    private static int CharParse(char ch)
    {
        return int.Parse(ch.ToString());
    }
}
