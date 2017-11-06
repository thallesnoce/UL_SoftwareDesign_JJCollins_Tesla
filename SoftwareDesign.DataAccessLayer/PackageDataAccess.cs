using SoftwareDesign.DataAccessLayer.DataModel;
using SoftwareDesign.Entities;
using SoftwareDesign.Entities.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareDesign.DataAccessLayer
{
    /// <summary>
    /// All data are mockup from flatfile using the "FlatFileHelper"
    /// </summary>
    public class PackageDataAccess
    {
        public List<PackageEntity> SearchPackage(int transportId, int destinationId, int hotelId, DateTime startDate, DateTime endDate)
        {
            //linq
            var data = FlatFileHelper.ListAllPackages();
            return data.Where(x => x.Transport.TransportId == transportId 
            &&  x.Destination.DestinationId == destinationId 
            &&  x.Hotel. HotelId == hotelId 
            &&  x.StartDate >=startDate 
            && x.EndDate <= endDate).Select(x => x).ToList();
        }

        public PackageEntity GetPackage(int packageId)
        {
            var data = FlatFileHelper.ListAllPackages();
            return data.Where(x => x.PackageId == packageId).FirstOrDefault();
        }
    }
}