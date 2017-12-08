using SoftwareDesign.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;


namespace SoftwareDesign.View.Controllers
{
    public class ReportController : Controller
    {
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

            var reports = new List<ReportDTO>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54155/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Report");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<ReportDTO>>();
                    readTask.Wait();

                    reports = readTask.Result;
                }
            }

            return View(reports);
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
