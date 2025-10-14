using System;
using System.Collections.Generic;
using System.Linq;

namespace Mindfulness;

public class ReflectingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    // ===== EXCEEDING REQUIREMENT (2): Non-repeating =====
    private Queue<string> _promptDeck;
    private Queue<string> _questionDeck;

    public ReflectingActivity()
        : base("Reflecting",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. It helps you recognize your inner power and how you can use it in other aspects of your life.")
    {
        _promptDeck = new Queue<string>(_prompts.OrderBy(_ => Rng.Next()));
        _questionDeck = new Queue<string>(_questions.OrderBy(_ => Rng.Next()));
    }

    private string DrawPrompt()
    {
        if (_promptDeck.Count == 0)
            _promptDeck = new Queue<string>(_prompts.OrderBy(_ => Rng.Next()));
        return _promptDeck.Dequeue();
    }

    private string DrawQuestion()
    {
        if (_questionDeck.Count == 0)
            _questionDeck = new Queue<string>(_questions.OrderBy(_ => Rng.Next()));
        return _questionDeck.Dequeue();
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"> {DrawPrompt()}");
        Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
        Console.ReadLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
    }

    public void DisplayQuestions()
    {
        DateTime end = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < end)
        {
            Console.Write($"\n{DrawQuestion()} ");
            ShowSpinner(6);
        }
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        DisplayQuestions();

        LogSession(); // save session record
        DisplayEndingMessage();
    }
}
