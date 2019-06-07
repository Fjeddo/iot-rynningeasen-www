namespace iot_rynningeasen_www
{
    public interface ISensor
    {
        string Name { get; }
        double Value { get; }
    }
}