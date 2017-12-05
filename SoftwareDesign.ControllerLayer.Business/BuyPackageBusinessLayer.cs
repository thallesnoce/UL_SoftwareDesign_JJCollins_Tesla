using SoftwareDesign.ControllerLayer.Business.Interceptor;
using SoftwareDesign.DataAccessLayer;
using SoftwareDesign.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public Tuple<Boolean, string> EffectivePackageBuy(int packageid, decimal price, string cardNumber, string expirationDate, string cvc)
        {
            Tuple<bool, string> hotelPartnerReturn;
            Tuple<bool, string> transportPartnerReturn;
            Tuple<bool, string> crediCardPartnerReturn;

            /*
             * >>> Interceptor <<<
             *  Here the framework triggers the PreMarshalRequest
             */
            var unmarshaledRequest = new UnmarshaledRequest();
            unmarshaledRequest.setPackageId(packageid);
            BuyPackageDispatcher.Instance.DispatchClientRequestInterceptorPreMarshal(unmarshaledRequest);

            /**
             * 
             This will ensure that buy package will happen in a synchronous way
             *
             */
            lock (locker)
            {
                var package = new PackageDataAccess().GetPackage(packageid);

                hotelPartnerReturn = CheckWithThirdHotel(package.Hotel.HotelPartnerId);
                transportPartnerReturn = CheckWithThirdTransport(package.Transport.TransportPartnerId);
                crediCardPartnerReturn = CheckWithThirdPartCrediCard(price, cardNumber, expirationDate, cvc);
            }

            /*
             * >>> Interceptor <<<
             *  Here the framework triggers the PostMarshalRequest
             */
            var marshaledRequest = new MarshaledRequest();
            marshaledRequest.setPackageId(packageid);
            BuyPackageDispatcher.Instance.DispatchClientRequestInterceptorPostMarshal(marshaledRequest);

            return new Tuple<bool, string>(crediCardPartnerReturn.Item1, crediCardPartnerReturn.Item2);
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
        /// Simulate Hotel Parter
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        private static Tuple<bool, string> CheckWithThirdHotel(int hotelId)
        {
            return new Tuple<bool, string>(true, string.Empty);
        }

        /// <summary>
        /// Simulate Transport Partner
        /// </summary>
        /// <param name="TransportId"></param>
        /// <returns></returns>
        private static Tuple<bool, string> CheckWithThirdTransport(int TransportId)
        {
            return new Tuple<bool, string>(true, string.Empty);
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

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"api/CreditCard/{cardNumber}/{cvc}/{price.ToString("F2").Replace(".", "")}").Result;

            if (response.IsSuccessStatusCode)
            {
                var transactionStatus = response.Content.ReadAsStringAsync().Result.Split('|');

                isSuccess = true;
                message = "Transaction successfully completed";
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