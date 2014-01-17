using System;
using System.Linq;
class CalcWorkDays
{
    public static DateTime[] Holydays2014 = {
                                                new DateTime(2014, 1, 1), new DateTime(2014, 3, 3),
                                                new DateTime(2014, 5, 1), new DateTime(2014, 5, 2),
                                                new DateTime(2014, 5, 3), new DateTime(2014, 5, 4),
                                                new DateTime(2014, 5, 5), new DateTime(2014, 5, 6),
                                                new DateTime(2014, 5, 24), new DateTime(2014, 9, 6), 
                                                new DateTime(2014, 9, 22), new DateTime(2014, 12, 24),
                                                new DateTime(2014, 12, 25), new DateTime(2014, 12, 26),
                                                new DateTime(2014, 12, 31)
                                            };
    static void Main()
    {
        DateTime futureDate = new DateTime(2014, 12, 26);
        int workdays = CalcWork(futureDate);

        Console.WriteLine(workdays);
    }

    private static int CalcWork(DateTime futureDate)
    {
        DateTime curDate = DateTime.Today;
        int workdays = 0;

        while ( !curDate.Equals(futureDate) )
        {
            if ( curDate.DayOfWeek >= DayOfWeek.Monday && curDate.DayOfWeek <= DayOfWeek.Friday
                && !Holydays2014.Contains(curDate) )
                workdays++;
            curDate = curDate.AddDays(1);
        }
        return workdays;
    }
}