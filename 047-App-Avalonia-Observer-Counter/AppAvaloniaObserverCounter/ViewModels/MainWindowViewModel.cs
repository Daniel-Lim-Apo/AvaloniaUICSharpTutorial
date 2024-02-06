using AppAvaloniaObserverCounter.Interfaces;
using System.Collections.Generic;

namespace AppAvaloniaObserverCounter.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public Counter counter = new Counter();
    }

    public class Counter : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private int count = 0;

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(count);
            }
        }

        public void Increment()
        {
            count++;
            Notify();
        }
    }
}
