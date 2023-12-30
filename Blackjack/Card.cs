namespace Blackjack;

public class Card
{
    // CONSTRUCTOR
    public Card(int suit, int rank)
    {
        Suit = (CardSuit)suit;
        Rank = (CardRank)rank;

        // SET IsFaceCard
        if ((int)Rank >= 10 && (int)Rank <= 13)
        {
            IsFaceCard = true;
        }
        else
        {
            IsFaceCard = false;
        }

        // SET CardValue
        if (IsFaceCard)
        {
            CardValue = 10;
        }
        else if (IsAce)
        {
            CardValue = 11;
        }
        else
        {
            CardValue = (int)Rank;
        }
    }
    
    // PROPERTIES
    public CardSuit Suit { get; set; }
    public CardRank Rank { get; set; }
    public bool IsAce { get; set; }
    public int CardValue { get; set; }
    public bool IsFaceCard { get; set; }
    
    public override string ToString()
    {
        return $"{Rank.ToString()} of {Suit.ToString()} worth {CardValue} points";
    }
    
    public enum CardSuit
    {
        Clubs = 1,
        Diamonds = 2,
        Hearts = 3,
        Spades = 4
    }

    public enum CardRank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }
}