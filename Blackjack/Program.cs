using Blackjack;



Player user = new Player("Carl");
Player dealer = new Player("Dealer");
Game game = new Game([user, dealer]);
Deck deck = new Deck();


// Deal two cards to each player in order
for (int i = 0; i < 2; i++)
{
    foreach (Player p in game.Players)
    {
        game.Deal(deck, p);
    }
}

Console.WriteLine($"Your hand: {user.Hand[0]}, {user.Hand[1]}");
Console.WriteLine($"Dealer's hand: {dealer.Hand[0]}, {dealer.Hand[1]}");


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

