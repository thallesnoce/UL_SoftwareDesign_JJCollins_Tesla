using SoftwareDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.Repository
{
    public class PackageRepository
    {
        //Monica, here will be all data access (fake in our case)
        //Simulate the date base here.
        // All flat files will be here.
        public List<Package> SearchPackage(int transportId, int hotelId, DateTime startDate, DateTime endDate)
        {
            var data = new List<Package>()
            {
                new Package(){ PackageId = 1, Name = "3 Nights in Paris",  Description="Long Description", StartDate= DateTime.Now.Subtract(new TimeSpan(5,1,1,1)), EndDate= DateTime.Now.Add(new TimeSpan(5,1,1,1))},
                new Package(){ PackageId = 2, Name = "5 Nights in Irend",  Description="Long Description", StartDate= DateTime.Now.Subtract(new TimeSpan(25,1,1,1)), EndDate= DateTime.Now.Add(new TimeSpan(30,1,1,1))}
                //...
            };

            return data.Where(x => x.Transport.TransportId == transportId).Select(x => x).ToList();
        }
    }
}