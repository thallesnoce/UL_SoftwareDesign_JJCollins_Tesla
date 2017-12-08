using AutoMapper;
using SoftwareDesign.ControllerLayer.Business;
using SoftwareDesign.DTO;
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
        public List<PackageDTO> ListPackages()
        {
            var list = new ManagePackageBusinessLayer().ListPackage();
            return Mapper.Map<List<PackageDTO>>(list);
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
