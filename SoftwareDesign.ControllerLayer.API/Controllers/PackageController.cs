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
        public List<PackageEntity> SearchPackage(int transportId, int destinationId, int hotelId)
        {
            return new PackageBusinessLayer().SearchPackage(transportId, destinationId, hotelId, new DateTime(), new DateTime());
        }

        [HttpGet]
        [Route("CalculatePrice/{packageId}/{additionalServices}")]
        public PackageEntity CalculatePrice(int packageId, string additionalServices)
        {
            var package = new BuyPackageBusinessLayer();
            var additionalServicesAux = !string.IsNullOrEmpty(additionalServices) ? additionalServices.Split(',').Select(x => Convert.ToInt32(x)).ToList() : new List<int>();
            var price = package.CalculatePrice(packageId, additionalServicesAux);
            return new PackageEntity()
            {
                PackageId = packageId,
                Price = price
            };
        }

        [HttpGet]
        [Route("GetPackage/{packageId}")]
        public PackageEntity GetPackage(int packageId)
        {
            var package = new PackageBusinessLayer().ViewPackage(packageId);
            return package;
        }
    }
}
