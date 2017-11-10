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
        public ActionResult Details(int id)
        {
            return View();
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
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
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

                return RedirectToAction("Index");
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

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
