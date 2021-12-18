namespace TrafficLightUI
{
    public enum TrafficLightStatus
    {
        Off,
        Standby, // Blink Yellow
        Stop, // Red
        Prepare, // Red/Yellow
        Go, // Green
        Warning // Yellow
    }
}