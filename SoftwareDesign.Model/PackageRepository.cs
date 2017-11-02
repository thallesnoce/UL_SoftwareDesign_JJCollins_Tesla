using SoftwareDesign.Model.DataModel;
using SoftwareDesign.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareDesign.Model
{
    /// <summary>
    /// All data are mockup from flatfile using the "FlatFileHelper"
    /// </summary>
    public class PackageRepository
    {
        public List<Package> SearchPackage(int transportId, int hotelId, DateTime startDate, DateTime endDate)
        {
            var data = FlatFileHelper.ListAllPackages();
            return data.Where(x => x.Transport.TransportId == transportId).Select(x => x).ToList();
        }

        public Package GetPackage(int packageId)
        {
            var data = FlatFileHelper.ListAllPackages();
            return data.Where(x => x.PackageId == packageId).FirstOrDefault();
        }
    }
}