using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftwareDesign.Models.Entities
{
    public class Accommodation
    {
        public int AccommodationId {get;set;}
        public string Name { get; set; }
        public int Description { get; set; }
        public int AccommodationType { get; set; }
        public int Country { get; set; }
        public int City { get; set; }
        public int RoomType { get; set; }
        public int NumberStar { get; set; }
    }
}