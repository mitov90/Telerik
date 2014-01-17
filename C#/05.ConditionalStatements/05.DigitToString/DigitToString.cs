using System;

class DigitToString
{
    static void Main()
    {
        string[] digits = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        byte digit;

        do
        {
            Console.Write("Enter digit: ");
        }
        while (!byte.TryParse(Console.ReadLine(),out digit) || digit > 10);
        Console.Write("You hit ");
        switch ( digit )
        {
            case 0:
                Console.Write(digits[0]);
                break;
            case 1:
                Console.Write(digits[1]);
                break;
            case 2:
                Console.Write(digits[2]);
                break;
            case 3:
                Console.Write(digits[3]);
                break;
            case 4:
                Console.Write(digits[4]);
                break;
            case 5:
                Console.Write(digits[5]);
                break;
            case 6:
                Console.Write(digits[6]);
                break;
            case 7:
                Console.Write(digits[7]);
                break;
            case 8:
                Console.Write(digits[8]);
                break;
            case 9:
                Console.Write(digits[9]);
                break;

            default:
                Console.Write("Wrong input");
                throw new ArgumentException();
        }
        Console.WriteLine();
    }
}
