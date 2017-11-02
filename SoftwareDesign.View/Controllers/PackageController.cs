using SoftwareDesign.ControllerLayer.Business;
using SoftwareDesign.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareDesign.View.Controllers
{
    public class PackageController : Controller
    {
        // GET: Package
        public ActionResult Index()
        {
            return View();
        }

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

            List<Package> packageList = new List<Package>();
            if (TransportId.HasValue && DestinationId.HasValue && HotelId.HasValue)
            {
                packageList = new PackageBusinessLayer().SearchPackage(TransportId.Value, DestinationId.Value, new DateTime(), new DateTime());
            }

            return View(packageList);
        }

        /// <summary>
        /// Process the Payment of the Package
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BuyPackage(int packageId)
        {
            var package = new PackageBusinessLayer();
            var clientId = 1;//Get Clientid;

            package.BuyPackage(packageId, clientId);
            //TODO: WIP
            //TODO: Check the use case and do this implementation
            return View();
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