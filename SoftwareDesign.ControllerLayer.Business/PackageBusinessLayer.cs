using SoftwareDesign.DataAccessLayer;
using SoftwareDesign.DataAccessLayer.DataModel;
using SoftwareDesign.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using static SoftwareDesign.Entities.Enums.Enums;
using System.Collections;


namespace SoftwareDesign.ControllerLayer.Business
{
    public class PackageBusinessLayer  //Subject
    {
        private ArrayList observers;
        private int state;

        public int State { get => state; set => state = value; }

        public PackageBusinessLayer()
        {
            observers = new ArrayList();
        }

        public void registerObserver(Observer o)
        {
            observers.Add(o);
        }

        public void removeObserver(Observer o)
        {
            int i = observers.IndexOf(o);
            if (i >= 0)
            {
                observers.Remove(i);
            }
        }

        public void notifyAllObservers()
        {
            foreach (Observer observer in observers)
            {
                observer.updateState(state);
            }
        }

        public Tuple<Boolean, string> BuyPackage(int packageId, int clientId, decimal price, int cardOptions, string cardNumber, string expirationDate, string cvc)
        {
            //var packageData = new UserDataAccess().GetPackage(packageId);
            //TODO: Implement the clientId

            //TODO: Implement the Design Patter Interceptor here.
            var bp = new BuyPackageBusinessLayer();
            return bp.EffectivePackageBuy(price, cardOptions, cardNumber, expirationDate, cvc);
        }

        public List<PackageEntity> SearchPackage(int transportId, int destinationId, int hotelId, DateTime startDate, DateTime endDate)
        {
            //TODO: Use a design pattern to create an instance of Repository
            return new PackageDataAccess().SearchPackage(transportId, destinationId, hotelId, startDate, endDate);
        }

        // Monica and hang use case implementation 11/11/2017 
        public List<PackageEntity> DetailsPackage(String Name, int PackageId, String Description, int Price, DateTime startDate, DateTime endDate)
        {
            //TODO: Use a design pattern to create an instance of Repository
            return new PackageDataAccess().DetailsPackage(Name, PackageId, Description, Price, startDate, endDate);
        }

        public PackageEntity GetPackage(int packageId)
        {
            throw new NotImplementedException();
        }

        public PackageEntity ViewPackage(int packageId)
        {
            state = packageId;
            ConcreteObserver co = new ConcreteObserver();
            registerObserver(co);
            notifyAllObservers();
            return new PackageDataAccess().GetPackage(packageId);
        }
    }
}