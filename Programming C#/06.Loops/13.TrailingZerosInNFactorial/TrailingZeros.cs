using System;

class TrailingZeros
{
    static void Main()
    {
        uint numFactorial = InputValue();
        uint factorOfFive = 5;
        uint trailingZeros = 0;

        trailingZeros = CalcTrailingZero(numFactorial, factorOfFive, trailingZeros);
        Console.WriteLine("Trailing zeros in {0}! -> {1}",numFactorial, trailingZeros);
    }

    private static uint CalcTrailingZero(uint numFactorial, uint factorOfFive, uint trailingZeros)
    {
        for ( uint i = factorOfFive; numFactorial / i != 0; i *= factorOfFive )
        {
            trailingZeros += numFactorial / i;
        }
        return trailingZeros;
    }

    private static uint InputValue()
    {
        uint numFactorial;
        do
        {
            Console.Write("Enter number of factorial: ");
        }
        while ( !uint.TryParse(Console.ReadLine(), out numFactorial) );
        return numFactorial;
    }
}
