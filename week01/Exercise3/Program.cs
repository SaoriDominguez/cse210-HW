using System;

class Program
{
    static void Main(string[] args)
    {
        // Play the whole game, and ask to play again at the end
        string playAgain;
        do
        {
        
            Random rng = new Random();
            int magicNumber = rng.Next(1, 101);

            
            int guessCount = 0;
            int guess = -1;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                guess = int.Parse(input);
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

           
            Console.WriteLine($"Number of guesses: {guessCount}");

            //git Ask to play again (stretch)
            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine().Trim().ToLower();
            Console.WriteLine();

        } while (playAgain == "yes");
    }
}
