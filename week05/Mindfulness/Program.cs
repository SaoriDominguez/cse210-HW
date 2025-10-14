using System;

namespace Mindfulness
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflecting Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                if (choice == "1") new BreathingActivity().Run();
                else if (choice == "2") new ReflectingActivity().Run();
                else if (choice == "3") new ListingActivity().Run();
                else if (choice == "4") break;
                else
                {
                    Console.WriteLine("Invalid option. Press Enter to continue...");
                    Console.ReadLine();
                }
            }

            // ===== EXCEEDING REQUIREMENTS =====
            // (1) Session Logging:
            //     Each time an activity ends, a line is appended to "session_log.csv"
            //     with timestamp, activity name, duration, and (for Listing) item count.
            //
            // (2) Non-repeating:
            //     Prompts and questions are shuffled and consumed without repetition
            //     within the same session for a better user experience.
        }
    }
}
