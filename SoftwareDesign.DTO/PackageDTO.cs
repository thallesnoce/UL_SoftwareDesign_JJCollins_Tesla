using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.DTO
{
    /// <summary
    /// >
    /// Concrete Component
    /// </summary>
    public class PackageDTO
    {
        public int PackageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public HotelDTO Hotel { get; set; }
        public TransportDTO Transport { get; set; }
        public DestinationDTO Destination { get; set; }
        public ClientDTO Client { get; set; }
    }
}