using SoftwareDesign.ControllerLayer.Business;
using SoftwareDesign.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SoftwareDesign.View.Controllers
{
    public class PackageController : Controller
    {
        /// <summary>
        /// Thalles and Jessie Use Case Implementation
        /// </summary>
        /// <param name="transportId"></param>
        /// <param name="hotelId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Search(int? TransportId, int? DestinationId, int? HotelId)
        {
            ViewBag.TransportId = new TransportBusinessLayer().ListTransports().Select(x => new SelectListItem() { Text = x.Name, Value = x.TransportId.ToString() });
            ViewBag.DestinationId = new DestinationBusinessLayer().ListDestinations().Select(x => new SelectListItem() { Text = x.Name, Value = x.DestinationId.ToString() });
            ViewBag.HotelId = new HotelBusinessLayer().ListHoteis().Select(x => new SelectListItem() { Text = x.Name, Value = x.HotelId.ToString() });

            var packageList = new List<PackageEntity>();
            if (TransportId.HasValue && DestinationId.HasValue && HotelId.HasValue)
            {
                packageList = new PackageBusinessLayer().SearchPackage(TransportId.Value, DestinationId.Value, new DateTime(), new DateTime());
            }

            return View(packageList);
        }

        [HttpGet]
        public ActionResult CalculatePrice(int packageId, string additionalServices)
        {
            var package = new PackageBusinessLayer();
            var additionalServicesAux = additionalServices.Split(',').Select(x => Convert.ToInt32(x)).ToList();
            var price = package.CalculatePrice(packageId, additionalServicesAux);
            var packagePrice = new PackageEntity() { Price = price };

            ViewBag.cardOptions = new List<SelectListItem>() {
                    new SelectListItem(){ Text= "Credit Card",Value="1" },
                    new SelectListItem(){ Text= "Debit Card", Value="2"}
                };

            return PartialView("_calculatePrice", packagePrice);
        }

        /// <summary>
        /// Process the Payment of the Package
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BuyPackage(int packageId, decimal price, int cardOptions, string cardNumber, string expirationDate, string cvc)
        {
            var package = new PackageBusinessLayer();
            var clientId = 1;

            var result = package.BuyPackage(packageId, clientId, price, cardOptions, cardNumber, expirationDate, cvc);
            return PartialView("_confirmPayment", result.Item2);
        }

        /// <summary>
        /// Monica and HangDu Use Case Implementation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ViewPackage(int packageId)
        {
            var package = new PackageBusinessLayer().ViewPackage(packageId);
            return View(package);
        }

        /* public ActionResult ManagePackage(int Packageid)
         {
             //Monica, start here
             var list = new PackageBusinessLayer().SearchPackage();

             return View(list);
         }
         public PackageBusinessLayer GetPackage(int packageid)
         { 
           //  var list = new PackageBusinessLayer()
             return View(list);
         }*/
    }
}