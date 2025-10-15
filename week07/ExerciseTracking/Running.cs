using System;

namespace ExerciseTracking
{
    public class Running : Activity
    {
        private double _distanceKm; // Distance provided by the user

        public Running(DateTime date, int minutes, double distanceKm)
            : base(date, minutes)
        {
            _distanceKm = distanceKm;
        }

        public override double GetDistanceKm() => _distanceKm;

        public override double GetSpeedKph()
        {
            // Speed (kph) = (distance / minutes) * 60
            return (_distanceKm / GetMinutes()) * 60.0;
        }

        public override double GetPaceMinPerKm()
        {
            // Pace (min/km) = minutes / distance
            return GetMinutes() / _distanceKm;
        }
    }
}
