using SoftwareDesign.ControllerLayer.Business;
using SoftwareDesign.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SoftwareDesign.ControllerLayer.API.Controllers
{
    public class ReportController : ApiController
    {
        public List<ReportEntity> Get()
        {
            var ReportPackage = new ReportBusinessLayer();
            return ReportPackage.ListViewedPackges();
        }
    }
}
