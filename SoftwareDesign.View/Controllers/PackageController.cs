using SoftwareDesign.ControllerLayer.Business;
using SoftwareDesign.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace SoftwareDesign.View.Controllers
{
    public class PackageController : Controller  //subject
    {
        /// <summary>
        /// Thalles and Jessie Use Case Implementation
        /// </summary>
        /// <param name="transportId"></param>
        /// <param name="hotelId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public ActionResult Search(int? TransportId, int? DestinationId, int? HotelId, string StartDate, string EndDate)
        {
            ViewBag.TransportId = GetTransports();
            ViewBag.DestinationId = GetDestinations();
            ViewBag.HotelId = GetHoteis();

            var packageList = new List<PackageEntity>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54155/api/");
                //HTTP GET
                var responseTask = client.GetAsync($"Package/SearchPackage/{TransportId ?? 0}/{DestinationId ?? 0}/{HotelId ?? 0}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<PackageEntity>>();
                    readTask.Wait();

                    packageList = readTask.Result;
                }
            }

            return View(packageList);
        }

        [HttpGet]
        public ActionResult CalculatePrice(int packageId, string additionalServices)
        {
            PackageEntity package = new PackageEntity();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54155/api/");
                //HTTP GET
                var services = !string.IsNullOrEmpty(additionalServices) ? additionalServices : "0";
                var responseTask = client.GetAsync($"Package/CalculatePrice/{packageId}/{services}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PackageEntity>();
                    readTask.Wait();

                    package = readTask.Result;
                }
            }

            ViewBag.cardOptions = new List<SelectListItem>() {
                    new SelectListItem(){ Text= "Credit Card",Value="1" },
                    new SelectListItem(){ Text= "Debit Card", Value="2"}
                };

            return PartialView("_calculatePrice", package);
        }

        /// <summary>
        /// Process the Payment of the Package
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BuyPackage(int packageId, decimal price, int cardOptions, string cardNumber, string expirationDate, string cvc)
        {
            Tuple<bool, string> packageResult = new Tuple<bool, string>(false, "");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54155/api/");
                //HTTP GET
                var responseTask = client.GetAsync($"Package/BuyPackage/{packageId}/{1}/{price}/{cardOptions}/{cardNumber}/{expirationDate}/{cvc}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Tuple<bool, string>>();
                    readTask.Wait();

                    packageResult = readTask.Result;
                }
            }
            return PartialView("_confirmPayment", packageResult.Item2);
        }

        /// <summary>
        /// Monica and HangDu Use Case Implementation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ViewPackage(int packageId)
        {
            PackageEntity package = new PackageEntity();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54155/api/");
                //HTTP GET
                var responseTask = client.GetAsync($"Package/GetPackage/{packageId}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PackageEntity>();
                    readTask.Wait();

                    package = readTask.Result;
                }
            }

            return View(package);
        }

        private IEnumerable<SelectListItem> GetDestinations()
        {
            IEnumerable<DestinationEntity> transports = new List<DestinationEntity>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54155/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Destination");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<DestinationEntity>>();
                    readTask.Wait();

                    transports = readTask.Result;
                }
            }

            return transports.Select(x => new SelectListItem() { Text = x.Name, Value = x.DestinationId.ToString() });
        }

        private IEnumerable<SelectListItem> GetHoteis()
        {
            IEnumerable<HotelEntity> transports = new List<HotelEntity>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54155/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Hotel");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<HotelEntity>>();
                    readTask.Wait();

                    transports = readTask.Result;
                }
            }

            return transports.Select(x => new SelectListItem() { Text = x.Name, Value = x.HotelId.ToString() });
        }

        private IEnumerable<SelectListItem> GetTransports()
        {
            IEnumerable<TransportEntity> transports = new List<TransportEntity>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54155/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Transport");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<TransportEntity>>();
                    readTask.Wait();

                    transports = readTask.Result;
                }
            }
            return transports.Select(x => new SelectListItem() { Text = x.Name, Value = x.TransportId.ToString() });
        }
    }
}
