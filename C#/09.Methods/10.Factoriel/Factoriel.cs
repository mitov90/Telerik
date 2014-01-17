using System;
using System.Numerics;
using System.Text;

class Factoriel
{
    static void Main()
    {
        Console.Write("Enter factoriel num: ");
        int num = int.Parse(Console.ReadLine());
        BigInteger[] factoriels = new BigInteger[num+1];
        string sb = CalcFactoriel(factoriels, num);
        Console.WriteLine(sb);
    }

    private static string CalcFactoriel(BigInteger[] factoriels, int num)
    {
        StringBuilder sb = new StringBuilder();
        factoriels[0] = 1;
        for ( int i = 1; i <= num; i++ )
        {
            factoriels[i] = factoriels[i - 1] * i;
            sb.Append(factoriels[i] + Environment.NewLine);
        }
        return sb.ToString();
    }
}
