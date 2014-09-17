using System;
using System.Globalization;
using System.Threading;

class CompareTo7Sign
{
    private static bool CompareWithMagnitude(decimal first, decimal second, decimal numSign)
    {
        if ( Math.Abs(first - second) < numSign )
            return true;
        return false;
    }
    static void Main()
    {
        CultureInfo myCI = (CultureInfo) CultureInfo.CurrentCulture.Clone();
        myCI.NumberFormat.NumberDecimalSeparator= "."; /* The numbers are separeted by dot(.) */
        Thread.CurrentThread.CurrentCulture = myCI;

        decimal magnitude = 0.000001M;
        decimal firstVal = 0M;
        decimal secondVal = 0M;
        string [] inputs;

        do
        {
            Console.WriteLine("Enter floating point numbers to compare");
            Console.WriteLine("Format (x.y,n.m) Ex: 123.45, 67.890");
            inputs = Console.ReadLine().Split(new char[] { '(', ')', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        } while ( inputs.Length != 2
                 || !decimal.TryParse(inputs[0], out firstVal)
                 || !decimal.TryParse(inputs[1], out secondVal));
        
        Console.WriteLine("{0} and {1} are{2} equal with magnitude of {3}", firstVal, secondVal, CompareWithMagnitude(firstVal, secondVal, magnitude)? string.Empty : " not", magnitude);
    }
}
