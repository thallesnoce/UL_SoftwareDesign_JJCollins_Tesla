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
    public class HotelController : ApiController
    {
        public List<HotelDTO> Get()
        {
            var list = new HotelBusinessLayer().ListHoteis();
            return Mapper.Map<List<HotelDTO>>(list);
        }
    }
}
