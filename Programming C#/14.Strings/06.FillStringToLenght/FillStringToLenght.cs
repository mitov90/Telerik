using System;

class FillStringToLenght
{
    static void Main()
    {
        int maxLenght = 20;
        char symbol = '*';
        string input = Console.ReadLine();

        try
        {
            GetStringFill(input, maxLenght, symbol);
        }
        catch ( ArgumentException e )
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void GetStringFill(string input, int maxLenght, char symbol)
    {
        if ( input.Length > maxLenght )
            throw new ArgumentException("Input max lenght exceeded!");

        input = input.PadRight(maxLenght, symbol);
        Console.WriteLine(input);
    }
}
