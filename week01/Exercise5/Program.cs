using System;

class Program
{
    static void Main(string[] args)
    {
        // 1) Greet
        DisplayWelcome();

        // 2) Gather inputs
        string name = PromptUserName();
        int favorite = PromptUserNumber();

        // 3) Process
        int squared = SquareNumber(favorite);

        // 4) Output result
        DisplayResult(name, squared);
    }

    // Prints the welcome message
    static void DisplayWelcome()
    {
        // Match the sample output’s exact text/casing
        Console.WriteLine("Welcome to the program!");
    }

    // Asks and returns user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Asks and returns user's favorite number (as int)
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine();
        return int.Parse(input); // assumes valid integer input
    }

    // Returns n squared
    static int SquareNumber(int n)
    {
        return n * n;
    }

    // Prints "<name>, the square of your number is <squared>"
    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }
}
