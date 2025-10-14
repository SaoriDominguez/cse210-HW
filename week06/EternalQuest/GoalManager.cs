using System;
using System.Collections.Generic;
using System.IO;

/// Encapsulates menu loop, score, badges, saving/loading, etc.
public class GoalManager
{
    private readonly List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    // --- Creativity extras state ---
    private bool _hasEarnedFirstChecklistBadge = false;
    private int _eternalGoalStreak = 0;
    private DateTime _lastEternalRecordedDate = DateTime.MinValue;

    public void Start()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine($"You have {_score} points.  Level: {_score / 1000}");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Display Score");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine() ?? "";
            Console.WriteLine();

            switch (choice.Trim())
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": DisplayPlayerInfo(); break;
                case "7": return;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }

    public void DisplayPlayerInfo()
        => Console.WriteLine($"Your current score is: {_score} (Level {_score / 1000})");

    public void ListGoalDetails()
    {
        if (_goals.Count == 0) { Console.WriteLine("No goals yet."); return; }
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine() ?? "";

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine() ?? "";
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine() ?? "0");

        Goal g;
        if (type == "1")
        {
            g = new SimpleGoal(name, desc, points);
        }
        else if (type == "2")
        {
            g = new EternalGoal(name, desc, points);
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine() ?? "1");
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine() ?? "0");
            g = new ChecklistGoal(name, desc, points, target, bonus);
        }
        else if (type == "4")
        {
            // Here, 'points' is actually a penalty.
            g = new NegativeGoal(name, desc, points);
        }
        else
        {
            Console.WriteLine("Unknown type.");
            return;
        }

        _goals.Add(g);
        Console.WriteLine("Goal created.");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0) { Console.WriteLine("No goals to record."); return; }

        Console.WriteLine("Which goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");

        Console.Write("Enter number: ");
        if (!int.TryParse(Console.ReadLine(), out int idx) || idx < 1 || idx > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Goal g = _goals[idx - 1];
        int earned = g.RecordEvent();        // polymorphic call
        _score += earned;

        // ✨ Confetti: if points > base points (bonus on checklist finish)
        if (earned > g.GetBasePoints())
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("🎉 BONUS ACHIEVED! Confetti falls from the sky! 🎉");
            Console.ResetColor();
        }

        if (earned >= 0)
            Console.WriteLine($"You earned {earned} points.");
        else
            Console.WriteLine($"Points change: {earned}.");

        // 🏅 First checklist badge
        if (g is ChecklistGoal checklist && checklist.IsComplete() && !_hasEarnedFirstChecklistBadge)
        {
            _hasEarnedFirstChecklistBadge = true;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("🏅 You earned the 'Consistency Hero' badge for completing your first checklist goal!");
            Console.ResetColor();
        }

        // 🔁 Eternal goal streak tracking
        if (g is EternalGoal)
        {
            if (_lastEternalRecordedDate == DateTime.MinValue)
            {
                _eternalGoalStreak = 1;
            }
            else
            {
                int gapDays = (DateTime.Now.Date - _lastEternalRecordedDate.Date).Days;
                _eternalGoalStreak = (gapDays <= 1) ? _eternalGoalStreak + 1 : 1;
            }
            _lastEternalRecordedDate = DateTime.Now.Date;

            if (_eternalGoalStreak == 7)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("🌟 You earned the 'Eternal Devotion' badge for a 7-day streak!");
                Console.ResetColor();
            }
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine() ?? "goals.txt";

        using (var sw = new StreamWriter(filename))
        {
            sw.WriteLine(_score);
            foreach (Goal g in _goals)
                sw.WriteLine(g.GetStringRepresentation());
            // (Badges/streak are not required to persist for the assignment)
        }
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine() ?? "goals.txt";
        if (!File.Exists(filename)) { Console.WriteLine("File not found."); return; }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0) { Console.WriteLine("Empty file."); return; }

        _score = int.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split('|');
            string type = parts[0];

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                    break;

                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;

                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(
                        parts[1], parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5]),
                        int.Parse(parts[6])));
                    break;

                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
            }
        }
        Console.WriteLine("Goals loaded.");
    }
}
