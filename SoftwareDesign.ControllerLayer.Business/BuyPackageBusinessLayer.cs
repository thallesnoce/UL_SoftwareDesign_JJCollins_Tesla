using SoftwareDesign.ControllerLayer.Business.Interceptor;
using SoftwareDesign.DataAccessLayer;
using SoftwareDesign.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.ControllerLayer.Business
{
    public class BuyPackageBusinessLayer
    {
        private static readonly object locker = new object();
        public BuyPackageBusinessLayer()
        {
        }

        public Tuple<Boolean, string> EffectivePackageBuy(decimal price, string cardNumber, string expirationDate, string cvc)
        {
            /*
             * >>> Interceptor <<<
             *  Here the framework triggers the PreMarshalRequest
             */
            var unmarshaledRequest = new UnmarshaledRequest();
            unmarshaledRequest.setPackageId(500);
            BuyPackageDispatcher.Instance.DispatchClientRequestInterceptorPreMarshal(unmarshaledRequest);

            /**
             * 
             This will ensure that buy package will happen in a synchronous way
             *
             */
            //TODO: Check this
            lock (locker)
            {
                var result = CheckWithThirdPartCrediCard(price, cardNumber, expirationDate, cvc);
            }

            /*
             * >>> Interceptor <<<
             *  Here the framework triggers the PostMarshalRequest
             */
            var marshaledRequest = new MarshaledRequest();
            marshaledRequest.setPackageId(500);
            BuyPackageDispatcher.Instance.DispatchClientRequestInterceptorPostMarshal(marshaledRequest);

            return new Tuple<bool, string>(true, "");
        }

        public decimal CalculatePrice(int packageId, List<int> aditionalServices)
        {
            IPackage package = new PackageDataAccess().GetPackage(packageId);

            foreach (var serviceType in aditionalServices)
            {
                var packageFactory = new ConcretePackageFactory();
                package = packageFactory.FactoryServiceMethod(package, serviceType);
            }

            return package.GetPrice();
        }

        /// <summary>
        /// This Method Simulate a comunication with the Third Part Software. 
        /// In this case Credit Card Operator System.
        /// Was Created a API to fake this comunication.
        /// </summary>
        /// <param name="price"></param>
        /// <param name="cardNumber"></param>
        /// <param name="expirationDate"></param>
        /// <param name="cvc"></param>
        /// <returns></returns>
        private static Tuple<bool, string> CheckWithThirdPartCrediCard(decimal price, string cardNumber, string expirationDate, string cvc)
        {
            bool isSuccess = false;
            string message = string.Empty;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:58561/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"CrediCard/PostRegisterBuy/{cardNumber}/{expirationDate}/{cvc}/{price}").Result;
            if (response.IsSuccessStatusCode)
            {
                var transactionStatus = response.Content.ReadAsStringAsync().Result.Split('|');

                isSuccess = Convert.ToBoolean(transactionStatus[0]);
                message = transactionStatus[1];
            }
            else
            {
                isSuccess = false;
                message = "Error when trying to connect to the Credit Card Company.";
            }

            return new Tuple<bool, string>(isSuccess, message);
        }
    }
}