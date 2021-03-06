﻿using AutoMapper;
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
    [RoutePrefix("api/Package")]
    public class PackageController : ApiController
    {
        [HttpGet]
        [Route("BuyPackage/{packageId}/{clientId}/{price}/{cardOptions}/{cardNumber}/{expirationDate}/{cvc}")]
        public Tuple<bool, string> BuyPackage(int packageId, int clientId, decimal price, string cardOptions, string cardNumber, string expirationDate, string cvc)
        {
            return new BuyPackageBusinessLayer().EffectivePackageBuy(packageId, price, cardNumber, expirationDate, cvc);
        }

        [HttpGet]
        [Route("SearchPackage/{transportId}/{destinationId}/{hotelId}")]
        public List<PackageDTO> SearchPackage(int transportId, int destinationId, int hotelId)
        {
            var packages = new PackageBusinessLayer().SearchPackage(transportId, destinationId, hotelId, new DateTime(), new DateTime());
            return Mapper.Map<List<PackageDTO>>(packages);
        }

        [HttpGet]
        [Route("CalculatePrice/{packageId}/{additionalServices}")]
        public PackageDTO CalculatePrice(int packageId, string additionalServices)
        {
            var package = new BuyPackageBusinessLayer();
            additionalServices = additionalServices != "0" ? additionalServices : string.Empty;
            var additionalServicesAux = !string.IsNullOrEmpty(additionalServices) ? additionalServices.Split(',').Select(x => Convert.ToInt32(x)).ToList() : new List<int>();
            var price = package.CalculatePrice(packageId, additionalServicesAux);
            var packageEntity = new PackageEntity()
            {
                PackageId = packageId,
                Price = price
            };

            return Mapper.Map<PackageDTO>(packageEntity);
        }

        [HttpGet]
        [Route("GetPackage/{packageId}")]
        public PackageDTO GetPackage(int packageId)
        {
            var package = new PackageBusinessLayer().ViewPackage(packageId);
            return Mapper.Map<PackageDTO>(package);
        }
    }
}
