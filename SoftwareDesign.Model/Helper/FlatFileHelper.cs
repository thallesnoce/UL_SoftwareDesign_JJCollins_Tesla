using Newtonsoft.Json;
using SoftwareDesign.Model.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.Model.Helper
{
    /// <summary>
    /// This class is to create and maintain the FlatFile.
    /// 
    /// All data are stored in JSON format.
    /// </summary>
    public class FlatFileHelper
    {
        private string assemblyFolder;
        private string flatFileLocation;

        private static FlatFile Data = new FlatFile();

        public void Initialize()
        {
            assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            flatFileLocation = Path.Combine(assemblyFolder, "FlatFile.json");

            generatePackage();
            readFlatFile();
        }

        public static List<Transport> ListAllTransports()
        {
            return Data.Transports;
        }

        public static List<Destination> ListAllDestinations()
        {
            return Data.Destinations;
        }

        public static List<Hotel> ListAllHoteis()
        {
            return Data.Hoteis;
        }

        public static List<Package> ListAllPackages()
        {
            return Data.Packages;
        }

        private void readFlatFile()
        {
            var stringfyedData = File.ReadAllText(flatFileLocation);
            Data = JsonConvert.DeserializeObject<FlatFile>(stringfyedData);
        }

        private void generatePackage()
        {
            var flatFile = new FlatFile();

            /*Transportes*/
            flatFile.Transports = new List<Transport>() {
                new Transport() { TransportId = 1, Name = "Airplane", Description = "Airplane Otion", TransportPartnerId = "1" },
                new Transport() { TransportId = 2, Name = "Bus", Description = "Bus Option", TransportPartnerId = "2" }
            };

            /*Destinations*/
            flatFile.Destinations = new List<Destination>() {
                new Destination() { DestinationId = 1, Name = "Dublin", Description = "Long Description"},
                new Destination() { DestinationId = 2, Name = "Limerick", Description = "Long Description"},
                new Destination() { DestinationId = 3, Name = "Galway", Description = "Long Description"},
                new Destination() { DestinationId = 4, Name = "Paris", Description = "Long Description"},
                new Destination() { DestinationId = 5, Name = "Belo Horizonte", Description = "Long Description"}
            };

            /*Hoteis*/
            flatFile.Hoteis = new List<Hotel>() {
                new Hotel() { HotelId = 1, Name = "Savoy Hotel", Description = "The best option 5 stars in Dublin", HotelPartnerId = "1" ,City="",NumberStars="5 Stars"},
                new Hotel() { HotelId = 2, Name = "Absolute Limerick Hotel", Description = "Long Description", HotelPartnerId = "2" ,City="",NumberStars="4 Stars"},
                new Hotel() { HotelId = 3, Name = "Galway Hotel", Description = "Long Description", HotelPartnerId = "3" ,City="",NumberStars=""},
                new Hotel() { HotelId = 4, Name = "The Louvre Hotel", Description = "Long Description", HotelPartnerId = "4" ,City="",NumberStars=""},
                new Hotel() { HotelId = 5, Name = "Belo Horizonte Hotel", Description = "Long Description", HotelPartnerId = "5" ,City="",NumberStars=""}
            };

            /*Packages*/
            flatFile.Packages = new List<Package>()
            {
                new Package(){ PackageId = 1, Name = "3 Nights in Paris",  Description="Long Description", StartDate= DateTime.Now.Subtract(new TimeSpan(5,1,1,1)), EndDate= DateTime.Now.Add(new TimeSpan(5,1,1,1)),
                    Transport =flatFile.Transports.Find((x)=>x.TransportId==1),Destination=flatFile.Destinations.Find((d)=>d.DestinationId ==4),Hotel=flatFile.Hoteis.Find((d)=>d.HotelId ==4),Price=500},

                new Package(){ PackageId = 2, Name = "15 Nights in Limerick",  Description="Long Description", StartDate= DateTime.Now.Subtract(new TimeSpan(25,1,1,1)), EndDate= DateTime.Now.Add(new TimeSpan(30,1,1,1)),
                    Transport =flatFile.Transports.Find((x)=>x.TransportId==2),Destination=flatFile.Destinations.Find((d)=>d.DestinationId ==2),Hotel=flatFile.Hoteis.Find((d)=>d.HotelId ==2),Price=500},

                new Package(){ PackageId = 2, Name = "2 Nights in Galway",  Description="Long Description", StartDate= DateTime.Now.Subtract(new TimeSpan(20,1,1,1)), EndDate= DateTime.Now.Add(new TimeSpan(35,1,1,1)),
                    Transport =flatFile.Transports.Find((x)=>x.TransportId==2),Destination=flatFile.Destinations.Find((d)=>d.DestinationId ==3),Hotel=flatFile.Hoteis.Find((d)=>d.HotelId ==3),Price=500},

                new Package(){ PackageId = 2, Name = "7 Nights in Dublin",  Description="Long Description", StartDate= DateTime.Now.Subtract(new TimeSpan(10,1,1,1)), EndDate= DateTime.Now.Add(new TimeSpan(20,1,1,1)),
                    Transport =flatFile.Transports.Find((x)=>x.TransportId==1),Destination=flatFile.Destinations.Find((d)=>d.DestinationId ==1),Hotel=flatFile.Hoteis.Find((d)=>d.HotelId ==1),Price=500},

                new Package(){ PackageId = 2, Name = "16 Nights in Belo Horizonte",  Description="Long Description", StartDate= DateTime.Now.Subtract(new TimeSpan(5,1,1,1)), EndDate= DateTime.Now.Add(new TimeSpan(15,1,1,1)),
                    Transport =flatFile.Transports.Find((x)=>x.TransportId==1),Destination=flatFile.Destinations.Find((d)=>d.DestinationId ==5),Hotel=flatFile.Hoteis.Find((d)=>d.HotelId ==5),Price=500}
            };

            var jsonString = JsonConvert.SerializeObject(flatFile);
            File.WriteAllText(flatFileLocation, jsonString);
        }
    }

    public class FlatFile
    {
        public List<Package> Packages { get; set; }
        public List<Transport> Transports { get; set; }
        public List<Destination> Destinations { get; set; }
        public List<Hotel> Hoteis { get; set; }
    }
}