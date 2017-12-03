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
    public class DestinationController : ApiController
    {
        public List<DestinationEntity> Get()
        {
            var business = new DestinationBusinessLayer();
            return business.ListDestinations();
        }
    }
}
