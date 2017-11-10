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
            new EnquireDataAccess().CreateEnquire(packageId, message);
            //Monica, Use your Observer Class here.
        }
    }
}
