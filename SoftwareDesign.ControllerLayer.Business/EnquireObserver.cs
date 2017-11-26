using SoftwareDesign.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.ControllerLayer.Business
{
    /* Observer: EnquireColler
     * Subjects: Enquire information in packageDetail page
     * When client enters enquiries, the subjects will notify the obsever by using notifyObservers()
     */
     /*
      Please Monica, comment every class with what is role in the Design Pattern.
      This will help other to stuff for the exam, the presentation and the interview to match the class diagram and the code.
         */

    public interface ISetEnquire
    {
        void SetEnquire(string message);
    }

    public interface IGetEnquire
    {
        string GetEnquire();
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    public class EnquireData : ISetEnquire, IGetEnquire, ISubject
    {
        private ArrayList observers;
        private string Enquire;

        public EnquireData()
        {
            observers = new ArrayList();
        }

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            int i = observers.IndexOf(o);
            if (i >= 0)
            {
                observers.Remove(i);
            }
        }

        public void NotifyObservers()
        {
            for (int i = 0; i < observers.Count; i++)
            {
                IObserver observer = (IObserver)observers[i];
                observer.update(Enquire);
            }
        }

        public void EnquireChanged()
        {
            NotifyObservers();
        }

        public void SetEnquire(string Enquire)
        {
            this.Enquire = Enquire;
            EnquireChanged();
        }

        public string GetEnquire()
        {
            return Enquire;
        }
    }
    public interface IDisplayElement
    {
        void display();
    }

    public interface IObserver
    {
        void update(string Enquire);
    }

    public class EnquireDisplay : IObserver, IDisplayElement
    {
        private string Enquire;
        private ISubject EnquireData;

        public EnquireDisplay(ISubject EnquireData)
        {
            this.EnquireData = EnquireData;
            EnquireData.RegisterObserver(this);
        }

        public void update(string Enquire)
        {
            this.Enquire = Enquire;
            display();
        }

        public void display()
        {
            //("Your Enquire submission is done");
        }
    }
}
