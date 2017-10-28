﻿
using SoftwareDesign.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareDesign.UI.Controllers
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
            //Monica, start here
            var list = new PackageBusinessLayer().SearchPackage(transportId, hotelId, startDate, endDate);

            return View(list);

            
        }
        public ActionResult ViewPackage()
        {
            //Monica, start here
            var list = new PackageBusinessLayer().ViewPackage();

            return View(list);
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