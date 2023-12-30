using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Player
    {
        public string Name { get; set; }
        public List<Card> Hand = [];
        public int Score { get; set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
        }

        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
            Score += card.CardValue;
        }

        public virtual bool HitOrStand()
        {
            while (true)
            {
                Console.Write("Do you want to hit or stand? (h/s): ");
                string choice = Console.ReadLine();
                if (choice.Equals("h"))
                {
                    Console.WriteLine($"{Name} hits.");
                    Console.WriteLine();
                    return true;
                }
                else if (choice.Equals("s"))
                {
                    Console.WriteLine($"{Name} stands.");
                    Console.WriteLine();
                    return false;
                }

            }
        }

        public virtual void PrintPlayerHand()
        {
            Console.WriteLine($"{Name}'s hand:\n\t{String.Join("\n\t", Hand)}\n\tScore: {Score}");
        }
    }

    internal class Dealer : Player
    {
        public Dealer() : base("Dealer")
        {
            Score = 0;
        }

        override public bool HitOrStand()
        {

            if (Score < 17)
            {
                Console.WriteLine($"{Name} hits.");
                return true;
            }
            else
            {
                Console.WriteLine($"{Name} stands.");
                return false;
            }
        }
    }
}
