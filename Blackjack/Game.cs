namespace Blackjack;

internal class Game
{
    // Set max score for game of blackjack
    private const int MAX_SCORE = 21;

    // Stores players in a game
    internal Player[] Players = new Player[2];

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
        Card card = deck.CardsInDeck.Last();
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

    /*
     * Description:
     *      Checks to determine if there's a winner.
     *
     * Parameters:
     *      bool bothStand: Passed when both players choose to stand so scores can be compared. Default is false.
     */
    public bool EvaluateScores(bool bothStand = false, bool isInitialRound = false)
    {
        bool isDraw = false;
        bool playerWins = false;
        bool dealerWins = false;

        // If it's initial round (user's turn), don't check the dealers score
        if (isInitialRound)
        {
            // If player busts
            if (Players[0].Score > MAX_SCORE)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Players[1].Name} wins. ({Players[0].Name} bust)");
                Console.ForegroundColor = ConsoleColor.White;
                dealerWins = true;
                return dealerWins;
            }
            // If player and dealer hit 21
            else if (Players[0].Score == MAX_SCORE && Players[1].Score == MAX_SCORE)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Game is a draw (Both players scored 21)");
                Console.ForegroundColor = ConsoleColor.White;
                isDraw = true;
                return isDraw;
            }
            // If only player hits 21
            else if (Players[0].Score == MAX_SCORE)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Players[0].Name} wins. (Scored 21)");
                Console.ForegroundColor = ConsoleColor.White;
                playerWins = true;
                return playerWins;
            }

            return false;
        }

        // If both players stand, compare scores to check winner
        if (bothStand)
        {
            // If user score higher than dealer score
            if (Players[0].Score > Players[1].Score)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Players[0].Name} wins. (High score)");
                Console.ForegroundColor = ConsoleColor.White;
                playerWins = true;
                return playerWins;
            }

            // If user score less than dealer score
            if (Players[0].Score < Players[1].Score)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Players[1].Name} wins. (High score)");
                Console.ForegroundColor = ConsoleColor.White;
                dealerWins = true;
                return dealerWins;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Game is a draw (Equal score)");
            Console.ForegroundColor = ConsoleColor.White;
            isDraw = true;
            return isDraw;
        }

        // If player and dealer have 21
        if (Players[0].Score == Players[1].Score && Players[0].Score == MAX_SCORE)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Game is a draw (Both players scored 21)");
            Console.ForegroundColor = ConsoleColor.White;
            isDraw = true;
            return isDraw;
        }

        // If player has 21 and dealer does not
        if (Players[0].Score == MAX_SCORE && Players[0].Score > Players[1].Score)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Players[0].Name} wins. (Scored 21)");
            Console.ForegroundColor = ConsoleColor.White;
            playerWins = true;
            return playerWins;
        }

        // If dealer has 21 and player does not
        if (Players[1].Score == MAX_SCORE && Players[1].Score > Players[0].Score)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Players[1].Name} wins. (Scored 21)");
            Console.ForegroundColor = ConsoleColor.White;
            dealerWins = true;
            return dealerWins;
        }

        // If player busts and dealer doesn't
        if (Players[0].Score > MAX_SCORE && Players[1].Score <= MAX_SCORE)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Players[1].Name} wins. ({Players[0].Name} bust)");
            Console.ForegroundColor = ConsoleColor.White;
            dealerWins = true;
            return dealerWins;
        }

        // If dealer busts and player doesn't
        if (Players[1].Score > MAX_SCORE && Players[0].Score <= MAX_SCORE)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Players[0].Name} wins. ({Players[1].Name} bust)");
            Console.ForegroundColor = ConsoleColor.White;
            playerWins = true;
            return playerWins;
        }

        // If both player and dealer bust, draw
        if (Players[0].Score > MAX_SCORE && Players[1].Score > MAX_SCORE)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Game is a draw (Both players bust)");
            Console.ForegroundColor = ConsoleColor.White;
            isDraw = true;
            return isDraw;
        }

        return false;
    }

}