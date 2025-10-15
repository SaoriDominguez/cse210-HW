using System;

namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int _laps; // Number of laps provided by the user
        private const double LapMeters = 50.0;

        public Swimming(DateTime date, int minutes, int laps)
            : base(date, minutes)
        {
            _laps = laps;
        }

        public override double GetDistanceKm()
        {
            // Distance (km) = laps * 50 / 1000
            return (_laps * LapMeters) / 1000.0;
        }

        public override double GetSpeedKph()
        {
            // Speed (kph) = (distance / minutes) * 60
            double km = GetDistanceKm();
            return (km / GetMinutes()) * 60.0;
        }

        public override double GetPaceMinPerKm()
        {
            // Pace (min/km) = minutes / distance
            double km = GetDistanceKm();
            return GetMinutes() / km;
        }
    }
}
