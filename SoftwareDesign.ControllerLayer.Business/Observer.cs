using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.ControllerLayer.Business
{
    public interface Observer
    {
         void updateState(int state); // for packageId
    }
}
