using Blackjack;

Card card = new Card(3, 12);


Deck deck = new Deck();

for (int i = 0; i < 52; i++)
{
Console.WriteLine(deck.CardsInDeck[i]);
    
}

Console.WriteLine(deck.NumCardsInDeck);