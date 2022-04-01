using System;
using ObserverTest.interfaces;
using ObserverTest.subjects;

namespace ObserverTest.observers
{
    public class FirstConcreteObserver : Observer
    {
        private readonly string key = "first_concrete_observer";
        private ConcreteSubject subject; // Override subject type of the parent class
        
        private string state = "nothing here";

        public FirstConcreteObserver(ConcreteSubject subject) : base(subject)
        {
            this.subject = subject;
        }

        public override void update()
        {
            Console.WriteLine("Debug: " + this.subject.getState());
            this.state = this.subject.getState();
        }

        public void printState()
        {
            Console.WriteLine(this.key + " | " + this.state);
        }
    }
}