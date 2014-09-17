using System;
using System.Linq;

public class Sums
{
    public static long CalculateBinom(int n, int k)
    {
        long nominator = 1;
        for (int i = n; i >= (n - k + 1); i--)
        {
            nominator *= i;
        }

        long denominator = 1;
        for (int i = k; i >= 1; i--)
        {
            denominator *= i;
        }

        return nominator / denominator;
    }

    public static long CalculateSum(int[] numbers)
    {
        return numbers.Aggregate<int, long>(0, (current, t) => current + t);
    }

    public static void ReadInputAndSolve()
    {
        int tests = int.Parse(Console.ReadLine());
        for (int i = 0; i < tests; i++)
        {
            string[] nAndKValues = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            short n = short.Parse(nAndKValues[0]);
            short k = short.Parse(nAndKValues[1]);
            int[] numbers =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            Console.WriteLine(SolveSumSubSeq(n, k, numbers));
        }
    }

    public static long SolveSumSubSeq(int n, int k, int[] numbers)
    {
        long sumSubSeq = CalculateBinom(n - 1, k) * CalculateSum(numbers);
        return sumSubSeq;
    }

    private static void Main()
    {
        ReadInputAndSolve();
    }
}