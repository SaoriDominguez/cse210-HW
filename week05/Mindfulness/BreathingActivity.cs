using System;

namespace Mindfulness;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing",
            "This activity will help you relax by guiding you through slow, deep breathing. Clear your mind and focus on your breath.")
    { }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime end = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < end)
        {
            Console.Write("Breathe in... ");
            ShowCountDown(4);
            if (DateTime.Now >= end) break;

            Console.Write("Breathe out... ");
            ShowCountDown(6);
        }

        LogSession(); // save session record
        DisplayEndingMessage();
    }
}
