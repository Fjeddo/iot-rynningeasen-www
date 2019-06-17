using System.Collections.Generic;

namespace IoTRynningeasenWWW
{
    public class SensorGroup
    {
        public string Name { get; set; }
        public Dictionary<string, double> Values { get; set; }
    }
}