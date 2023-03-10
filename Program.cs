using System;
namespace introApp;

class Program
{
    static string correctWord = "hangman";
    static char[]? letters;
    static Player? player;

    static void Main(string[] args)
    {
        StartGame();
        PlayGame();
        EndGame();
    }

    //Start game method
    private static void StartGame()
    {
        letters = new char[correctWord.Length];
        for (int i = 0; i < correctWord.Length; i++)
        {
            letters[i] = '_';
        }
        AskForUserName();
    }

    // Method to ask for user's name
    static void AskForUserName()
    {
        Console.WriteLine("Enter your name: ");
        string? input = Console.ReadLine();

        if (input?.Length >= 2)
        {
            //If name valid, save name
            player = new Player(input);
        }
        else
        {
            ThrowError("Error: Name too short");
            AskForUserName();
        }
    }

    // Method to play game
    static void PlayGame() 
    {
        do
        {
        Console.Clear();
        DisplayMaskedWord();
        char guessedLetter = AskForLetter();
        CheckLetter(guessedLetter);
        } while (correctWord != new string (letters));

        Console.Clear();
    }

    //Method to check if letter guessed is in the correct word
    private static void CheckLetter(char guessedLetter)
    {
        for (int i = 0; i < letters?.Length; i++)
        {
            if(guessedLetter == correctWord[i])
            {
                letters[i] = guessedLetter;
                player.score++;
            }
        }
    }

    //Method to display masked word
    static void DisplayMaskedWord()
    {
        for (int i = 0; i < letters?.Length; i++)
        {
            Console.WriteLine(letters[i]);
        }
        Console.WriteLine();
    }  

    //Method to ask for letter
    static char AskForLetter()
    {
        string? input;
        Console.WriteLine("Enter a letter:");
        do
        {
            input = Console.ReadLine();
        } while (input?.Length != 1);

        var letter = input[0];

        if (!player.guessedLetters.Contains(letter))
        {
            player.guessedLetters.Add(letter);
        }

        return letter;
    }

    //Method to end game
    static void EndGame()
    {
        Console.WriteLine("Game Over");
        Console.WriteLine($"Thanks for playing {player?.name}");
        Console.WriteLine($"Guesses: {player?.guessedLetters.Count} score: {player?.score}");
    }

    static void ThrowError(string errorMessage)
    {
        Console.WriteLine(errorMessage);
        return;
    }
}