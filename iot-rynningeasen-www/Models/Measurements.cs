using System;

namespace IotRynningeasenWWW.Models
{
    public class Measurements
    {
        public State Temperature { get; set; } = new State();
        public State Pressure { get; set; } = new State();
        public State Humidity { get; set; } = new State();
    }

    public class State
    {
        public Value Current { get; set; } = new Value();
        public Value AverageYesterday { get; set; } = new Value();
        public Value AverageLastWeek { get; set; } = new Value();
        public Value MaxLastWeek { get; set; } = new Value();
        public Value MaxToday { get; set; } = new Value();
        public Value MinLastWeek { get; set; } = new Value();
        public Value MinToday { get; set; } = new Value();
    }

    public class Value
    {
        public void Set(double value)
        {
            What = value;
            When = DateTimeOffset.UtcNow;
        }

        public string ToClientString()
        {
            return double.IsNaN(What) ? "waiting..." : $"{What:F1}";
        }

        public double What { get; set; } = double.NaN;
        public DateTimeOffset When { get; set; } = DateTimeOffset.UtcNow;
    }
}
