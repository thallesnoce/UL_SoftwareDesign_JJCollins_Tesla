using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.ControllerLayer.Business.Interceptor
{
    /// <summary>
    /// Interface Client Request Interceptor
    /// </summary>
    public interface IClientRequestInterceptor
    {
        void onPreMarshalRequest(IUnmarshaledRequest context);
        void onPostMarshalRequest(IMarshaledRequest context);
    }
}