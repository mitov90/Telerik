
using System;
using System.Text;

class ChiperText
{
    static void Main()
    {
        string chiper = "test";
        string input = "Godzzila and King Kong";

        var result = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            result.Append((char)(input[i] ^ chiper[i%chiper.Length]));
        }

        Console.WriteLine(result);
    }
}
