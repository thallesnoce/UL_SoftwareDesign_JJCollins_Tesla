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
        //Monica, use this Controller as Reference to the manager package.
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
            // monica and hang usecase implementation 11/11/2017
            var business1 = new PackageBusinessLayer();
            var packages1 = business1.DetailsPackage(Name, PackageId, Description, Price, startDate, endDate);
            return View(Package1);
        }

        // GET: MngPackage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MngPackage/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            { //Insert Logic
                var business2 = new PackageBusinessLayer();
                var packages2 = business2.InsertPackage(Name, PackageId, Description, Price, startDate, endDate);
                return View(packages2);
               // return RedirectToAction("Index");



            }
            catch
            {
                return View();
            }
        }

        // GET: MngPackage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MngPackage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var business3 = new PackageBusinessLayer();
                var package3 = business3.EditPackage(Name,packageId,Description);
                return View(package3);

               // return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MngPackage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MngPackage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var business4 = new PackageBusinessLayer();
                var package4 = business4.DeletePackage(PackageId);
                return View(Package4);

               // return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
