using SoftwareDesign.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SoftwareDesign.Entities.Enums.Enums;

namespace SoftwareDesign.ControllerLayer.Business
{
    /// <summary>
    /// Design Pattern Factory
    /// </summary>
    public class PackageFactory
    {
        

        public static IPackage CreatePackageInstance()
        {
            var package = new PackageEntity() { };

            return package;
        }
        //Create a static method "CreatePackageServiceInstace" that receives IPackage and int
        public static IPackage CreatePackageServiceInstance(IPackage package, int ServiceType)
         {
            if (ServiceType == (int)Entities.Enums.Enums.ServiceType.HonneyMoon)
            {
                return new HoneyMoonPackage(package);
            }

            else if (ServiceType == (int)Entities.Enums.Enums.ServiceType.BachelorPartyHoliday)
            {
                return new BachelorPartyPackage(package);
            }

            else if (ServiceType == (int)Entities.Enums.Enums.ServiceType.BirthDayParty)
            {
                return new BirthDayPartyPackage(package);
            }
            else return null;
        }
    }





      
    }
