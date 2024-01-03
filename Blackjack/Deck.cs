namespace Blackjack;

public class Deck
{
    private const int NUMBER_OF_SUITS = 4; // Clubs, Diamonds, Hearts, Spades
    private const int NUMBER_OF_CARDS = 52; // Standard deck
    private const int MIN_CARD_VALUE = 2; // CardRank enum starts at 2 (Two)
    private const int MAX_CARD_VALUE = 14; // CardRank enum ends at 14 (Ace)

    // Array to store cards in the deck
    internal Card[] CardsInDeck = new Card[NUMBER_OF_CARDS];

    // Constructor
    public Deck()
    {
        int index = 0;

        // For each suit
        for (int j = 1; j <= NUMBER_OF_SUITS; j++)
        {
            // For each card in suit
            for (int i = MIN_CARD_VALUE; i <= MAX_CARD_VALUE; i++)
            {
                // Create card and add to deck
                Card card = new(j, i);
                CardsInDeck[index] = card;
                index++;
            }
        }
        // Shuffle the deck on creation
        Shuffle();
    }

    // Method to shuffle deck of cards
    public void Shuffle()
    {
        Random.Shared.Shuffle(CardsInDeck);
    }

    // Method removes top card from deck. Used when dealing cards in Game.
    public void RemoveTopCard()
    {
        Card topCard = CardsInDeck.Last();
        // Update CardsInDeck without topCard
        CardsInDeck = CardsInDeck.Where(x => x != topCard).ToArray();
    }
}