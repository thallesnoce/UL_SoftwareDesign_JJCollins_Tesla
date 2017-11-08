using SoftwareDesign.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.ControllerLayer.Business
{
    public class EnquireBusinessLayer
    {
        public void CreateEnquire(int packageId, string message)
        {
            // add statement about what the observer need to do here
            
            /* Observer: EnquireColler
             * Subjects: Enquire information in packageDetail page
             * When client enters enquiries, the subjects will notify the obsever by using notifyObservers()
            
            */
             new EnquireDataAccess().CreateEnquire(packageId,message);
      
        }
    }
}
