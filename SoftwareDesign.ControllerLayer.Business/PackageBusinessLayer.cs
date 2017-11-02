using SoftwareDesign.Model;
using SoftwareDesign.Model.DataModel;
using System;
using System.Collections.Generic;

namespace SoftwareDesign.ControllerLayer.Business
{
    public class PackageBusinessLayer
    {
        public void BuyPackage(int packageId, int clientId)
        {
            throw new NotImplementedException();
        }

        public List<Package> SearchPackage(int transportId, int hotelId, DateTime startDate, DateTime endDate)
        {
            //TODO: Use a design pattern to create an instance of Repository
            return new PackageRepository().SearchPackage(transportId, hotelId, startDate, endDate);
        }

        public Package GetPackage(int packageId)
        {
            throw new NotImplementedException();
        }

        public Package ViewPackage(int packageId)
        {
            return new PackageRepository().GetPackage(packageId);
        }
    }
}