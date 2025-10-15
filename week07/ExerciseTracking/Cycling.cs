using System;

namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private double _speedKph; // Speed provided by the user

        public Cycling(DateTime date, int minutes, double speedKph)
            : base(date, minutes)
        {
            _speedKph = speedKph;
        }

        public override double GetDistanceKm()
        {
            // Distance = speed * (minutes / 60)
            return _speedKph * (GetMinutes() / 60.0);
        }

        public override double GetSpeedKph() => _speedKph;

        public override double GetPaceMinPerKm()
        {
            // Pace = 60 / speed
            return 60.0 / _speedKph;
        }
    }
}
