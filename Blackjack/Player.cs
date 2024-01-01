using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            if (Score > 21)
            {
                // If hand contains an Ace with a value of 11
                if (Hand.Any(card => card.IsAce && card.CardValue == 11))
                {
                    // Add aces in hand to new list
                    List<Card> acesInHand = Hand.Where(card => card.IsAce).ToList();
                    while (Score > 21)
                    {
                        acesInHand[0].CardValue = 1;
                        acesInHand.Remove(acesInHand[0]);
                        Score -= 10;
                    }
                }
            }
        }

        public virtual bool HitOrStand()
        {
            while (true)
            {
                Console.Write("Do you want to hit or stand? (h/s): ");
                string choice = Console.ReadLine();
                if (choice.ToLower().Equals("h"))
                {
                Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{Name} hits.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    return true;
                }
                else if (choice.ToLower().Equals("s"))
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{Name} stands.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    return false;
                }

            }
        }

        public virtual void PrintPlayerHand(bool isInitialRound = false)
        {
            if (isInitialRound && this.GetType() == typeof(Dealer))
            {
                Console.WriteLine($"----- {Name}'s HAND -----");
                Console.WriteLine($"{Name}'s hand:\n\tHole card\n\t{Hand[1]}\n\tScore: {Hand[1].CardValue} + ?");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"----- {Name}'s HAND -----");
                Console.WriteLine($"{Name}'s hand:\n\t{String.Join("\n\t", Hand)}\n\tScore: {Score}");
                Console.WriteLine();
            }
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
