using System;
using ObserverTest.interfaces;

namespace ObserverTest.subjects
{
    public class ConcreteSubject : Subject
    {
        private readonly string key = "concrete_subject";
        
        private string state;

        public ConcreteSubject(string initialState)
        {
            this.state = initialState;
        }

        public string getState()
        {
            return this.state;
        }

        public void setState(string value)
        {
            this.state = value;
            this.notify();
        }

        public void printState()
        {
            Console.WriteLine(this.key + " | " + this.state);
        }
    }
}