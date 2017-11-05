namespace SoftwareDesign.Entities
{
    using System;
    using System.Collections.Generic;
    
    public class HotelEntity
    {   
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string NumberStars { get; set; }
        public string HotelPartnerId { get; set; }
    }
}