using System;
using System.Globalization;
using System.Text;
using System.Threading;

class FloatRepresentation
{
    unsafe static void Main()
    {
        float testNumber = -27.25F;

        //unsafe
        //int valueAsInteger = *(int*)&testNumber;
        //string result = Convert.ToString(valueAsInteger,2);

        string exponent;
        string mantisa;
        char sign;
        FloatToStringBin(testNumber, out exponent, out mantisa, out sign);

        Console.WriteLine("Sign: " + sign);
        Console.WriteLine("Exponent: " + exponent);
        Console.WriteLine("Mantisa: " + mantisa);
    }

    unsafe private static void FloatToStringBin(float testNumber, out string exponent, out string mantisa, out char sign)
    {
        var bytes = BitConverter.GetBytes(testNumber);
        StringBuilder result = new StringBuilder();

        for ( int i = bytes.Length - 1; i >= 0; i-- )
        {
            result.Append(Convert.ToString(bytes[i], 2).PadLeft(8, '0'));
        }

        exponent = result.ToString().Substring(1, 8);
        mantisa = result.ToString().Substring(9);

        sign = testNumber < 0 ? '1' : '0';
    }
}