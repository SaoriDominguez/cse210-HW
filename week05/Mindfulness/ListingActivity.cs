using System;
using System.Collections.Generic;
using System.Linq;

namespace Mindfulness;

public class ListingActivity : Activity
{
    private int _count;
    private readonly List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    // ===== EXCEEDING REQUIREMENT (2): Non-repeating =====
    private Queue<string> _promptDeck;

    public ListingActivity()
        : base("Listing",
            "This activity will help you reflect on the good things in your life by having you list as many as you can in a certain area.")
    {
        _promptDeck = new Queue<string>(_prompts.OrderBy(_ => Rng.Next()));
    }

    private string DrawPrompt()
    {
        if (_promptDeck.Count == 0)
            _promptDeck = new Queue<string>(_prompts.OrderBy(_ => Rng.Next()));
        return _promptDeck.Dequeue();
    }

    public List<string> GetListFromUser()
    {
        var results = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(Duration);

        Console.WriteLine("\nStart listing (press Enter after each item):");
        while (DateTime.Now < end)
        {
            if (Console.KeyAvailable)
            {
                string line = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                    results.Add(line.Trim());
            }
        }
        return results;
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nList responses to the following prompt:");
        Console.WriteLine($"> {DrawPrompt()}");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        var responses = GetListFromUser();
        _count = responses.Count;

        Console.WriteLine($"\nYou listed {_count} items:");
        foreach (var r in responses)
            Console.WriteLine($"- {r}");

        LogSession($"count={_count}");
        DisplayEndingMessage();
    }
}
