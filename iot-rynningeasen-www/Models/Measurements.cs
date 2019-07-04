using System;

namespace IotRynningeasenWWW.Models
{
    public class Measurements
    {
        public State Temperature { get; set; }
        public State Pressure { get; set; }
        public State Humidity { get; set; }
    }

    public class State
    {
        public Value Current { get; set; }
        public Value AverageYesterday { get; set; }
        public Value AverageLastWeek { get; set; }
        public Value MaxLastWeek { get; set; }
        public Value MaxToday { get; set; }
        public Value MinLastWeek { get; set; }
        public Value MinToday { get; set; }
    }

    public class Value
    {
        public double What { get; set; }
        public DateTimeOffset When { get; set; } = DateTimeOffset.UtcNow;
    }
}
