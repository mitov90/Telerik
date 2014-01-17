using System;

class SumInteger
{
    static void Main()
    {
        string data = "43 68 9 23 318";

        var tokens = data.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        int sum = 0;
        foreach ( var token in tokens )
        {
            int value = int.TryParse(token, out value) ? value : 0;
            sum += value;
        }
        Console.WriteLine(sum);
    }
}