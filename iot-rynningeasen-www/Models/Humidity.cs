using IoTRynningeasenWWW;

namespace IotRynningeasenWWW.Models
{
    public class Humidity : ISensor
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
}