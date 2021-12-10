using System;

namespace TrafficLight
{
    class Program
    {
        static TrafficLight trafficLight = new TrafficLight();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            switchStatus();
            
            Console.WriteLine("Start Traffic Light");
            trafficLight.start();
            switchStatus();
            switchStatus();
            switchStatus();
            switchStatus();
            switchStatus();
        }

        static void switchStatus()
        {
            trafficLight.switchStatus();
            Console.WriteLine("Current Status " + trafficLight.getEnumName(trafficLight.getCurrentStatus()));
        }
    }
}