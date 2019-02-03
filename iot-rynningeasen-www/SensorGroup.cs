using System.Collections.Generic;

namespace iot_rynningeasen_www
{
    public class SensorGroup
    {
        public string Name { get; set; }
        public Dictionary<string, double> Values { get; set; }
    }
}