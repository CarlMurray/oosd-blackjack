namespace Blackjack;

public class Deck
{
    private const int NUMBER_OF_SUITS = 4;
    private const int NUMBER_OF_CARDS = 52;
    private const int MIN_CARD_VALUE = 2;
    private const int MAX_CARD_VALUE = 2;
    
    
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
                Card card = new Card(j, i);
                CardsInDeck[index] = card;
                index++;
            }
        }
    }
}