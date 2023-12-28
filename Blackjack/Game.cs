using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Game
    {
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
        }
    }
}
