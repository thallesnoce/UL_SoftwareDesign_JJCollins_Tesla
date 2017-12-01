using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.ControllerLayer.Business.Interceptor
{
    /// <summary>
    /// Context object
    ///
    /// Post
    /// </summary>
    public class MarshaledRequest : IMarshaledRequest
    {
        private int packageId;
        private int clientId;
        private decimal price;

        public int getPackageId() => packageId;
        public void setPackageId(int packageId)
        {
            this.packageId = packageId;
        }

        public int getClientId() => clientId;
        public decimal getPrice() => price;
    }
}