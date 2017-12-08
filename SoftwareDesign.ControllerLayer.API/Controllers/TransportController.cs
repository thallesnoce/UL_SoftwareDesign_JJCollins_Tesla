using AutoMapper;
using SoftwareDesign.ControllerLayer.Business;
using SoftwareDesign.DTO;
using System.Collections.Generic;
using System.Web.Http;

namespace SoftwareDesign.ControllerLayer.API.Controllers
{
    public class TransportController : ApiController
    {
        public List<TransportDTO> Get()
        {
            var list = new TransportBusinessLayer().ListTransports();
            return Mapper.Map<List<TransportDTO>>(list);
        }
    }
}