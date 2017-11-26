using SoftwareDesign.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareDesign.View.Controllers
{
    //this an controller class. 
    //to control the view only.
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            //1- Created: a business class in the business SoftwareDesign.ControllerLayer.Business
            //2- Created: a method in that class that returns a list of reportentity(List<ReportEntity>)

            //That new class should call the DataAccessLayer
            //follow the search package example. 
            //but is now report. 
            //var viewedPackages = ReportBusinessLayer.ListViewedPackges();

            //delete these two lines later. after you finish create the steps before
            //replace the fake list with the true return.
            var fakelist = new List<ReportEntity>();
            fakelist.Add(new ReportEntity() { PackageName = "packaage", TotalViews = 10 });
            fakelist.Add(new ReportEntity() { PackageName = "packaage 2", TotalViews = 2 });

            //List is the paramenter to show in the page
            return View(fakelist);
        }

        // GET: Report/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Report/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Report/Create
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

        // GET: Report/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Report/Edit/5
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

        // GET: Report/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Report/Delete/5
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
