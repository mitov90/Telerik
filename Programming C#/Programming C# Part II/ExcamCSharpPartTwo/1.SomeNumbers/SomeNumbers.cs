using System;
using System.Collections.Generic;

internal class SomeNumbers
{
    private static readonly string[] GalNumSystem =
    {
        "LON+",
        "VK-",
        "*ACAD2",
        "^MIM",
        "ERIK|",
        "SEY&",
        "EMY>>",
        "/TL",
        "<<DON"
    };

    private static void Main()
    {
        ulong value = ulong.Parse(Console.ReadLine());
        var result = new List<string>();

        for (int i = 0; value != 0; i++)
        {
            result.Add(GalNumSystem[value%9]);
            value /= 9;
        }

        for (int i = result.Count - 1; i >= 0; i--)
        {
            Console.Write(result[i]);
        }
    }
}
