using System;
using PersonalManagement.Models.virutalMethodTest;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            Audi audi = new Audi();
            audi.action();
            
            Console.WriteLine("---");
            Car car = audi;
            car.smell();
            car.sound(); // virtual
            Console.WriteLine("---");
            audi.smell();
            audi.sound(); // virtual
            
        }
    }
}