using SoftwareDesign.Model;
using SoftwareDesign.Model.DataModel;
using System;
using System.Collections.Generic;

namespace SoftwareDesign.ControllerLayer.Business
{
    public class PackageBusinessLayer
    {
        //All the logic will be here.
        //Controller
        public void BuyPackage(int transportPartnerId, Destination destination, Hotel hotel)
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
        public Package ViewPackage()
        {
            return new PackageRepository().GetPackage(1);
        }
    }
}