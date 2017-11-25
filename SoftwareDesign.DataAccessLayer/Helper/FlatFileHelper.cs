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
        private static Dictionary<PackageEntity,int> ViewedPackages;

        public static void Initialize()
        {
            var assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var flatFileLocation = Path.Combine(assemblyFolder, "FlatFile.json");

            generatePackage(flatFileLocation);
            readFlatFile(flatFileLocation);

            ViewedPackages = new Dictionary<PackageEntity, int>();


            //First parameter is the packageEntity
            //the second parameter is the number of times the package was viewed
        }

        /// <summary>
        /// TODO： Hang   this will be called by the observer method
        /// </summary>
        /// <param name="packageid"></param>
        public static void IncrementPackageView(PackageEntity package) {
            if (!ViewedPackages.ContainsKey(package))
            {
                ViewedPackages.Add(package, 1);
            }
            else {
                var totalViews = ViewedPackages[package];
                ViewedPackages[package] = totalViews + 1;
            }
        }

        /// <summary>
        /// this will be called by the report controller
        /// </summary>
        /// <returns></returns>
        public static Dictionary<PackageEntity,int> ListViewedPackages() {
            return ViewedPackages;
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
                new PackageEntity(){ PackageId = 1, Name = "3 Nights in Paris",  Description="Avoid the huge crowds, and skip the line when going to the Arc de Triomphe in Paris. This 160-foot- (50-meter-) tall and 148-foot- (45-meter-) wide arch is a must-see when travelling to France’s capital. Stroll down Champs-Élysées, one of the city’s largest boulevards, to make your way there. Admire the mighty monument where the wars fought by France and the names of the French generals involved are written. Climb up the terrace for beautiful views across Paris, or spend time visiting the tomb of the Unknown Soldier.", StartDate= DateTime.Now.Subtract(new TimeSpan(5,1,1,1)), EndDate= DateTime.Now.Add(new TimeSpan(5,1,1,1)),
                    Transport =flatFile.Transports.Find((x)=>x.TransportId==1),Destination=flatFile.Destinations.Find((d)=>d.DestinationId ==4),Hotel=flatFile.Hoteis.Find((d)=>d.HotelId ==4),Price=420},

                new PackageEntity(){ PackageId = 2, Name = "15 Nights in Limerick",  Description="Escape the bustle of Dublin in favor of the coastal scenery of County Clare on a guided full-day trip to Ireland’s Cliffs of Moher. From the comfort of a luxury coach, admire the unrivaled beauty of the Irish countryside as you travel to the dramatic array of cliffs. Enjoy leisurely strolls on rugged coastal paths; gain fascinating insight into the geology and history of the area from your expert guide; and explore the stunning Burren National Park on this day trip.", StartDate= DateTime.Now.Subtract(new TimeSpan(25,1,1,1)), EndDate= DateTime.Now.Add(new TimeSpan(30,1,1,1)),
                    Transport =flatFile.Transports.Find((x)=>x.TransportId==2),Destination=flatFile.Destinations.Find((d)=>d.DestinationId ==2),Hotel=flatFile.Hoteis.Find((d)=>d.HotelId ==2),Price=980},

                new PackageEntity(){ PackageId = 2, Name = "2 Nights in Galway",  Description="For visitors, the best thing about Galway is that you can walk everywhere. As soon as you arrive, enjoy a walk through the city streets. There, you'll find lively pubs, independent shops and winding cobblestone streets packed with students, artists, writers and craftspeople. You may even hear Gaelic spoken. For a day trip, take a ferry to the island of Inis Mor. You'll return refreshed by the ocean air and Inis Mor's breathtaking scenery. Oh, and be sure to wear sunscreen on the island, no matter how chilly it is. ", StartDate= DateTime.Now.Subtract(new TimeSpan(20,1,1,1)), EndDate= DateTime.Now.Add(new TimeSpan(35,1,1,1)),
                    Transport =flatFile.Transports.Find((x)=>x.TransportId==2),Destination=flatFile.Destinations.Find((d)=>d.DestinationId ==3),Hotel=flatFile.Hoteis.Find((d)=>d.HotelId ==3),Price=290},

                new PackageEntity(){ PackageId = 2, Name = "7 Nights in Dublin",  Description="Dublin (fresh from the factory), but what you may not know is that Dublin is a perfect destination for the whole family. No, we're not suggesting you let the kiddies drink a pint. Instead, take them to the Dublin Zoo, to feed the ducks in Stephen's Green or on a picnic in Phoenix Park. Scholars enjoy walking in the literary footsteps of such writers as Yeats and Joyce, while discerning shoppers have their pick of designer boutiques.", StartDate= DateTime.Now.Subtract(new TimeSpan(10,1,1,1)), EndDate= DateTime.Now.Add(new TimeSpan(20,1,1,1)),
                    Transport =flatFile.Transports.Find((x)=>x.TransportId==1),Destination=flatFile.Destinations.Find((d)=>d.DestinationId ==1),Hotel=flatFile.Hoteis.Find((d)=>d.HotelId ==1),Price=660},

                new PackageEntity(){ PackageId = 2, Name = "16 Nights in Belo Horizonte",  Description="The name says it all: Belo Horizonte, or “beautiful horizon,” has stunning views of surrounding mountains. Built as a planned city about a century ago, its tree-lined streets are laid out in a tidy grid. Explore the modern Brazilian architecture of the Pampulha neighborhood, relax in Mangabeiras Park or indulge in some epic retail therapy. Refresh with a cachaça rum cocktail, or tuck into a sumptuous pile of meat at a traditional Brazilian barbecue restaurant.", StartDate= DateTime.Now.Subtract(new TimeSpan(5,1,1,1)), EndDate= DateTime.Now.Add(new TimeSpan(15,1,1,1)),
                    Transport =flatFile.Transports.Find((x)=>x.TransportId==1),Destination=flatFile.Destinations.Find((d)=>d.DestinationId ==5),Hotel=flatFile.Hoteis.Find((d)=>d.HotelId ==5),Price=500}
            };

            var jsonString = JsonConvert.SerializeObject(flatFile);
            File.WriteAllText(flatFileLocation, jsonString);
        }


        public void AddPaclage(PackageEntity package)
        {
            Data.Packages.Add(package);
        }

        public void Remove(int id)
        {
            Data.Packages.RemoveAll(x => x.PackageId == id);
        }

        public void Update(int id, string name, string description)
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