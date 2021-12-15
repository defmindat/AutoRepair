using DomainModel;
using DomainModel.Catalog;
using DomainModel.Customers;
using DomainModel.Offices;
using DomainModel.Requests;
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
            Managers = base.Set<Manager>();
            Vehicles = base.Set<Vehicle>();
            Addresses = base.Set<Address>();
            Offices = base.Set<Office>();
            WorkShops = base.Set<Workshop>();
            DiagnosticItems = base.Set<DiagnosticItem>();
            WorkItems = base.Set<WorkItem>();
            Requests = base.Set<Request>();
        }

        public DbSet<Customer> Customers { get; }
        public DbSet<Manager> Managers { get; }
        public DbSet<Vehicle> Vehicles { get; }
        public DbSet<Address> Addresses { get; }
        public DbSet<Office> Offices { get; }
        public DbSet<Workshop> WorkShops { get; }
        public DbSet<Request> Requests { get; }
        public DbSet<DiagnosticItem> DiagnosticItems { get; }
        public DbSet<WorkItem> WorkItems { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Add the shadow property to the model

            // Use the shadow property as a foreign key
            builder.Entity<Request>()
                .HasOne(p => p.Office)
                .WithMany(b => b.Requests)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Request>()
                .HasOne(v => v.Vehicle)
                .WithMany(x => x.Requests)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}