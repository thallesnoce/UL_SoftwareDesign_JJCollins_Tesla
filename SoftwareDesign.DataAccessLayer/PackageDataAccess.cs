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
            SingletonDBContext.Packages.ToList();

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

        public List<ReportEntity> ListViewedPackges()
        {
            throw new NotImplementedException();
        }

        public List<ReportEntity> ListViewedPackges(int transportId, int destinationId, int hotelId, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<ReportEntity> ListPackage(int transportId, int destinationId, int hotelId, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        //by monica and hang 11/11/2017
        public List<PackageEntity> DetailsPackage(String Name, int PackageId, String Description, int Price, DateTime startDate, DateTime endDate)

        {
            var data = FlatFileHelper.ListAllPackages();
            return data.Select(x => x).ToList();

            //Getting the DBContext through a singleton design pattern
            //SingletonDBContext.GetContext().Packages.ToList();
        }

        /*
         TN: I've created the method in the flatfile EditPackage
         No return needed also. should be void.
         */
        public PackageEntity InsertPackage(String Name, int PackageId, String Description, int Price, DateTime startDate, DateTime endDate)
        {
            var data = FlatFileHelper.ListAllPackages();
            return data.First();
            //return RedirectToAction("Index");
            //Getting the DBContext through a singleton design pattern
            //SingletonDBContext.GetContext().Packages.ToList();
        }

        /*TN: should be void
         * No return needed 
         
            I've created the method in the flatfile EditPackage
             */
        public void EditPackage(String Name, int PackageId, String Description)
        {
            var data = FlatFileHelper.ListAllPackages();
            // Thalles please help here.
            //return RedirectToAction("Index");
            //Getting the DBContext through a singleton design pattern
            //SingletonDBContext.GetContext().Packages.ToList();   
        }

        /*TN: should be void (no return needed)
         
         I've created the method in the flatfile DeletePackage

            usage: FlatFile.Delete(PackageId);
             */
        public void DeletePackage(int PackageId)
        {
            var data = FlatFileHelper.ListAllPackages();
            //return data.Where(x=>x.PackageId==PackageId);
            //thalles pls help here.
            //return RedirectToAction("Index");
            //Getting the DBContext through a singleton design pattern
            //SingletonDBContext.GetContext().Packages.ToList();
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

        /// <summary>
        /// The observer will call this method.
        /// </summary>
        /// <param name="packageid"></param>
        public void IncrementView(int packageid) {
            //get the package 
            var package = GetPackage(packageid);
            //increment
            FlatFileHelper.IncrementPackageView(package);
        }
        //create a method here a method and call the method in the flatfile
        //increase 


        //Create new page in the view project
        //that page will show all packages and the total views for each

        //create a new business class in the business project
        //Create a method to get the list of viewedpakcage ******
        //using the method created in the flatfle

    }
}