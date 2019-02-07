using System;

namespace iot_rynningeasen_www.DataAccess.Entities
{
    public class Sensors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset LastSignOfLife { get; set; }
    }
}