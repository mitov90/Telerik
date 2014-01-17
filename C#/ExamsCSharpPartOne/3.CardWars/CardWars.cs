using System;
using System.Numerics;

class Card_Wars
{
    static void Main(string[] args)
    {

        string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "A", "J", "Q", "K" };
        int[] cardsPoints = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 11, 12, 13 };

        BigInteger[] scores = { 0, 0 };
        int[] currScores = { 0, 0 };
        bool[] cardsX = { false, false };
        int[] gamesWin = { 0, 0 };

        int gamesCount = int.Parse(Console.ReadLine());
        for ( int i = 0; i < gamesCount; i++ )  //games
        {
            cardsX[0] = false;
            cardsX[1] = false;
            for ( int j = 0; j <= 1; j++ )  //players
            {
                currScores[j] = 0;
                int currCardCounter = 0;
                for ( int k = 0; k <= 2; k++ ) //cards
                {
                    string card = Console.ReadLine();
                    currCardCounter++;

                    if ( card == "Y" )
                    {
                        scores[j] -= 200;
                    }
                    else if ( card == "Z" )
                    {
                        scores[j] *= 2;
                    }
                    else if ( card == "X" )
                    {
                        cardsX[j] = true;
                        //break;
                    }
                    else
                    {
                        int ind = Array.IndexOf(cards, card);
                        int cardPoint = cardsPoints[ind];
                        currScores[j] += cardPoint;
                    }
                }//cards end

                for ( int l = 1; l <= 3 - currCardCounter; l++ )
                {
                    Console.ReadLine();
                }

            }//players end

            if ( cardsX[0] && cardsX[1] )
            {
                scores[0] += 50;
                scores[1] += 50;
            }
            else if ( cardsX[0] )
            {
                break;
            }
            else if ( cardsX[1] )
            {
                break;
            }

            if ( currScores[0] > currScores[1] )
            {
                scores[0] += currScores[0];
                gamesWin[0]++;
            }
            else if ( currScores[0] < currScores[1] )
            {
                scores[1] += currScores[1];
                gamesWin[1]++;
            }
            // else  nothig if equal
            cardsX[0] = false;
            cardsX[1] = false;
        }//games end


        if ( cardsX[0] )
        {
            Console.WriteLine("X card drawn! Player one wins the match!");
        }
        else if ( cardsX[1] )
        {
            Console.WriteLine("X card drawn! Player two wins the match!");
        }
        else if ( scores[0] > scores[1] )
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: {0}", scores[0]);
            Console.WriteLine("Games won: {0}", gamesWin[0]);
        }
        else if ( scores[0] < scores[1] )
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: {0}", scores[1]);
            Console.WriteLine("Games won: {0}", gamesWin[1]);
        }
        else
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", scores[0]);
        }
    }
}