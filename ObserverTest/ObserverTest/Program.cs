using System;
using ObserverTest.observers;
using ObserverTest.subjects;

namespace ObserverTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-- Start ---------");
            
            // Create Subject
            ConcreteSubject subject = new ConcreteSubject("Hello World");
            
            // Create Observers
            FirstConcreteObserver firstConcreteObserver = new FirstConcreteObserver(subject);
            SecondConcreteObserver secondConcreteObserver = new SecondConcreteObserver(subject);

            subject.printState();
            firstConcreteObserver.printState();
            secondConcreteObserver.printState();
            
            Console.WriteLine("---");

            // Update Subject value
            subject.setState("Jeff");

            subject.printState();
            firstConcreteObserver.printState();
            secondConcreteObserver.printState();

            Console.WriteLine("---");
            
            // Detach Observers
            subject.detach(firstConcreteObserver);
            subject.detach(secondConcreteObserver);

            // Update Subject value
            subject.setState("Frank");

            subject.printState();
            firstConcreteObserver.printState();
            secondConcreteObserver.printState();
            
            
            Console.WriteLine("-- End -----------");
            
        }
    }
}