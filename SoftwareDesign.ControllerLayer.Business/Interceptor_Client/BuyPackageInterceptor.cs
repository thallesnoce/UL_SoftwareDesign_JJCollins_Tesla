using SoftwareDesign.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.ControllerLayer.Business.Interceptor
{
    /// <summary>
    /// Concrete Interceptor
    /// Here the client implements what is not provided by the framework
    /// </summary>
    public class BuyPackageInterceptor : IClientRequestInterceptor
    {
        public void onPreMarshalRequest(IUnmarshaledRequest context)
        {
            var sb = new List<string>();
            sb.Add($"Interceptor PreMarshal - {DateTime.Now.ToShortDateString()}");
            sb.Add($"clientId : {context.getPackageId()} trying to buy the packageid: {context.getPackageId()}");
            sb.Add($".");

            File.AppendAllLines(Path.Combine(@"C:\Workarea", "PreMarshal"), sb);
        }

        public void onPostMarshalRequest(IMarshaledRequest context)
        {
            var sb = new List<string>();
            sb.Add($"Interceptor PostMarshal - {DateTime.Now.ToShortDateString()}");
            sb.Add($"Packageid: {context.getPackageId()} was bought by the client {context.getPackageId()}");
            sb.Add($".");

            File.AppendAllLines(Path.Combine(@"C:\Workarea", "PostMarshal"), sb);
        }
    }
}