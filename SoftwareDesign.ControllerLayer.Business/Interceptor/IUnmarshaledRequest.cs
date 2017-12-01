using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.ControllerLayer.Business.Interceptor
{
    /// <summary>
    /// Interface Context object
    /// 
    /// Pre
    /// </summary>
    public interface IUnmarshaledRequest
    {
        int getPackageId();
        void setPackageId(int packageId);
        int getClientId();
        decimal getPrice();
    }
}