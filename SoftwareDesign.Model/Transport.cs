using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.Model
{
    public class Transport
    {
        public int TransportId { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
        public int TransportPartnerId { get; set; }
    }
}