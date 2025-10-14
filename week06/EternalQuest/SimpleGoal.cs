using System;

/// A goal completed once; further records award 0.
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    // Extra constructor used when loading from file.
    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete) return 0;
        _isComplete = true;
        return _points;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentation()
        => $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
}
