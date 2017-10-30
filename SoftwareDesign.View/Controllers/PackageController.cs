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

        // Search: Package
        public ActionResult Search(int transportId, int hotelId, DateTime startDate, DateTime endDate)
        {
            //Put this in the Model Project later
            var listTransport = new List<Transport>() {
                new Transport() { TransportId = 1, Name = "Transport1" },
                new Transport() { TransportId = 2, Name = "Transport2" }
            };
            ViewBag.TransportType = listTransport;
            var list = new PackageBusinessLayer().SearchPackage(transportId, hotelId, startDate, endDate);

            return View(list);
        }

        public ActionResult ViewPackage()
        {
            var package = new PackageBusinessLayer().ViewPackage();

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