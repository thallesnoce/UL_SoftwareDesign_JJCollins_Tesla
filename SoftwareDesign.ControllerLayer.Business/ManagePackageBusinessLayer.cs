using SoftwareDesign.DataAccessLayer;
using SoftwareDesign.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.ControllerLayer.Business
{
    public class ManagePackageBusinessLayer  
    {
        public List<PackageEntity> ListPackage()
        {
            return new PackageDataAccess().ListPackage();
        }

        public PackageEntity GetPackage(int PackageId)
        {
            return new PackageDataAccess().GetPackage(PackageId);
        }
    }
}