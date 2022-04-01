namespace ObserverTest.interfaces
{
    public abstract class Observer
    {
        // protected Subject subject;

        public Observer(Subject subject)
        {
            // this.subject = subject;
            // this.subject.attach(this);
            subject.attach(this);
        }
        
        public abstract void update();
    }
}