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
        public List<PackageEntity> AddPackage(String Name, int PackageId, String Description, int Price, DateTime startDate, DateTime endDate)
        {
            //TODO: Use a design pattern to create an instance of Repository
            PackageDataAccess obj = new PackageDataAccess();
            obj.AddPackage(Name, PackageId, Description, Price, startDate, endDate);
            return null;//new PackageDataAccess().InsertPackage(Name, PackageId, Description, Price, startDate,endDate);
        }

        public List<PackageEntity> EditPackage(String Name, int PackageId, String Description, int Price, DateTime startDate, DateTime endDate)
        {
            PackageDataAccess obj = new PackageDataAccess();
            obj.EditPackage(Name, PackageId, Description, Price, startDate, endDate);
            return null;// new PackageDataAccess().EditPackage(PackageId);
        }


        public List<PackageEntity> DeletePackage(int PackageId)
        {
            PackageDataAccess obj = new PackageDataAccess();
            obj.DeletePackage(PackageId);
            //TODO: Use a design pattern to create an instance of Repository
            return null;// new PackageDataAccess().DeletePackage( PackageId);
        }

        public List<PackageEntity> ListPackage()
        {
            var dataAccess = new PackageDataAccess();
            var packages = dataAccess.ListPackage();
            return packages;
        }

        public PackageEntity GetPackage(int PackageId)
        {
            return new PackageDataAccess().GetPackage(PackageId);
        }
    }
}