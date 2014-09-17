using System;

class PrintCardDeck
{
    static void Main()
    {
        for ( int i = 0; i < 4; i++ )
        {
            string suit = string.Empty;
            switch ( i )
            {
                case 0:
                    suit = "spades";
                    break;
                case 1:
                    suit = "diamonds";
                    break;
                case 2:
                    suit = "clubs";
                    break;
                case 3:
                    suit = "hearts";
                        break;
            }
            for ( int j = 1; j <= 13; j++ )
            {
                switch ( j )
                {
                    case 1:
                        Console.WriteLine("Ace " + suit);
                        break;
                    case 11:
                        Console.WriteLine("Jack " + suit);
                        break;
                    case 12:
                        Console.WriteLine("Queen " + suit);
                        break;
                    case 13:
                        Console.WriteLine("King " + suit);
                        break;
                    default:
                        Console.WriteLine(j+ " " + suit);
                        break;
                }
            }
        }
    }
}
