using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareDesign.View.Controllers
{
    public class EnquireController : Controller
    {
        [HttpGet]
        public ActionResult Index(int packageId) {
            return View(); 
        }

        // GET: Enquire
        [HttpGet]
        public ActionResult MakeEnquire(int PackageId, String Message)
        {
            var ClientId = 1;            
            return View();
        }
    }
}


