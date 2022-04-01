using System;
using ObserverTest.interfaces;
using ObserverTest.subjects;

namespace ObserverTest.observers
{
    public class SecondConcreteObserver : Observer
    {
        private readonly string key = "second_concrete_observer";
        private ConcreteSubject subject; // Override subject type of the parent class
        
        private string state = "nothing here";

        public SecondConcreteObserver(ConcreteSubject subject) : base(subject)
        {
            this.subject = subject;
        }

        public override void update()
        {
            this.state = this.subject.getState();
        }

        public void printState()
        {
            Console.WriteLine(this.key + " | " + this.state);
        }
    }
}