using System;
using System.Drawing;

namespace PersonalManagement.Models.virutalMethodTest
{
    public class Car : Vehicle
    {

        public Car(string color) : base(color, 4)
        {
            // do nothing
        }
        
        public void action()
        {
            this.drive();
            this.sound();
            this.smell();
            this.destroy();
        }
        
        public override void drive()
        {
            Console.WriteLine("Drive car " + this.wheelsCount);
        }

        // https://stackoverflow.com/questions/622132/what-are-virtual-methods
        // https://www.youtube.com/watch?v=6wfM2ng5tiU
        public virtual void sound()
        {
            Console.WriteLine("Virtueller Sound in der Oberklasse (Car)");
        }

        public void smell()
        {
            Console.WriteLine("Einfacher Geruch in der Oberklasse (Car)");
        }
        
    }
}