using Newtonsoft.Json;
using SoftwareDesign.DataAccessLayer.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.Entities.Helper
{
    /// <summary>
    /// This class is to create and maintain the FlatFile.
    /// 
    /// All data are stored in JSON format.
    /// </summary>
    public class FlatFileHelper
    {
        private static FlatFile Data;

        public static void Initialize()
        {
            var assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var flatFileLocation = Path.Combine(assemblyFolder, "FlatFile.json");

            generatePackage(flatFileLocation);
            readFlatFile(flatFileLocation);
        }

        public static List<TransportEntity> ListAllTransports()
        {
            if (Data == null)
            {
                Initialize();
            }
            return Data.Transports;
        }

        public static List<DestinationEntity> ListAllDestinations()
        {
            if (Data == null)
            {
                Initialize();
            }
            return Data.Destinations;
        }

        public static List<HotelEntity> ListAllHoteis()
        {
            if (Data == null)
            {
                Initialize();
            }
            return Data.Hoteis;
        }

        public static List<PackageEntity> ListAllPackages()
        {
            if (Data == null)
            {
                Initialize();
            }
            return Data.Packages;
        }

        private static void readFlatFile(string flatFileLocation)
        {
            var stringfyedData = File.ReadAllText(flatFileLocation);
            Data = JsonConvert.DeserializeObject<FlatFile>(stringfyedData);
        }

        private static void generatePackage(string flatFileLocation)
        {
            var flatFile = new FlatFile();

            /*Transport types*/
            flatFile.Transports = new List<TransportEntity>() {
                new TransportEntity() { TransportId = 1, Name = "Airplane", Description = "Airplane Otion", TransportPartnerId = "1" },
                new TransportEntity() { TransportId = 2, Name = "Bus", Description = "Bus Option", TransportPartnerId = "2" }
            };

            /*Destinations*/
            flatFile.Destinations = new List<DestinationEntity>() {
                new DestinationEntity() { DestinationId = 1, Name = "Dublin", Description = "Long Description"},
                new DestinationEntity() { DestinationId = 2, Name = "Limerick", Description = "Long Description"},
                new DestinationEntity() { DestinationId = 3, Name = "Galway", Description = "Long Description"},
                new DestinationEntity() { DestinationId = 4, Name = "Paris", Description = "Long Description"},
                new DestinationEntity() { DestinationId = 5, Name = "Belo Horizonte", Description = "Long Description"}
            };

            /*Hoteis*/
            flatFile.Hoteis = new List<HotelEntity>() {
                new HotelEntity() { HotelId = 1, Name = "Savoy Hotel", Description = "The best option 5 stars in Dublin", HotelPartnerId = "1" ,City="",NumberStars="5 Stars"},
                new HotelEntity() { HotelId = 2, Name = "Absolute Limerick Hotel", Description = "Long Description", HotelPartnerId = "2" ,City="",NumberStars="4 Stars"},
                new HotelEntity() { HotelId = 3, Name = "Galway Hotel", Description = "Long Description", HotelPartnerId = "3" ,City="",NumberStars=""},
                new HotelEntity() { HotelId = 4, Name = "The Louvre Hotel", Description = "Long Description", HotelPartnerId = "4" ,City="",NumberStars=""},
                new HotelEntity() { HotelId = 5, Name = "Belo Horizonte Hotel", Description = "Long Description", HotelPartnerId = "5" ,City="",NumberStars=""}
            };

            /*Packages*/
            flatFile.Packages = new List<PackageEntity>()
            {
                new PackageEntity(){ PackageId = 1, Name = "3 Nights in Paris",  Description="Long Description", StartDate= DateTime.Now.Subtract(new TimeSpan(5,1,1,1)), EndDate= DateTime.Now.Add(new TimeSpan(5,1,1,1)),
                    Transport =flatFile.Transports.Find((x)=>x.TransportId==1),Destination=flatFile.Destinations.Find((d)=>d.DestinationId ==4),Hotel=flatFile.Hoteis.Find((d)=>d.HotelId ==4),Price=500},

                new PackageEntity(){ PackageId = 2, Name = "15 Nights in Limerick",  Description="Long Description", StartDate= DateTime.Now.Subtract(new TimeSpan(25,1,1,1)), EndDate= DateTime.Now.Add(new TimeSpan(30,1,1,1)),
                    Transport =flatFile.Transports.Find((x)=>x.TransportId==2),Destination=flatFile.Destinations.Find((d)=>d.DestinationId ==2),Hotel=flatFile.Hoteis.Find((d)=>d.HotelId ==2),Price=500},

                new PackageEntity(){ PackageId = 2, Name = "2 Nights in Galway",  Description="Long Description", StartDate= DateTime.Now.Subtract(new TimeSpan(20,1,1,1)), EndDate= DateTime.Now.Add(new TimeSpan(35,1,1,1)),
                    Transport =flatFile.Transports.Find((x)=>x.TransportId==2),Destination=flatFile.Destinations.Find((d)=>d.DestinationId ==3),Hotel=flatFile.Hoteis.Find((d)=>d.HotelId ==3),Price=500},

                new PackageEntity(){ PackageId = 2, Name = "7 Nights in Dublin",  Description="Long Description", StartDate= DateTime.Now.Subtract(new TimeSpan(10,1,1,1)), EndDate= DateTime.Now.Add(new TimeSpan(20,1,1,1)),
                    Transport =flatFile.Transports.Find((x)=>x.TransportId==1),Destination=flatFile.Destinations.Find((d)=>d.DestinationId ==1),Hotel=flatFile.Hoteis.Find((d)=>d.HotelId ==1),Price=500},

                new PackageEntity(){ PackageId = 2, Name = "16 Nights in Belo Horizonte",  Description="Long Description", StartDate= DateTime.Now.Subtract(new TimeSpan(5,1,1,1)), EndDate= DateTime.Now.Add(new TimeSpan(15,1,1,1)),
                    Transport =flatFile.Transports.Find((x)=>x.TransportId==1),Destination=flatFile.Destinations.Find((d)=>d.DestinationId ==5),Hotel=flatFile.Hoteis.Find((d)=>d.HotelId ==5),Price=500}
            };

            var jsonString = JsonConvert.SerializeObject(flatFile);
            File.WriteAllText(flatFileLocation, jsonString);
        }

        public static void AddPackage(PackageEntity package)
        {
            Data.Packages.Add(package);
        }

        public static void RemovePackage(int id)
        {
            Data.Packages.RemoveAll(x => x.PackageId == id);
        }

        public static void UpdatePackage(int id, string name, string description)
        {
            var package = Data.Packages.FirstOrDefault(x => x.PackageId == id);
            package.Name = name;
            package.Description = description;
        }

        public class FlatFile
        {
            public List<PackageEntity> Packages { get; set; }
            public List<TransportEntity> Transports { get; set; }
            public List<DestinationEntity> Destinations { get; set; }
            public List<HotelEntity> Hoteis { get; set; }
        }
    }
}