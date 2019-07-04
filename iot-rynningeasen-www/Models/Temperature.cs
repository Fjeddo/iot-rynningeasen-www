using IoTRynningeasenWWW;

namespace IotRynningeasenWWW.Models
{
    public class Temperature : ISensor
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
}