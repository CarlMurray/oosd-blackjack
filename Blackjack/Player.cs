using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Player
    {
        public string Name { get; set; }
        public List<Card> Hand = [];
        public int Score { get; set; }

        public Player(string name, int score = 0)
        {
            Name = name;
            Score = score;
        }

        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
            Score += card.CardValue;
        }
    }
}
