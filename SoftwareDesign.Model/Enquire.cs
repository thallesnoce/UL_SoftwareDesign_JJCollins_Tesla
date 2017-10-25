using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.Model
{
    public class Enquire
    {
        public int EnquireIid { get; set; }
        public string Comment { get; set; }
        public string Subject { get; set; }
        public Boolean IsUrgent { get; set; }
    }
}