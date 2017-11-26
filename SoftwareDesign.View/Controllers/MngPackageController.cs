using SoftwareDesign.ControllerLayer.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareDesign.View.Controllers
{
    public class MngPackageController : Controller
    {
        /*
         * TN: Monica, You didnt create the pages to handle the Create/Update. You should create that for your use case.
         * 
         * As I mentioned in the email, try to use Scaffolding using the model PackageEntity
         * https://www.google.ie/search?q=scaffolding+mvc+example&oq=scaffolding+mvc&aqs=chrome.3.69i57j0l5.15013j0j7&sourceid=chrome&ie=UTF-8
         */
        // GET: MngPackage
        public ActionResult Index()
        {
            var business = new PackageBusinessLayer();
            var packages = business.SearchPackage(0, 0, 0, new DateTime(), new DateTime()); //Create a method to list all
            return View(packages);
        }


        // GET: MngPackage/Details/5
        public ActionResult Details()
        {
            /*
             TN: Monica, Detail you need to receive an id and use the packageBusinessLayer to get the data from the flatfile.
             */
            //// monica and hang usecase implementation 11/11/2017
            //var business1 = new PackageBusinessLayer();
            //var packages1 = business1.DetailsPackage(Name, PackageId, Description, Price, startDate, endDate);
            //return View(Package1);
            return View();
        }

        // GET: MngPackage/Create
        public ActionResult Create()
        {
            return View();
        }

        /*
         TN: You did right in call insertPackage.
         but the return should be Return View("Index")
         so, after create the package the user will be sent back to the first page with the list of packages
             */
        // POST: MngPackage/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            //try
            //{ //Insert Logic
            //    var business2 = new PackageBusinessLayer();
            //    var packages2 = business2.InsertPackage(Name, PackageId, Description, Price, startDate, endDate);
            //    return View(packages2);
            //}
            //catch
            //{
            //    return View();
            //}
            return View();
        }

        // GET: MngPackage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        /*
         * The EditPackage in businesslayer should be void.
         * The Return should be Return View("Index")
         */
        // POST: MngPackage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            //try
            //{
            //    // TODO: Add update logic here
            //    var business3 = new PackageBusinessLayer();
            //    var package3 = business3.EditPackage(Name,packageId,Description);
            //    return View(package3);

            //   // return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
            return View();
        }

        // GET: MngPackage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        /*
         * The DeletePackage in businessLayer and DataAccessLayer should be void
         * The return should be Return View("Index")
         */
        // POST: MngPackage/Delete/5
        //[HttpPost]
        //  public ActionResult Delete(int id)
        //{
        //try
        //{
        //    // TODO: Add delete logic here
        //    var business4 = new PackageBusinessLayer();
        //    var package4 = business4.DeletePackage(PackageId);
        //    return View(Package4);

        //   // return RedirectToAction("Index");
        //}
        //catch
        //{
        //    return View();
        //}
        //return View();
        //}
    }
}
