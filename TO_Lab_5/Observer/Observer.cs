using System.Collections.Generic;

namespace TO_Lab_5.Observer
{
    public interface IObserver
    {
        // Receive update from subject
        List<FireTruck> SignalNewIncident();
    }
    
    public interface ISubject
    {
        // Attach an observer to the subject.
        void Attach(IObserver observer);

        // Notify all observers about an event.
        List<FireTruck> Notify();
    }
}