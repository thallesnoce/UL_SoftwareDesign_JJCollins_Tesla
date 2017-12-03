namespace SoftwareDesign.Entities
{
    using System;
    using System.Collections.Generic;
    
    public class TransportEntity
    {    
        public int TransportId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TransportPartnerId { get; set; }
    }
}
