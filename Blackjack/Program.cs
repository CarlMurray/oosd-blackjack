/*
 * README
 *
 * Program emulates the game of Blackjack.
 *
 * Game rules and logic implemented:
 *
 * Info:
 * - Ace is worth 11 or 1 - value is automatically set throughout the game to whichever is in favour of the user.
 * - Ace value can change throughout the game i.e. Ace may initially be 11, but if the user hits the Ace may change to 1 if required.
 *
 * Game flow:
 * - Create 2 players - user and dealer. Game is restricted to two players only.
 * - Create a standard deck of 52 cards and shuffle before play.
 * - When game starts, deal two (2) cards to each player in alternating sequence, starting with user.
 * - Dealer's first card is the 'hole card' i.e. it's value is hidden.
 * - Evaluate scores to see if there is a winner after initial deal - if so, end game.
 * - Prompt user for decision - hit (deal another card) or stand (keep current hand and end turn).
 * - Evaluate scores to check if user is bust or hits 21 - if so, end game.
 * - Dealer's turn:
 * - Reveal hole card and evaluate score.
 * - Dealer must hit until score of >= 17 is reached, then stand.
 * - Evaluate scores to check for winner.
 * - Prompt user to play again.
 *
 */

using Blackjack;

static void Main()
{
    // Clear console 
    Console.Clear();

    // Initialise players, game, deck
    Player user = new Player("Carl");
    Dealer dealer = new Dealer();
    Game game = new Game([user, dealer]);
    Deck deck = new Deck();


    Console.WriteLine("----- DEALING HANDS -----");
    // Deal two cards to each player in order
    for (int i = 0; i < 2; i++)
    {
        foreach (Player p in game.Players)
        {
            game.Deal(deck, p);
        }
    }
    Console.WriteLine();

    // Check if either player is bust or 21
    if (game.EvaluateScores())
    {
        Console.WriteLine("Starting new game...");
        Main();
    }

    Console.WriteLine("----- PLAYER HANDS -----");
    bool isInitialRound = true;
    // Print each player's hand and score
    foreach (Player p in game.Players)
    {
        p.PrintPlayerHand(isInitialRound);
    }
    Console.WriteLine();

    // Variable to exclude player from play if stand
    bool playerStands = false;
    bool dealerStands = false;
    bool gameHasWinner = false;

    while (game.EvaluateScores() == false)
    {
        // If player has not already chosen to stand
        if (!playerStands)
        {
            // While player chooses to hit, keep looping
            if (user.HitOrStand() && game.EvaluateScores() == false)
            {
                Console.WriteLine("----- DEALING -----");
                game.Deal(deck, user);
                Console.WriteLine();
                Console.WriteLine($"----- {user.Name}'s HAND -----");
                user.PrintPlayerHand();
                Console.WriteLine();
                Console.WriteLine($"----- {dealer.Name}'s HAND -----");
                dealer.PrintPlayerHand(true);
                Console.WriteLine();
            }
            else
            {
                playerStands = true;
                game.EvaluateScores();
                break;
            }
        }
        // Check if there's a winner
        if (game.EvaluateScores())
        {
            gameHasWinner = true;
            break;
        }
    }

    if (gameHasWinner == false)
    {


        while (game.EvaluateScores() == false)
        {
            // If player has not already chosen to stand
            if (!dealerStands)
            {
                // Hit returns true. If true, deal card.
                if (dealer.HitOrStand() && game.EvaluateScores() == false)
                {
                    Console.WriteLine("----- DEALING -----");
                    game.Deal(deck, dealer);
                    Console.WriteLine();
                    Console.WriteLine($"----- {user.Name}'s HAND -----");
                    user.PrintPlayerHand();
                    Console.WriteLine();
                    Console.WriteLine($"----- {dealer.Name}'s HAND -----");
                    dealer.PrintPlayerHand();
                    Console.WriteLine();
                }
                else
                {
                    dealerStands = true;
                    game.EvaluateScores();
                    break;
                }
            }

            // Check if there's a winner
            if (game.EvaluateScores())
            {
                break;
            }
        }
    }

    // If both dealer and player stand
    if (playerStands == true && dealerStands == true)
    {
        foreach (var player in game.Players)
        {
            player.PrintPlayerHand();
        }
        // Check if there's a winner with true argument to check endgame scores
        game.EvaluateScores(true);

        Console.WriteLine("--------- END OF GAME ----------");
        Console.WriteLine();

        // Restart game
        PlayAgainPrompt();
    }
    PlayAgainPrompt();
}

static void PlayAgainPrompt()
{
    Console.WriteLine("Do you want to play again? (y/n): ");
    string choice;
    do
    {
        choice = Console.ReadLine();
    } while (!new[] { "y", "n" }.Contains(choice.ToLower()));

    switch (choice)
    {
        case "y":
            Main();
            break;
        case "n":
            Console.WriteLine("Game over.");
            Environment.Exit(0);
            break;
    }

}

Main();