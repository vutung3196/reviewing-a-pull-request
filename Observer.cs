using System;
using System.Collections.Generic;
using System.Threading;

// Observer is a behavioral design pattern that
// lets you define a subscription
// mechanism to notify multiple objects about any
// events that happen to the object they’re observing.
namespace DesignPatterns
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);

        void Detach(IObserver observer);

        void Notify();
    }

    public class Subject : ISubject
    {
        public int State { get; set; } = -0;

        // List of subscribers
        private readonly IList<IObserver> _observers = new List<IObserver>();


        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attach an observer.");
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            Console.WriteLine("Subject: Detach an observer.");
            _observers.Remove(observer);
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers.");
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nSubject: I'm doing something important.");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: My state has just changed to: " + this.State);
            this.Notify();
        }
    }   

    class ConcreteExampleA : IObserver
    {
        public void Update(ISubject subject)
        {
            if (((Subject) subject).State < 3)
            {
                Console.WriteLine("ConcreteObserverA: Reacted to the event.");
            }
        }
    }

    class ConcreteExampleB : IObserver
    {
        public void Update(ISubject subject)
        {
            if (((Subject) subject).State is 0 or >= 2)
            {
                Console.WriteLine("ConcreteObserverB: Reacted to the event.");
            }
        }
    }


    static class ObserverProgram
    {
        public static void Run()
        {
            var subject = new Subject();
            var observerA = new ConcreteExampleA();
            subject.Attach(observerA);

            var observerB = new ConcreteExampleB();
            subject.Attach(observerB);

            subject.SomeBusinessLogic();
            subject.SomeBusinessLogic();

            subject.Detach(observerB);

            subject.SomeBusinessLogic();
        }
    }
}