using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main()
        {
            // Create a list of activities (demonstrates polymorphism)
            List<Activity> activities = new List<Activity>
            {
                // Running: 30 min, 4.8 km
                new Running(new DateTime(2022, 11, 03), 30, 4.8),

                // Cycling: 40 min, 27 kph
                new Cycling(new DateTime(2022, 11, 05), 40, 27.0),

                // Swimming: 25 min, 30 laps (1.5 km)
                new Swimming(new DateTime(2022, 11, 07), 25, 30)
            };

            // Loop through and display the summaries
            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
