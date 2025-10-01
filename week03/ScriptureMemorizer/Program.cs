using System;

/// W03 Scripture Memorizer
/// Exceeds requirements (explain for rubric #10):
/// 1) Hide only words that are currently visible (stretch).
///    - Implemented in Scripture.HideRandomWords(...) by selecting
///      from visible words only.
/// 2) Preserve punctuation while hiding: underscores replace only
///    letters; punctuation marks remain (Word.GetDisplayText()).

class Program
{
    static void Main(string[] args)
    {
        // Example scripture: Proverbs 3:5-6
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";

        Scripture scripture = new Scripture(reference, text);

        const int WORDS_PER_STEP = 3;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(reference.GetDisplayText());
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to end.");

            if (scripture.IsCompletelyHidden())
            {
                // Final required display with all words hidden
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
