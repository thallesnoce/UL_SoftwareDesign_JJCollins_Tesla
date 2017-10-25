using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.Model
{
    public class Client : User
    {
        public int ClientId { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string ZipCode { get; set; }
    }
}