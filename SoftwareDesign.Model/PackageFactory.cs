using SoftwareDesign.Entities;

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