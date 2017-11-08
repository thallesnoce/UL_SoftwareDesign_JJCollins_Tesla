using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.Entities
{
    ///*
    ///Implementation of Decorator Design Pattern
    ///
    /// Pair @Thalles and Jessie
    /// */

    /// <summary>
    /// Component class
    /// </summary>
    public interface IPackage
    {
        int PackageId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }

        decimal GetPrice();
    }

    /// <summary
    /// >
    /// Concrete Component
    /// </summary>
    public class PackageEntity : IPackage
    {
        public int PackageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual HotelEntity Hotel { get; set; }
        public virtual TransportEntity Transport { get; set; }
        public virtual DestinationEntity Destination { get; set; }
        //public virtual Payment Payment { get; set; }
        public virtual ClientEntity Client { get; set; }

        public decimal GetPrice()
        {
            return this.Price;
        }
    }

    /// <summary>
    /// Decorator
    /// </summary>
    public abstract class PackageServices : IPackage
    {
        public int PackageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        private IPackage package;

        public PackageServices(IPackage package)
        {
            this.package = package;
        }

        public virtual decimal GetPrice()
        {
            return this.package.GetPrice();
        }
    }

    /// <summary>
    /// Concrete Decorator
    /// 
    /// HoneyMoon service added to the package
    /// </summary>
    public class HoneyMoonPackage : PackageServices
    {
        private decimal honeyMoonAddicionalPrice = 800.50M;

        public HoneyMoonPackage(IPackage package) : base(package)
        {
        }

        public override decimal GetPrice()
        {
            return base.GetPrice() + honeyMoonAddicionalPrice;
        }
    }

    /// <summary>
    /// Concrete Decorator
    /// 
    /// Bachelor Party service added to the package
    /// </summary>
    public class BachelorPartyPackage : PackageServices
    {
        private decimal bachelorAddicionalPrice = 1050.00M;

        public BachelorPartyPackage(IPackage package) : base(package)
        {
        }

        public override decimal GetPrice()
        {
            return base.GetPrice() + bachelorAddicionalPrice;
        }
    }

    /// <summary>
    /// Concrete Decorator
    /// 
    /// BirthDay service added to the package
    /// </summary>
    public class BirthDayPartyPackage : PackageServices
    {
        private decimal birthDayAddicionalPrice = 100M;

        public BirthDayPartyPackage(IPackage package) : base(package)
        {
        }

        public override decimal GetPrice()
        {
            return base.GetPrice() + birthDayAddicionalPrice;
        }
    }
}