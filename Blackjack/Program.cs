/*
 * TODO:
 * - Add a check for Ace value if score > 21
 * - Tidy up output formatting
 */

using Blackjack;

static void Main()
{
    // Initialise players, game, deck
    Player user = new Player("Carl");
    Dealer dealer = new Dealer();
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

    // Check if either player is bust or 21
    if (game.EvaluateScores(false))
    {
        Console.WriteLine("Starting new game...");
        Main();
    }

    // Print each player's score
    Console.WriteLine($"Your hand: {user.Hand[0]}, {user.Hand[1]}");
    Console.WriteLine($"Dealer's hand: {dealer.Hand[0]}, {dealer.Hand[1]}");

    // Variable to exclude player from play if stand
    bool playerStands = false;
    bool dealerStands = false;

    while (game.EvaluateScores(false) == false)
    {
        // If player has not already chosen to stand
        if (!playerStands)
        {
            // Hit returns true. If true, deal card.
            if (user.HitOrStand())
            {
                game.Deal(deck, user);
            }
            else playerStands = true;
        }

        // Check if there's a winner
        if (game.EvaluateScores(false))
        {
            break;
        }

        // If player has not already chosen to stand
        if (!dealerStands)
        {
            // Hit returns true. If true, deal card.
            if (dealer.HitOrStand())
            {
                game.Deal(deck, dealer);
            }
            else dealerStands = true;
        }

        // If both dealer and player stand
        if (playerStands == true && dealerStands == true)
        {
            // Check if there's a winner with true argument to check endgame scores
            game.EvaluateScores(true);
            // Restart game
            Main();
        }

    }

    while (game.EvaluateScores(false) == false) ;

    // Restart game
    Main();
}

Main();