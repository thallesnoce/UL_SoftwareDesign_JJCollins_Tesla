using SoftwareDesign.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.ControllerLayer.Business
{
    public class EnquireBusinessLayer
    {
        public void CreateEnquire(int packageId, string message)
        {
            // add statement about what the observer need to do here

            /* Observer: EnquireColler
             * Subjects: Enquire information in packageDetail page
             * When client enters enquiries, the subjects will notify the obsever by using notifyObservers()
             */

       /* public interface SetEnquiry
        { public void setEnquiry(Package Id); }
        public interface GetEnquiry
        { public string getEnquiry(); }
        public interface Subject
        {
            public void registerObserver(Observer o);
            public void removeObserver(Observer o);
            public void notifyObservers();
        }
        public  class EnquireData implements (SetEnquiry, GetEnquiry, Subject)  {
             private ArrayList observers;
             private string Enquiry;
      
            public void EnquiryData()
       {
        observers = new ArrayList();
        }

    public void registerObserver(Observer o)
    {
        observers.add(o);
    }

    public void removeObserver(IObserver o)
    {
        int i = observers.indexOf(o);
        if (i >= 0) { observers.remove(i);
        }
    }

    public void notifyObservers()
    { 
        for (int i = 0; i < Observers.size(); i++)
        {
            Observer observer = (Observer)observer.get(i);
            observer.update(Enqure);
        }
    }

    public void EnquireChanged()
    {
        notifyObservers();
    }

    public void setEnquire(string Enquire) {
        this.Enqire = Enquire;
        EnquireChanged();
    }

    public string getEnquire()
    {
        return Enquire;
    }

    public interface DisplayElement
    {
        public void display();
    }

    public interface Observer
    {
        public void update(string Enquire);
    }

    public class EnruireDisplay implements Observer, DisplayElement {
        private string Enquire;
        private Subject EnquireData;

    public EnquireDisplay(Subject EnquireData)
    {
        this.EnquiryData = EnquireData;
        EnquireData.registerObserver(this);
    }

    public void update(string Enquire)
    {
        this.Enquire = Enquire;
        display();
    }

    public void display()
    {
        System.out.println("Your Enquire submission is done");
    }
}
*/


        new EnquireDataAccess().CreateEnquire(packageId,message);
      
        }
    }
}
