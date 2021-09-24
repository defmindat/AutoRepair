﻿using DomainModel;
using DomainModel.Customers;
using DomainModel.Offices;
using DomainModel.Vehicles;
using DomainModel.WorkShops;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Facade
{
    public class DomainModelFacade : IdentityDbContext<User>
    {
        public DomainModelFacade(DbContextOptions<DomainModelFacade> options)
            : base(options)
        {
            Database.EnsureCreated();

            Customers = base.Set<Customer>();
            Vehicles = base.Set<Vehicle>();
            Addresses = base.Set<Address>();
            Offices = base.Set<Office>();
            WorkShops = base.Set<Workshop>();
        }

        public DbSet<Customer> Customers { get; }
        public DbSet<Vehicle> Vehicles { get; }
        public DbSet<Address> Addresses { get; }
        public DbSet<Office> Offices { get; }
        public DbSet<Workshop> WorkShops { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}