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

        public int State { get => state; set => state = value;  }
        
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
            if (i>=0)
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
        public decimal CalculatePrice(int packageId, List<int> aditionalServices)
        {
            IPackage package = new PackageDataAccess().GetPackage(packageId);

            foreach (var item in aditionalServices)
            {
                //PackageFactory.CreatePackageServiceInstace(package, item);
            }

            return package.GetPrice();
        }

        public Tuple<Boolean, string> BuyPackage(int packageId, int clientId, decimal price, int cardOptions, string cardNumber, string expirationDate, string cvc)
        {
            //var packageData = new UserDataAccess().GetPackage(packageId);
            //TODO: Implement the clientId

            //TODO: Implement the Design Patter Interceptor here.

            var result = CheckWithThirdPartCrediCard(price, cardNumber, expirationDate, cvc);

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
            //TODO: Use a design pattern to create an instance of Repository
            PackageDataAccess.InsertPackage(Name, PackageId, Description, Price, startDate,endDate);
            return null;
        }
        public List<PackageEntity> EditPackage(String Name, int PackageId, String Description)
        {
            //TODO: Use a design pattern to create an instance of Repository
            return null;// new PackageDataAccess().EditPackage(Name, PackageId,Description);
        }
        public List<PackageEntity> DeletePackage(int PackageId)
        {
            //TODO: Use a design pattern to create an instance of Repository
            return null;// new PackageDataAccess().DeletePackage( PackageId);
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

        /// <summary>
        /// This Method Simulate a comunication with the Third Part Software. 
        /// In this case Credit Card Operator System.
        /// Was Created a API to fake this comunication.
        /// </summary>
        /// <param name="price"></param>
        /// <param name="cardNumber"></param>
        /// <param name="expirationDate"></param>
        /// <param name="cvc"></param>
        /// <returns></returns>
        private static Tuple<bool, string> CheckWithThirdPartCrediCard(decimal price, string cardNumber, string expirationDate, string cvc)
        {
            bool isSuccess = false;
            string message = string.Empty;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:58561/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"CrediCard/PostRegisterBuy/{cardNumber}/{expirationDate}/{cvc}/{price}").Result;
            if (response.IsSuccessStatusCode)
            {
                var transactionStatus = response.Content.ReadAsStringAsync().Result.Split('|');

                isSuccess = Convert.ToBoolean(transactionStatus[0]);
                message = transactionStatus[1];
            }
            else
            {
                isSuccess = false;
                message = "Error when trying to connect to the Credit Card Company.";
            }

            return new Tuple<bool, string>(isSuccess, message);
        }
    }
}