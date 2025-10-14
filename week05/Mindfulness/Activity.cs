using System;
using System.Threading;

namespace Mindfulness;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration; // in seconds

    protected static readonly Random Rng = new(); // shared random instance

    public Activity() { } // default constructor 
    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected int Duration => _duration;
    protected string Name => _name;
    protected string Description => _description;

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {Name} Activity.\n");
        Console.WriteLine(Description);
        Console.Write("\nHow many seconds would you like to do this activity? ");

        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a positive integer (seconds): ");
        }

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"\nWell done! You have completed {Duration} seconds of the {Name} Activity.");
        ShowSpinner(3);
        Console.WriteLine("Returning to menu...");
        ShowSpinner(2);
    }

    public void ShowSpinner(int seconds)
    {
        // Spinner animation 
        char[] frames = new[] { '|', '/', '-', '\\' };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        Console.Write(" ");
        while (DateTime.Now < end)
        {
            Console.Write("\b" + frames[i++ % frames.Length]);
            Thread.Sleep(150);
        }
        Console.Write("\b \b");
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    // ===== EXCEEDING REQUIREMENT (1): Session Logging =====
    // Each completed activity appends a line to "session_log.csv"
    // Format: timestamp, activity name, duration, optional extra info 
    protected void LogSession(string extra = "")
    {
        try
        {
            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss},{Name},{Duration},{extra}";
            System.IO.File.AppendAllLines("session_log.csv", new[] { line });
        }
        catch
        {
            // Silently ignore file I/O issues to prevent runtime crashes
        }
    }
}
