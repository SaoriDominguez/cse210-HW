using System;

/// Base class: common state and interface for all goals.
public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    protected Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetName() => _shortName;

    /// Helper to expose the base point value (used by the manager for UI only).
    public int GetBasePoints() => _points;

    /// Default details string; derived classes may add more info.
    public virtual string GetDetailsString()
    {
        string box = IsComplete() ? "[X]" : "[ ]";
        return $"{box} {_shortName} ({_description})";
    }

    /// Record the event and return the points earned NOW (may include bonus).
    public abstract int RecordEvent();

    /// Whether this goal is now complete.
    public abstract bool IsComplete();

    /// Compact line to save this goal to a file.
    public abstract string GetStringRepresentation();
}
