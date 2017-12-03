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
    [RoutePrefix("api/ManagePackage")]
    public class ManagePackageController : ApiController
    {
        [HttpGet]
        public List<PackageEntity> ListPackages()
        {
            return new ManagePackageBusinessLayer().ListPackage();
        }

        [HttpGet]
        [Route("Delete/{packageId}")]
        public void Delete(int packageId)
        {
            var managePackage = new ManagePackageBusinessLayer();
            managePackage.DeletePackage(packageId);
        }
    }
}
