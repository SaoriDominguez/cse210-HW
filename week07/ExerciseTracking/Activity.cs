using System;
using System.Globalization;

namespace ExerciseTracking
{
    // Abstract base class: stores date, duration, and defines abstract calculation methods
    public abstract class Activity
    {
        private DateTime _date;
        private int _minutes;

        protected Activity(DateTime date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        public DateTime GetDate() => _date;
        public int GetMinutes() => _minutes;

        // Abstract methods that derived classes must implement
        public abstract double GetDistanceKm();
        public abstract double GetSpeedKph();
        public abstract double GetPaceMinPerKm();

        // Virtual summary method that uses polymorphism
        public virtual string GetSummary()
        {
            string dateStr = _date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            return $"{dateStr} {GetType().Name} ({_minutes} min): " +
                   $"Distance {GetDistanceKm():0.##} km, " +
                   $"Speed {GetSpeedKph():0.##} kph, " +
                   $"Pace: {GetPaceMinPerKm():0.##} min per km";
        }
    }
}
