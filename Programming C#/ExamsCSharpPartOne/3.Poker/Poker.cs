using System;
using System.Collections.Generic;

class Poker
{
    static void Main()
    {
        SortedDictionary<byte, byte> cards = new SortedDictionary<byte, byte>();

        for ( int i = 0; i < 5; i++ )
        {
            string curCard = Console.ReadLine();
            byte cardNumber = 0;
            switch ( curCard )
            {
                case "J":
                    cardNumber = 11;
                    break;
                case "Q":
                    cardNumber = 12;
                    break;
                case "K":
                    cardNumber = 13;
                    break;
                case "A":
                    cardNumber = 14;
                    break;
                default:
                    cardNumber = byte.Parse(curCard);
                    break;
            }
            if (cards.ContainsKey(cardNumber))
                cards[cardNumber]++;
            else
                cards.Add(cardNumber, 1);
        }
        

        if (cards.ContainsValue(5))
        {
            Console.WriteLine("Impossible");
        }
        else if (cards.ContainsValue(4))
        {
            Console.WriteLine("Four of a Kind");
        }
        else if (cards.ContainsValue(3)&&cards.ContainsValue(2))
        {
            Console.WriteLine("Full House");
        }
        else if ( CheckStraight(cards) )
        {
            Console.WriteLine("Straight");
        }
        else if (cards.ContainsValue(3))
        {
            Console.WriteLine("Three of a Kind");
        }
        else if (cards.ContainsValue(2)&&cards.Values.Count==3)
        {
            Console.WriteLine("Two Pairs");
        }
        else if (cards.ContainsValue(2))
        {
            Console.WriteLine("One Pair");
        }
        else
        {
            Console.WriteLine("Nothing");
        }
    }
    static bool CheckStraight(SortedDictionary<byte,byte> cards)
    {
        bool result = false;
        if (cards.ContainsKey(14))
        {
            cards.Add(1, 1);
        }

        for ( int i = 1; i < 11; i++ )
        {
            if (cards.ContainsKey((byte)i)&&
                cards.ContainsKey((byte)(i+1))&&
                cards.ContainsKey((byte)(i+2))&&
                cards.ContainsKey((byte)(i+3))&&
                cards.ContainsKey((byte)(i+4)))
            {
                result = true;
            }
        }

        cards.Remove(1);
        return result;
    }
}
