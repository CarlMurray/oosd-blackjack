# About
- Submission for Object Oriented Software Design Semester 1 CA3

# The game of Blackjack

- In the game of Blackjack, players aim to achieve a hand value as close to 21 as possible without exceeding it. 
- Each player is dealt two cards initially.
- Face cards have a value of 10. 
- An Ace can be either 1 or 11. 
- Players can choose to "hit" to receive additional cards or "stand" to keep their current hand. 
- If a player exceeds 21, they bust and lose the round. 
- The dealer follows a set of rules for drawing cards. 
- The game involves strategic decisions based on the player's hand and the dealer's visible card. 
- The ultimate goal is to beat the dealer without busting

# Program Logic
- Program emulates the game of Blackjack.

**Game flow:**
- Create 2 players - user and dealer. Note: Game is restricted to two players only.
- Create a standard deck of 52 cards and shuffle before play.
- When game starts, deal two (2) cards to each player in alternating sequence, starting with user.
- Dealer's first card is the 'hole card' i.e. it's value is hidden.
- Evaluate scores to see if there is a winner after initial deal - if so, end game.
- Prompt user for decision - hit (deal another card) or stand (keep current hand and end turn).
- Evaluate scores to check if user is bust or hits 21 - if so, end game.
- Dealer's turn:
- Reveal hole card and evaluate score.
- Dealer must hit until score of >= 17 is reached, then stand.
- Evaluate scores to check for winner.
- Prompt user to play again.

**Handling Aces:**
- Ace is worth 1 or 11 - value is automatically set throughout the game to whichever is in favour of the player.
- The value of any Aces in a player's hand is re-evaluated after each "hit" by checking if the new score is greater than 21.
- Ace value can change throughout the game i.e. Ace may initially be 11, but if the user hits the Ace may change to 1 if required.

# Programming Concepts Implemented

## Classes

The following classes are implemented:

### `Player`

- Represents a player in the game
- Properties and variables:
	- `string Name` - Name of player
    - `List<Card> Hand = [];` - Player's hand, containing cards
    - `int Score` - Player's score
- Methods
    - `AddCardToHand` - Adds a card to the player's hand. Adjusts score. Evaluates value of Ace.
    - `HitOrStand` - Prompts user to hit or stand.
    - `PrintPlayerHand` - Prints cards in player's hand to console.

### `Dealer`
- Inherits from `Player`.
- Class created to handle logic for Dealer's rules for drawing cards.
- Hit if score < 17, else stand.

### `Deck`
- Represents a standard deck of 52 cards.
- Properties and variables:
	- `Card CardsInDeck[]` - The cards remaining in the deck. An array of length 52.
- Methods
    - `Shuffle` - Shuffles the deck into random order.
    - `RemoveTopCard` - Gets the last ('top') card in the deck, removes it, and updates `CardsInDeck`.

### `Card`
- Represents a single card.
- Properties and variables:
   - `CardValue` - The point value of a card.
   - `IsAce` - A boolean used to determine the `CardValue` of an Ace.
   - `IsFacecard` - A boolean used to determine the `CardValue` of a face card.
   - `Rank` - Stores the card's rank in relation to the `CardRank` enumeration.
   - `Suit` - Stores the card's suit in relation to the `CardSuit` enumeration.
- Methods:
   - `ToString` - Prints the rank, suit and value of a card.

### `Game` 
- Represents a single game/round.
- Properties and variables:
    - `Player Players[]` - An array containing players in the game.
- Methods:
    - `Deal` - Deals a card to a player and prints card to console.
    - `EvaluateScores` - Checks if there's a winner.

## Methods
`Program.cs` contains the following methods:
- `Main` method which handles the overall game flow.
- `PlayAgainPrompt` - Prompts player to play again or exit.
- `InitialiseGame` - Sets up game with players and deck.
- `PlayOutPlayerTurn` - Handles the logic for a player's turn, evaluating the score after each action.

## Array
- An Array is created as a variable of the `Game` class to store the two (2) players in the game (User and Dealer).
- A fifty-two (52) element Array stores 52 cards in a standard deck of cards used in the game.

## List
- A list stores the cards of each player's hand. A list was used over an array as the amount of elements contained in a hand can vary.

## Random
- A feature of .NET 8, the Random.Shared.Shuffle() method is used to shuffle the deck of cards array in a random order.

## Loop
Loops are used throughout the project, including `for`, `foreach`, `while` and `do...while`. Some notable examples include:
- The Main method is contained in a `do...while` loop which loops until the player decides to not play again.
- Nested `for` loops are used in the `Deck` constructor to create a full deck of 52 cards - 4 suits with 13 cards per suit.
- A `while` loop is used in the `Player.AddCardToHand` method to iterate through each Ace in the player's hand while their score is > 21, and to change the value to 1.
- `while` loops are used throughout the program to get valid user input, for example in the `Player.HitOrStand` and `PlayAgainPrompt` methods.
- A `while` loop is used in conjunction with the `Game.EvaluateScores` method throughout the program to check if the game has a winner after each action.

## Conditional Statements
- A `switch` statement is used in the `PlayAgainPrompt` method when checking user input.
- `if` statements are used throughout the program to determine logic to follow if the game has a winner and what to output to the console for each result, such as in the `Game.EvaluateScores` method
- An `if` statement is used in the `Player.PrintPlayerHand` and `Game.Deal` methods to ensure that the Dealer's first card is concealed from the player (the 'hole card').

## Enumeration
- `enum`s are used in the `Card` class and used in conjunction with an `if` statement to determine the score value for each card in the deck. 

# Extra Feature
- The program correctly handles the Dealer's "Hole card" in line with Blackjack rules, by dealing this card face down initially to add an element of uncertainty to the game, and then revealing the card when it's the Dealer's turn.