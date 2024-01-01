namespace Blackjack;

public class Deck
{
    private const int NUMBER_OF_SUITS = 4; // Clubs, Diamonds, Hearts, Spades
    private const int NUMBER_OF_CARDS = 52; // Standard deck
    private const int MIN_CARD_VALUE = 2; // CardRank enum starts at 2 (Two)
    private const int MAX_CARD_VALUE = 14; // CardRank enum ends at 14 (Ace)


    // GETS NUMBER OF CARDS IN THE CURRENT DECK
    public int NumCardsInDeck
    {
        get
        {
            int count = 0;
            foreach (Card x in CardsInDeck)
            {
                if (x is not null)
                {
                    count++;
                }
            }

            return count;
        }
    }

    public Card[] CardsInDeck = new Card[NUMBER_OF_CARDS];

    // CONSTRUCTOR
    public Deck()
    {
        // ARRAY INDEX
        int index = 0;

        // FOR EACH SUIT
        for (int j = 1; j <= NUMBER_OF_SUITS; j++)
        {
            // FOR EACH CARD IN SUIT
            for (int i = MIN_CARD_VALUE; i <= MAX_CARD_VALUE; i++)
            {
                // CREATE AND ADD CARD TO DECK
                Card card = new(j, i);
                CardsInDeck[index] = card;
                index++;
            }
        }
        Shuffle();
    }

    public void Shuffle()
    {
        Random.Shared.Shuffle(CardsInDeck);
    }

    // Description: Removes top card from deck. Used when dealing cards in Game.
    public void RemoveTopCard()
    {
        Card topCard = CardsInDeck.Last();
        // CREATE NEW ARRAY WITHOUT topCard
        CardsInDeck = CardsInDeck.Where(x => x != topCard).ToArray();
    }
}