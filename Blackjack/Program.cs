/*
 * TODO:
 * - Add a check for Ace value if score > 21
 * - Tidy up output formatting
 */

using System.Net.Mime;
using System.Runtime.CompilerServices;
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
    if (game.EvaluateScores(false))
    {
        Console.WriteLine("Starting new game...");
        Main();
    }

    Console.WriteLine("----- PLAYER HANDS -----");
    // Print each player's hand and score
    foreach (Player p in game.Players)
    {
        p.PrintPlayerHand();
    }
    Console.WriteLine();

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
                Console.WriteLine("----- DEALING -----");
                game.Deal(deck, user);
                Console.WriteLine();
                Console.WriteLine($"----- {user.Name}'s HAND -----");
                user.PrintPlayerHand();
                Console.WriteLine();
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
                Console.WriteLine("----- DEALING -----");
                game.Deal(deck, dealer);
                Console.WriteLine();
                Console.WriteLine($"----- {dealer.Name}'s HAND -----");
                dealer.PrintPlayerHand();
                Console.WriteLine();
            }
            else dealerStands = true;
        }

        // If both dealer and player stand
        if (playerStands == true && dealerStands == true)
        {
            // Check if there's a winner with true argument to check endgame scores

            game.EvaluateScores(true);

            Console.WriteLine("--------- END OF GAME ----------");
            Console.WriteLine();

            // Restart game
            PlayAgainPrompt();
        }

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