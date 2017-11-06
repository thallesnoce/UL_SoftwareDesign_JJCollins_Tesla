using SoftwareDesign.DataAccessLayer;
using SoftwareDesign.DataAccessLayer.DataModel;
using SoftwareDesign.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using static SoftwareDesign.Entities.Enums.Enums;

namespace SoftwareDesign.ControllerLayer.Business//Design Pattern about observer should be impelemented here.
{
    public class PackageBusinessLayer
    {
        public decimal CalculatePrice(int packageId, List<int> aditionalServices)
        {
            var packageData = new PackageDataAccess().GetPackage(packageId);
            IPackage package = new PackageEntity() { PackageId = packageData.PackageId, Price = packageData.Price };

            foreach (var item in aditionalServices)
            {
                //TODO: Use the Factory Design Pattern
                if (item == (int)ServiceType.HonneyMoon)
                {
                    package = new HoneyMoonPackage(package);
                }
                else if (item == (int)ServiceType.BachelorPartyHoliday)
                {
                    package = new BachelorPartyPackage(package);
                }
                if (item == (int)ServiceType.BirthDayParty)
                {
                    package = new BirthDayPartyPackage(package);
                }
            }

            return package.GetPrice();
        }

        public Tuple<Boolean, string> BuyPackage(int packageId, int clientId, decimal price, int cardOptions, string cardNumber, string expirationDate, string cvc)
        {
            //TODO: Implement the Design Patter Interceptor here.

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:58561/");
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"CrediCard/PostRegisterBuy/{cardNumber}/{expirationDate}/{cvc}/{price}").Result;
            var isSuccess = false;

            var message = string.Empty;
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

        public List<PackageEntity> SearchPackage(int transportId, int destinationId, int hotelId,  DateTime startDate, DateTime endDate)
        {
            //TODO: Use a design pattern to create an instance of Repository
            return new PackageDataAccess().SearchPackage(transportId, destinationId, hotelId, startDate, endDate);
        }

        public PackageEntity GetPackage(int packageId)
        {
            throw new NotImplementedException();
        }

        public PackageEntity ViewPackage(int packageId)
        {
            return new PackageDataAccess().GetPackage(packageId);
        }
    }
}