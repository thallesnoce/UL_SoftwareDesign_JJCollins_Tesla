using SoftwareDesign.ControllerLayer.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareDesign.View.Controllers
{
    public class ManagePackageController : Controller
    {
        // GET: ManagePackage
        public ActionResult Index(int packageId)
        {
            var package = new ManagePackageBusinessLayer();
            return View(package);
        }


    }
}