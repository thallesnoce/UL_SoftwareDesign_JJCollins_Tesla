using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static SoftwareDesign.Entities.Enums.Enums;
using Moq;

namespace SoftwareDesign.ControllerLayer.Business.Test
{
    [TestClass]
    public class PackageTest
    {
        /// <summary>
        /// Thalles and Jessie Use Case Implementation
        /// </summary>
        [TestMethod]
        public void SearchPackage_Success()
        {
            var package = new PackageBusinessLayer();
            package.SearchPackage(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>());
        }

        /// <summary>
        /// Monica and Hang Du Use Case Implementation
        /// Test for View Package function
        /// </summary>
        [TestMethod]
        public void ViewPackage_Success()
        {
            var package = new PackageBusinessLayer();
            package.GetPackage(It.IsAny<int>());
        }

        /// <summary>
        /// Monica and Hang Use Case Implementation
        /// Test for Manage Package function
        /// </summary>
        [TestMethod]
        public void ManagePackage_Success()
        {
            var package = new PackageBusinessLayer();
            package.InsertPackage(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>());
            package.EditPackage(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>());
            package.DeletePackage(It.IsAny<int>());
        }
    }
}