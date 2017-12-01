using SoftwareDesign.ControllerLayer.Business.Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.ControllerLayer.Business.Interceptor_Client
{
    public static class MainClientClass
    {
        /// <summary>
        /// This static method plays the role of the client.
        /// Here, the client create a instance of Concrete Interceptor and register it in the 
        /// dispatcher.
        /// </summary>
        public static void RegisterClientClass()
        {
            var interceptor = new BuyPackageInterceptor();
            BuyPackageDispatcher.Instance.register(interceptor);
        }
    }
}
