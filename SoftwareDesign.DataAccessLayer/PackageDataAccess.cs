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
            var a = data.Where(x =>
                          (transportId <= 0 || x.Transport.TransportId == transportId)
                          && (destinationId <= 0 || x.Destination.DestinationId == destinationId)
                          && (hotelId <= 0 || x.Hotel.HotelId == hotelId)
            //&&  x.StartDate >=startDate 
            //&& x.EndDate <= endDate
            )
            .Select(x => x)
            .ToList();
            return a;
        }

        /// <summary>
        /// by monica and hang 11/11/2017
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="PackageId"></param>
        /// <param name="Description"></param>
        /// <param name="Price"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<PackageEntity> DetailsPackage(String Name, int PackageId, String Description, int Price, DateTime startDate, DateTime endDate)

        {
            var data = FlatFileHelper.ListAllPackages();
            return data.Select(x => x).ToList();
        }

        public PackageEntity AddPackage(String Name, int PackageId, String Description, int Price, DateTime startDate, DateTime endDate)
        {
            PackageEntity obj = new PackageEntity();
            obj.Name = Name;
            obj.PackageId = PackageId;
            obj.Description = Description;
            obj.Price = Price;
            obj.StartDate = startDate;
            obj.EndDate = endDate;
            
            FlatFileHelper.AddPackage(obj);
            return null;
        }

        public PackageEntity EditPackage(String Name, int PackageId, String Description, int Price, DateTime startDate, DateTime endDate)
        {
            PackageEntity obj = new PackageEntity();

            obj.Name = Name;
            obj.PackageId = PackageId;
            obj.Description = Description;
            obj.Price = Price;
            obj.StartDate = startDate;
            obj.EndDate = endDate;

            FlatFileHelper.AddPackage(obj);
            return null;
        }

        public void DeletePackage(int packageId)
        {
            FlatFileHelper.RemovePackage(packageId);
        }

        public List<PackageEntity> ListPackage()
        {
            return FlatFileHelper.ListAllPackages();
        }

        public PackageEntity GetPackage(int packageId)
        {
            var data = FlatFileHelper.ListAllPackages();
            return data.Where(x => x.PackageId == packageId).FirstOrDefault();
        }
    }
}