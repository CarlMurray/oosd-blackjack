﻿/*
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
    (Player user, Dealer dealer, Deck deck, Game game) = InitialiseGame();

    DealInitialHands(game, deck);

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

    playerStands = playOutPlayerTurn(game, deck, user);

    if (!game.EvaluateScores())
    {
        dealerStands = playOutPlayerTurn(game, deck, dealer);
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

        // Restart game
        PlayAgainPrompt();
    }

    PlayAgainPrompt();
}

static void PlayAgainPrompt()
{
    Console.WriteLine();
    Console.BackgroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("--------- END OF GAME ----------");
    Console.BackgroundColor = ConsoleColor.Black;

    Console.WriteLine();
    Console.Write("Do you want to play again? (y/n): ");
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

static (Player, Dealer, Deck, Game) InitialiseGame()
{
    // Clear console 
    Console.Clear();

    // Initialise players, game, deck
    Player user = new Player("Carl");
    Dealer dealer = new Dealer();
    Deck deck = new Deck();
    Game game = new Game([user, dealer]);
    return (user, dealer, deck, game);
}


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


static bool playOutPlayerTurn(Game game, Deck deck, Player player, bool playerStands = false)
{
    while (game.EvaluateScores() == false)
    {
        if (!playerStands)
        {
            // While player chooses to hit, keep looping
            if (player.HitOrStand() && game.EvaluateScores() == false)
            {
                Console.WriteLine("----- DEALING -----");
                game.Deal(deck, player);
                Console.WriteLine();
                game.Players[0].PrintPlayerHand();
                Console.WriteLine();
                game.Players[1].PrintPlayerHand();
            }
            else
            {
                playerStands = true;
                game.EvaluateScores();
                break;
            }
        }
    }
    return playerStands;
}

Main();