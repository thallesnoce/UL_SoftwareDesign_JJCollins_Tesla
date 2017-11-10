using SoftwareDesign.DataAccessLayer.DataModel;
using SoftwareDesign.Entities;
using SoftwareDesign.Entities.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SoftwareDesign.DataAccessLayer
{
    /// <summary>
    /// All data are mockup from flatfile using the "FlatFileHelper"
    /// 
    /// For all Where clauses, we are using LINQ.
    /// </summary>
    public class PackageDataAccess
    {
        public List<PackageEntity> SearchPackage(int transportId, int destinationId, int hotelId, DateTime startDate, DateTime endDate)
        {
            //Getting the DBContext through a singleton design pattern
            //SingletonDBContext.GetContext().Packages.ToList();

            var data = FlatFileHelper.ListAllPackages();
            return data.Where(x =>
                        (transportId <= 0 || x.Transport.TransportId == transportId)
                        && (destinationId <= 0 || x.Destination.DestinationId == destinationId)
                        && (hotelId <= 0 || x.Hotel.HotelId == hotelId)
            //&&  x.StartDate >=startDate 
            //&& x.EndDate <= endDate
            )
            .Select(x => x)
            .ToList();
        }

        public List<PackageEntity> ListPackage()
        {
            throw new NotImplementedException();
        }

        public PackageEntity GetPackage(int packageId)
        {
            var data = FlatFileHelper.ListAllPackages();
            return data.Where(x => x.PackageId == packageId).FirstOrDefault();
        }
    }
}