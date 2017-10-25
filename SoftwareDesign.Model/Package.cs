using System;

namespace SoftwareDesign.Model
{
    public class Package
    {
        public int PackageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Transport Transport { get; set; }
        public Hotel Hotel { get; set; }
        public Destination Destination { get; set; }
    }
}