using System.Collections.Generic;

namespace ObserverTest.interfaces
{
    public abstract class Subject
    {
        private List<Observer> _observers = new List<Observer>();

        public void attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        protected void notify()
        {
            foreach (Observer o in _observers)
            {
                o.update();
            }
        }
    }
}