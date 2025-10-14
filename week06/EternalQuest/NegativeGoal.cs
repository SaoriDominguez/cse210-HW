using System;

/// A goal that removes points when recorded (bad habits).
public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int penalty)
        : base(name, description, penalty) { }

    public override int RecordEvent()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"⚠️  You lost {_points} points for '{_shortName}'. Keep trying!");
        Console.ResetColor();
        return -_points;
    }

    public override bool IsComplete() => false;

    public override string GetStringRepresentation()
        => $"NegativeGoal|{_shortName}|{_description}|{_points}";
}
