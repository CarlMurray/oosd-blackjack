using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Game
    {
        const int MAX_SCORE = 21;

        public Player[] Players = new Player[2];

        public Game(Player[] players)
        {
            Players = players;
        }

        /*
         * Description:
         *      Gets last card in deck, copies to player hand, removes from deck.
         *      
         * Parameters:
         *      Deck deck: The deck to deal from.
         *      Player player: The player to deal card to.
         */
        public void Deal(Deck deck, Player player)
        {
            // Get last item in deck array, copy to player hand, remove from deck.
            Card card = deck.CardsInDeck.Last();
            player.AddCardToHand(card);
            deck.RemoveTopCard();
            Console.WriteLine($"{card} dealt to {player.Name}");
        }

        public bool EvaluateScores(bool bothStand)
        {

            bool isDraw = false;
            bool playerWins = false;
            bool dealerWins = false;

            if (bothStand)
            {
                if (Players[0].Score > Players[1].Score)
                {
                    Console.WriteLine($"{Players[0].Name} wins.");
                    playerWins = true;
                    return playerWins;
                }
                else if (Players[0].Score < Players[1].Score)
                {
                    Console.WriteLine($"{Players[1].Name} wins.");
                    dealerWins = true;
                    return dealerWins;
                }
                else
                {
                    Console.WriteLine("Game is a draw");
                    isDraw = true;
                    return isDraw;
                }
            }

            // If player and dealer have 21
            if ((Players[0].Score == Players[1].Score) && Players[0].Score == MAX_SCORE)
            {
                Console.WriteLine("Game is a draw");
                isDraw = true;
                return isDraw;
            }
            // If player has 21 and dealer does not
            else if (Players[0].Score == MAX_SCORE && Players[0].Score > Players[1].Score)
            {
                Console.WriteLine($"{Players[0].Name} wins.");
                playerWins = true;
                return playerWins;
            }
            // If dealer has 21 and player does not
            else if (Players[1].Score == MAX_SCORE && Players[1].Score > Players[0].Score)
            {
                Console.WriteLine($"{Players[1].Name} wins.");
                dealerWins = true;
                return dealerWins;
            }
            // If player busts and dealer doesn't
            else if (Players[0].Score > MAX_SCORE && Players[1].Score <= MAX_SCORE)
            {
                Console.WriteLine($"{Players[1].Name} wins.");
                dealerWins = true;
                return dealerWins;
            }
            // If dealer busts and player doesn't
            else if (Players[1].Score > MAX_SCORE && Players[0].Score >= MAX_SCORE)
            {
                Console.WriteLine($"{Players[0].Name} wins.");
                playerWins = true;
                return playerWins;
            }
            // If both player and dealer bust, draw
            else if (Players[0].Score > MAX_SCORE && Players[1].Score > MAX_SCORE)
            {
                Console.WriteLine("Game is a draw");
                isDraw = true;
                return isDraw;
            }
            return false;

        }
    }
}
