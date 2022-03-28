using System;

namespace PersonalManagement.Models.virutalMethodTest
{
    public abstract class Vehicle
    {
        private string color;
        protected int wheelsCount;

        public Vehicle(string color, int wheelsCount)
        {
            this.color = color;
            this.wheelsCount = wheelsCount;
        }

        public abstract void drive();

        public void destroy()
        {
            Console.WriteLine("Destroy in der Basisklasse (Vehicle)");
        }
    }
}