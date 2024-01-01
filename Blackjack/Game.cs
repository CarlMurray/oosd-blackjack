namespace Blackjack;

internal class Game
{
    private const int MAX_SCORE = 21;

    public Player[] Players = new Player[2];

    public Game(Player[] players)
    {
        Players = players;
    }

    /*
     * Description:
     *      Gets last card in deck, copies to player hand, removes from deck.
     *
     * Parameters:
     *      Deck deck: The deck to deal from.
     *      Player player: The player to deal card to.
     */
    public void Deal(Deck deck, Player player)
    {
        // Get last item in deck array, copy to player hand, remove from deck.
        var card = deck.CardsInDeck.Last();

        player.AddCardToHand(card);
        deck.RemoveTopCard();

        // If it's the Dealer's first card being dealt (i.e. the Hole card)
        if (player.Hand.IndexOf(card) == 0 && player.GetType() == typeof(Dealer))
        {
            Console.WriteLine($"Hole card dealt to {player.Name}");
        }
        else
        {
            Console.WriteLine($"{card} dealt to {player.Name}");
        }
    }

    public bool EvaluateScores(bool bothStand = false)
    {
        bool isDraw = false;
        bool playerWins = false;
        bool dealerWins = false;

        if (bothStand)
        {
            if (Players[0].Score > Players[1].Score)
            {
                Console.WriteLine($"{Players[0].Name} wins. (High score)");
                playerWins = true;
                return playerWins;
            }

            if (Players[0].Score < Players[1].Score)
            {
                Console.WriteLine($"{Players[1].Name} wins. (High score)");
                dealerWins = true;
                return dealerWins;
            }

            Console.WriteLine("Game is a draw (Equal score)");


            isDraw = true;
            return isDraw;
        }

        // If player and dealer have 21
        if (Players[0].Score == Players[1].Score && Players[0].Score == MAX_SCORE)
        {
            Console.WriteLine("Game is a draw (Both players scored 21)");
            isDraw = true;
            return isDraw;
        }
        // If player has 21 and dealer does not

        if (Players[0].Score == MAX_SCORE && Players[0].Score > Players[1].Score)
        {
            Console.WriteLine($"{Players[0].Name} wins. (Scored 21)");
            playerWins = true;
            return playerWins;
        }
        // If dealer has 21 and player does not

        if (Players[1].Score == MAX_SCORE && Players[1].Score > Players[0].Score)
        {
            Console.WriteLine($"{Players[1].Name} wins. (Scored 21)");
            dealerWins = true;
            return dealerWins;
        }
        // If player busts and dealer doesn't

        if (Players[0].Score > MAX_SCORE && Players[1].Score <= MAX_SCORE)
        {
            Console.WriteLine($"{Players[1].Name} wins. ({Players[0].Name} bust)");
            dealerWins = true;
            return dealerWins;
        }
        // If dealer busts and player doesn't

        if (Players[1].Score > MAX_SCORE && Players[0].Score <= MAX_SCORE)
        {
            Console.WriteLine($"{Players[0].Name} wins. ({Players[1].Name} bust)");
            playerWins = true;
            return playerWins;
        }
        // If both player and dealer bust, draw

        if (Players[0].Score > MAX_SCORE && Players[1].Score > MAX_SCORE)
        {
            Console.WriteLine("Game is a draw (Both players bust)");
            isDraw = true;
            return isDraw;
        }

        return false;
    }
}