using System;

class NextDate
{
    static void Main()
    {
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());

        DateTime dt = new DateTime(year,month,day).AddDays(1);
        Console.WriteLine(dt.Day+"."+dt.Month+"."+dt.Year);
    }
}
