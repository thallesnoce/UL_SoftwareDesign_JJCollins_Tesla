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
    public class PackageBusinessLayer  //Subject: Package is being observed by interface Observer
    {
        private ArrayList observers;
        private int state;

        public int State { get => state; set => state = value; }

        public PackageBusinessLayer()
        {
            observers = new ArrayList();
        }

        public void registerObserver(Observer o) // Attach 
        {
            observers.Add(o);
        }

        public void removeObserver(Observer o) // Detach
        {
            int i = observers.IndexOf(o);
            if (i >= 0)
            {
                observers.Remove(i);
            }
        }

        public void notifyAllObservers() // Update
        {
            foreach (Observer observer in observers)
            {
                observer.updateState(state);
            }
        }

        public decimal CalculatePrice(int packageId, List<int> aditionalServices)
        {
            IPackage package = new PackageDataAccess().GetPackage(packageId);
            var packageFactory = new ConcretePackageFactory();

            foreach (var item in aditionalServices)
            {
                package = packageFactory.FactoryServiceMethod(package, item);
            }

            return package.GetPrice();
        }

        public Tuple<Boolean, string> BuyPackage(int packageId, int clientId, decimal price, int cardOptions, string cardNumber, string expirationDate, string cvc)
        {
            var buyPackage = new BuyPackageBusinessLayer();
            var result = buyPackage.EffectivePackageBuy(packageId, price, cardNumber, expirationDate, cvc);
            return result;
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

        public List<PackageEntity> InsertPackage(String Name, int PackageId, String Description, int Price, DateTime startDate, DateTime endDate)
        {
            var data = new PackageDataAccess();
            data.InsertPackage(Name, PackageId, Description, Price, startDate, endDate);
            return data.ListPackage();
        }

        public List<PackageEntity> EditPackage(String Name, int PackageId, String Description)
        {
            var data = new PackageDataAccess();
            data.EditPackage(Name, PackageId, Description);
            return data.ListPackage();
        }

        public List<PackageEntity> DeletePackage(int PackageId)
        {
            var data = new PackageDataAccess();
            data.DeletePackage(PackageId);
            return data.ListPackage();
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