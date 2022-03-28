using System;

namespace PersonalManagement.Models.virutalMethodTest
{
    public class Audi : Car
    {
        public Audi() : base("blue")
        {
            
        }
        
        public override void sound()
        {
            Console.WriteLine("Overriden (virtuell) Sound in Kindklasse (Audi)");
        }

        public void smell()
        {
            Console.WriteLine("Einfach überladener Geruch der Kindklasse (Audi)");
        }
    }
}