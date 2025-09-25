using System;
using System.Collections.Generic;

namespace Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            var journal = new Journal();
            var rng = new Random();

            var prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };

            int choice = -1;
            while (choice != 5)
            {
                Console.WriteLine("\nJournal Menu");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Quit");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a valid number (1-5).");
                    continue;
                }

                if (choice == 1)
                {
                    string prompt = prompts[rng.Next(prompts.Count)];
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("> Your entry: ");
                    string response = Console.ReadLine() ?? "";

                    var entry = new Entry(prompt, response);
                    journal.AddEntry(entry);
                    Console.WriteLine("Entry added.");
                }
                else if (choice == 2)
                {
                    Console.WriteLine();
                    journal.DisplayAll();
                }
                else if (choice == 3)
                {
                    Console.Write("Enter filename to save (e.g., journal.txt): ");
                    string filename = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(filename))
                        journal.SaveToFile(filename);
                }
                else if (choice == 4)
                {
                    Console.Write("Enter filename to load (e.g., journal.txt): ");
                    string filename = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(filename))
                        journal.LoadFromFile(filename);
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Goodbye!");
                }
                else
                {
                    Console.WriteLine("Please choose an option between 1 and 5.");
                }
            }
        }
    }
}
