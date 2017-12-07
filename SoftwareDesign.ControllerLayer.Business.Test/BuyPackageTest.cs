using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static SoftwareDesign.Entities.Enums.Enums;
using Moq;

namespace SoftwareDesign.ControllerLayer.Business.Test
{
    [TestClass]
    public class BuyPackageTest
    {
        /// <summary>
        /// Thalles and Jessie Use Case Implementation
        /// </summary>
        [TestMethod]
        public void BuyPackage_AdditionalServices_Success()
        {
            /*Price for Package 1 is 500 eruos*/
            var packageId = 1;
            var clientId = 2;

            /*ServiceType.BachelorPartyHoliday
             Adds 1050.00 euro to the package price 
             */

            /*ServiceType.BirthDayParty
             Adds 100 euro to price            
             */

            var aditionalServices = new List<int>() { (int)ServiceType.BachelorPartyHoliday, (int)ServiceType.BirthDayParty };

            var package = new BuyPackageBusinessLayer();
            var price = package.CalculatePrice(packageId, aditionalServices);

            Assert.IsTrue(price == 1650M);
        }

        /// <summary>
        /// Thalles and Jessie Use Case Implementation
        /// </summary>
        [TestMethod]
        public void BuyPackage_AdditionalServices_Error()
        {
            /*Price for Package 1 is 500 eruos*/
            var packageId = 1;
            var clientId = 2;

            /*ServiceType.BachelorPartyHoliday
             Adds 1050.00 euros to the package price 
             */

            /*ServiceType.HonneyMoon
             Adds 800.50 euros to price            
             */

            var aditionalServices = new List<int>() { (int)ServiceType.BachelorPartyHoliday, (int)ServiceType.HonneyMoon };

            var package = new BuyPackageBusinessLayer();
            var price = package.CalculatePrice(packageId, aditionalServices);

            //Assertin with a wrong value.
            Assert.IsFalse(price == 1650M);
        }
    }
}