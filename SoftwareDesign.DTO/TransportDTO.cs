namespace SoftwareDesign.DTO
{
    using System;
    using System.Collections.Generic;
    
    public class TransportDTO
    {    
        public int TransportId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TransportPartnerId { get; set; }
    }
}
