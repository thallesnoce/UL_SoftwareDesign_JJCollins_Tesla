using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.ControllerLayer.Business
{
    public interface Observer
    {
        /* 
         * update the state for Totalviews in the report
         * @pre packageId >0 && packageId != null
         * @post @IncrementPackageView --> totalViews + 1 --> totalViews >0
         * 
         */
        void updateState(int packageId); // for packageid, but also need Show package name to user in the ReportView.
    }
}
