/*
 * ----------------------------------------
 * ----------------------------------------
 * See README.MD for detailed documentation.
 * ----------------------------------------
 * ----------------------------------------
 */

using Blackjack;

// Loops game until player chooses not to play again
do
{
    // Init game
    (Player user, Dealer dealer, Deck deck, Game game) = InitialiseGame();
    DealInitialHands(game, deck);

    // Check if either player is bust or 21
    if (game.EvaluateScores())
    {
        Console.WriteLine("Starting new game...");
        continue;
    }

    Console.WriteLine("----- PLAYER HANDS -----");
    bool isInitialRound = true;
    // Print each player's hand and score
    foreach (Player p in game.Players)
    {
        p.PrintPlayerHand(isInitialRound);
    }
    Console.WriteLine();

    // Variable to end player's turn if stands
    bool playerStands = false;
    bool dealerStands = false;

    // Play out player's turn until they stand
    playerStands = playOutPlayerTurn(game, deck, user);

    // If player doesn't 21 or bust, dealer's turn
    if (!game.EvaluateScores())
    {
        dealerStands = playOutPlayerTurn(game, deck, dealer);
    }

    // If both dealer and player stand (neither player 21 nor bust)
    if (playerStands == true && dealerStands == true)
    {
        foreach (Player player in game.Players)
        {
            player.PrintPlayerHand();
        }
        // Check if there's a winner with true argument to check endgame scores
        game.EvaluateScores(true);

    }

} while (PlayAgainPrompt());

// Method prompts player to play again at game end
static bool PlayAgainPrompt()
{
    Console.WriteLine();
    Console.BackgroundColor = ConsoleColor.DarkRed;
    Console.Write("--------- END OF GAME ----------");
    Console.BackgroundColor = ConsoleColor.Black;

    Console.WriteLine();
    string choice;
    // Prompt user for valid input
    do
    {
        Console.Write("Do you want to play again? (y/n): ");
        choice = Console.ReadLine();
    } while (!new[] { "y", "n" }.Contains(choice.ToLower()));

    switch (choice)
    {
        case "y":
            return true;
            break;
        case "n":
            Console.WriteLine("Game over.");
            Environment.Exit(0);
            break;
    }

    return false;
}
// Method for initialising a game with players and deck
static (Player, Dealer, Deck, Game) InitialiseGame()
{
    // Clear console (when there's a previous game still visible)
    Console.Clear();

    // Initialise players, game, deck
    Player user = new("Carl");
    Dealer dealer = new();
    Deck deck = new();
    Game game = new([user, dealer]);
    return (user, dealer, deck, game);
}

// Method for dealing first two cards to each player
static void DealInitialHands(Game game, Deck deck)
{
    Console.WriteLine("----- DEALING HANDS -----");

    // Deal two cards to each player in alternating sequence
    for (int i = 0; i < 2; i++)
    {
        foreach (Player p in game.Players)
        {
            game.Deal(deck, p);
        }
    }

    Console.WriteLine();
}

// Method for handling logic for a player's turn
static bool playOutPlayerTurn(Game game, Deck deck, Player player, bool playerStands = false)
{
    // While there is no winner
    while (game.EvaluateScores() == false)
    {
        // If the player has not chosen to stand
        if (!playerStands)
        {
            // While player chooses to hit, keep looping
            if (player.HitOrStand() && game.EvaluateScores() == false)
            {
                // Print dealt card and current hand
                Console.WriteLine("----- DEALING -----");
                game.Deal(deck, player);
                Console.WriteLine();
                game.Players[0].PrintPlayerHand();
                Console.WriteLine();
                game.Players[1].PrintPlayerHand();
            }
            else
            {
                // Else if player stands, eval scores and exit loop
                playerStands = true;
                game.EvaluateScores();
                break;
            }
        }
    }
    return playerStands;
}
