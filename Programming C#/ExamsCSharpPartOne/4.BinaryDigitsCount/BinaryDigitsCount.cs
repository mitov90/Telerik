using System;

class BinaryDigitsCount
{
    static void Main(string[] args)
    {
        char binaryDigits = char.Parse(Console.ReadLine());
        int numValues = int.Parse(Console.ReadLine());

        for ( int i = 0; i < numValues; i++ )
        {
            long value = long.Parse(Console.ReadLine());
            string valueAsString = Convert.ToString(value, 2);

            int counter = 0;
            for ( int j = 0; j < valueAsString.Length; j++ )
            {
                if ( valueAsString[j] == binaryDigits )
                    counter++;
            }
            Console.WriteLine(counter);
        }


    }
}
