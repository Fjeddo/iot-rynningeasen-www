using IoTRynningeasenWWW;

namespace IotRynningeasenWWW.Models
{
    public class Pressure : ISensor
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
}