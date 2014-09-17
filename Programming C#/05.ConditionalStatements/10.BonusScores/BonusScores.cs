using System;

class BonusScores
{
    static void Main()
    {
        string userInput;
        int userDigit;
        Console.Write("Enter your digit: ");
        userInput = Console.ReadLine();
        if ( int.TryParse(userInput, out userDigit) )
        {

            switch ( userDigit )
            {
                case 1:
                case 2:
                case 3:
                    Console.WriteLine("Bonus scores: " + userDigit*10);
                    break;
                case 4:
                case 5:
                case 6:
                    Console.WriteLine("Bonus scores: " + userDigit * 100);
                    break;
                case 7:
                case 8:
                case 9:
                    Console.WriteLine("Bonus scores: " + userDigit * 1000);
                    break;
                default:
                    Console.WriteLine("Error in your input!");
                    break;
            }
        }
    }
}
