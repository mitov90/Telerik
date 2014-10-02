using System;

class DoubleOrFloat
{
    static void Main()
    {
       // 34.567839023, 12.345, 8923.1234857, 3456.091
        double firstVar = 34.567839023;
        Console.WriteLine(firstVar + " - " + typeof(double));
        float secondVar = 12.345f;
        Console.WriteLine(secondVar + " - " + typeof(float));
        double thirdVar = 8923.1234857;
        Console.WriteLine(thirdVar + " - " + typeof(double));
        float fourthVar = 3456.091f;
        Console.WriteLine(fourthVar + " - " + typeof(float));
    }
}
