using Blackjack;

Player user = new Player("Carl");
Player dealer = new Player("Dealer");
Game game = new Game([user, dealer]);
Deck deck = new Deck();

// Deal two cards to each player in order
for (int i = 0; i < 2; i++)
{
    game.Deal(deck, user);
    game.Deal(deck, dealer);
}

Console.WriteLine(user.Hand[0]);
Console.WriteLine(user.Hand[1]);


//for (int i = 0; i < 52; i++)
//{
//    Console.WriteLine(deck.CardsInDeck[i]);

//}

//Console.WriteLine(deck.NumCardsInDeck);

//deck.Shuffle();

//for (int i = 0; i < 52; i++)
//{
//    Console.WriteLine(deck.CardsInDeck[i]);

//}

