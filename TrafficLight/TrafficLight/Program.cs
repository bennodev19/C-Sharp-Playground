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
            Console.WriteLine("After Start: " + trafficLight.getEnumName(trafficLight.getCurrentStatus()));
            for (int i = 0; i < 10; i++)
            {
                switchStatus();
            }
            trafficLight.stop();
            Console.WriteLine("After Stop: " + trafficLight.getEnumName(trafficLight.getCurrentStatus()));
        }

        static void switchStatus()
        {
            trafficLight.switchStatus();
            Console.WriteLine("Current Status " + trafficLight.getEnumName(trafficLight.getCurrentStatus()));
        }
    }
}