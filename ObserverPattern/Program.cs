using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ObserverPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IvanSubject ivan = new IvanSubject();
            ivan.Age = 10;
            IvanObserver ivanObs = new IvanObserver("ivan_observer", ivan);
            ivan.Attach(ivanObs);
            ivan.Age = 11;
            Console.ReadKey();
        }
    }

    public abstract class Subject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Observer> observers;

        public Subject()
        {
            this.observers = new List<Observer>();
            PropertyChanged += Subject_PropertyChanged;
        }

        /// <summary>
        /// Handles the PropertyChanged event of the Subject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void Subject_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine(String.Format("prop changed: {0}", e.PropertyName));
            this.Notify();
        }

        public void Attach(Observer obs)
        {
            this.observers.Add(obs);

        }

        public void Detach(Observer obs)
        {
            observers.Remove(obs);
        }

        public void Notify()
        {
            foreach (Observer obs in this.observers)
            {
                obs.Update();
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public abstract class Observer
    {
        public abstract void Update();
    }

    public class IvanSubject : Subject
    {
        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }
    }

    public class IvanObserver : Observer
    {
        private string name;
        private IvanSubject subj;
        private int age;

        public IvanObserver(string name, IvanSubject subj)
        {
            this.name = name;
            this.subj = subj;
        }

        public IvanSubject Subj
        {
            get { return subj; }
            set { subj = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public override void Update()
        {
            Console.WriteLine(String.Format("observer: {0} - Age {1}", this.name, this.subj.Age));
            age = this.subj.Age;
        }
    }
}
