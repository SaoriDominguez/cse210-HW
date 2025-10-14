using System;

/// A goal that never completes; awards points every time.
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) {}

    public override int RecordEvent() => _points;

    public override bool IsComplete() => false;

    public override string GetStringRepresentation()
        => $"EternalGoal|{_shortName}|{_description}|{_points}";
}
