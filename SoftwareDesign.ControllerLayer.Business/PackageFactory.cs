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
    public  abstract class PackageFactory
    {
        public abstract IPackage FactoryMethod();
        public abstract IPackage FactoryServiceMethod(IPackage package,int serviceType);
    }
}