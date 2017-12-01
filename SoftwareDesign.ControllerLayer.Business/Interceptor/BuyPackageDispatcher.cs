using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.ControllerLayer.Business.Interceptor
{
    /// <summary>
    /// Dispatcher.
    /// Owns the List of Interceptors that the application should notify when a event occurs
    /// </summary>
    public class BuyPackageDispatcher
    {
        private static readonly object locker = new Object();
        private static List<IClientRequestInterceptor> interceptors = new List<IClientRequestInterceptor>();
        private static BuyPackageDispatcher instance;

        private BuyPackageDispatcher()
        {
        }

        public static BuyPackageDispatcher Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BuyPackageDispatcher();
                }

                return instance;
            }
        }

        public void register(IClientRequestInterceptor i)
        {
            lock (locker)
            {
                interceptors.Add(i); //Add interceptor.
            }
        }

        public void remove(IClientRequestInterceptor i)
        {
            lock (locker)
            {
                interceptors.Remove(i);// Remove interceptor.
            }
        }

        public void DispatchClientRequestInterceptorPreMarshal(IUnmarshaledRequest context)
        {
            List<IClientRequestInterceptor> interceptorsClone;

            lock (locker)
            {
                interceptorsClone = new List<IClientRequestInterceptor>(interceptors);
            }

            foreach (var interceptor in interceptorsClone)
            {
                var ic = interceptor;

                // dispatch callback hook method
                ic.onPreMarshalRequest(context);
            }
        }

        public void DispatchClientRequestInterceptorPostMarshal(IMarshaledRequest context)
        {
            List<IClientRequestInterceptor> interceptorsClone;

            lock (locker)
            {
                interceptorsClone = new List<IClientRequestInterceptor>(interceptors);
            }

            foreach (var interceptor in interceptorsClone)
            {
                var ic = interceptor;

                // dispatch callback hook method
                ic.onPostMarshalRequest(context);
            }
        }
    }
}