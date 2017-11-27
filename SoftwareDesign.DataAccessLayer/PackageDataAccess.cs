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
        FlatFileHelper context;
        public PackageDataAccess()
        {
            context = SingletonDBContext.GetContext();
        }

        public List<PackageEntity> SearchPackage(int transportId, int destinationId, int hotelId, DateTime startDate, DateTime endDate)
        {
            var data = context.ListAllPackages();
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

        //public List<ReportEntity> ListViewedPackges()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<ReportEntity> ListViewedPackges(int transportId, int destinationId, int hotelId, DateTime startDate, DateTime endDate)
        //{
        //    throw new NotImplementedException();
        //}

        //by monica and hang 11/11/2017
        public List<PackageEntity> DetailsPackage(String Name, int PackageId, String Description, int Price, DateTime startDate, DateTime endDate)

        {
            var data = context.ListAllPackages();
            return data.Select(x => x).ToList();

            //Getting the DBContext through a singleton design pattern
            //SingletonDBContext.GetContext().Packages.ToList();
        }

        public PackageEntity InsertPackage(String Name, int PackageId, String Description, int Price, DateTime startDate, DateTime endDate)
        {
            var data = context.ListAllPackages();
            return data.First();
            //return RedirectToAction("Index");
            //Getting the DBContext through a singleton design pattern
            //SingletonDBContext.GetContext().Packages.ToList();
        }

        public void EditPackage(String Name, int PackageId, String Description)
        {
            context.UpdatePackage(PackageId, Name, Description);
        }

        public void DeletePackage(int packageId)
        {
            context.RemovePackage(packageId);
        }

        public List<PackageEntity> ListPackage()
        {
            return context.ListAllPackages();
        }

        public PackageEntity GetPackage(int packageId)
        {
            var data = context.ListAllPackages();
            return data.Where(x => x.PackageId == packageId).FirstOrDefault();
        }

        /// <summary>
        /// The observer will call this method.
        /// </summary>
        /// <param name="packageid"></param>
        public void IncrementView(int packageId)
        {
            //get the package 
            var package = GetPackage(packageId);
            //increment
            context.IncrementPackageView(package);
        }

        public List<ReportEntity> ListViewedPackges()
        {
            return context.ListViewedPackages();
        }
    }
}