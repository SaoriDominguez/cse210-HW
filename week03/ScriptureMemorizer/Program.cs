using System;
using System.Collections.Generic;

/// W03 Scripture Memorizer
/// --------------------------------------------------------------
/// Exceeds requirements:
/// 1) Hides only words that are currently visible (stretch).
/// 2) Preserves punctuation when hiding (underscores replace only letters).
/// 3) Uses a library of multiple scriptures and randomly selects one
///    at program start (extra creativity).
/// --------------------------------------------------------------
class Program
{
    static void Main(string[] args)
    {
        // Create a small library of scriptures
        List<Scripture> library = new List<Scripture>();
        library.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
        ));
        library.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
        ));
        library.Add(new Scripture(
            new Reference("Mosiah", 2, 17),
            "When ye are in the service of your fellow beings ye are only in the service of your God."
        ));

        // Pick one scripture at random
        Random rng = new Random();
        int index = rng.Next(library.Count);
        Scripture scripture = library[index];
        Reference reference = scripture.GetReference();

        const int WORDS_PER_STEP = 3;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(reference.GetDisplayText());
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to end.");

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Program will end.");
                break;
            }

            string input = Console.ReadLine() ?? string.Empty;
            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(WORDS_PER_STEP);
        }
    }
}
