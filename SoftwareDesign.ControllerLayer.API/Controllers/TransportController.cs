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
    public class TransportController : ApiController
    {
        public List<TransportEntity> Get()
        {
            var business = new TransportBusinessLayer();
            return business.ListTransports();
        }
    }
}