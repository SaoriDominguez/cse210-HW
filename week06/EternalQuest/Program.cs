using System;

/// Eternal Quest — base requirements + creativity extras.
///
/// *** Creativity Features (beyond base requirements) ***
/// 1) Badge system:
///    - "Consistency Hero" for completing your first ChecklistGoal.
///    - "Eternal Devotion" for a 7-day streak recording an EternalGoal.
/// 2) NegativeGoal type: lets the user lose points for bad habits.
/// 3) Confetti celebration text (colorful console) when a bonus is earned.

public class Program
{
    public static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
