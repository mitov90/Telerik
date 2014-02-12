using System;

class PermutationGreen
{
    private static int _counter = 0;

    private static bool IsValid(int length, int[] numbers)
    {
        for (int i = 1; i < length; i++)
        {
            if (numbers[i] == numbers[i - 1])
            {
                return false;
            }
        }
        _counter++;
        return true;
    }

    static void Main()
    {
        var length = int.Parse(Console.ReadLine());
        var numbers = new int[length];

        for (int i = 0; i < length; i++)
        {
            numbers[i] = char.Parse(Console.ReadLine());
        }
        
        Array.Sort(numbers);
        IsValid(length, numbers);

        while (NextPermutation(length, numbers))
        {
            IsValid(length, numbers);
        }
        Console.WriteLine(_counter);
    }

    private static bool NextPermutation(int length, int[] numbers)
    {
        if (length == 1) return false;
        int k = length - 2;
        while (numbers[k] >= numbers[k + 1])
        {
                k--;
            
            if (k < 0)
            {
                return false;
            }
        }

        int l = length-1;
        while (numbers[k] >= numbers[l])
        {
                l--;
        }

        SwapValues(numbers, k, l);

        //reverse from numbers[k+1] -> to last elemte

        for (int i = k + 1, j = length - 1; i < j ; i++,j--)
        {
            SwapValues(numbers,i,j);
        }

        return true;
    }

    private static void SwapValues(int[] numbers, int k, int l)
    {
        int temp = numbers[k];
        numbers[k] = numbers[l];
        numbers[l] = temp;
    }
}
