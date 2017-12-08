namespace SoftwareDesign.DTO
{
    using System;
    using System.Collections.Generic;
    
    public class HotelDTO
    {   
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string NumberStars { get; set; }
        public int HotelPartnerId { get; set; }        
    }
}