using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareDesign.Entities;

namespace SoftwareDesign.ControllerLayer.Business
{
    public class ConcretePackageFactory : PackageFactory
    {
        /// <summary>
        /// concrete creator:ConcretePackage factory
        /// creator: PackageFactory
        /// This method created a factory method package
        /// </summary>
        /// <returns></returns>
        public override IPackage FactoryMethod()
        {
            return new PackageEntity();
        }

        /// <summary>
        /// This method creates a factory for the packages services with respect to the decorator pattern
        /// </summary>
        /// <param name="package"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public override IPackage FactoryServiceMethod(IPackage package, int serviceType)
        {
            if (serviceType == (int)Entities.Enums.Enums.ServiceType.HonneyMoon)
            {
                return new HoneyMoonPackage(package);
            }

            else if (serviceType == (int)Entities.Enums.Enums.ServiceType.BachelorPartyHoliday)
            {
                return new BachelorPartyPackage(package);
            }

            else if (serviceType == (int)Entities.Enums.Enums.ServiceType.BirthDayParty)
            {
                return new BirthDayPartyPackage(package);
            }
            else return null;
        }
    }

}




