﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoftwareDesign.DataAccessLayer.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DataModelContainer : DbContext
    {
        public DataModelContainer()
            : base("name=DataModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Destination> Destinations { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Transport> Transports { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Traveler> Travelers { get; set; }
        public virtual DbSet<PackageServices> PackageServices { get; set; }
    }
}
