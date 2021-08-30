using DomainModel.Customers;
using DomainModel.Vehicles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Facade
{
    public class DomainModelFacade: IdentityDbContext<User>
    {
        public DomainModelFacade(DbContextOptions<DomainModelFacade> options)
            : base(options)
        {
            Database.EnsureCreated();

            Customers = base.Set<Customer>();
            Vehicles = base.Set<Vehicle>();            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Customer> Customers { get; }
        public DbSet<Vehicle> Vehicles { get; }
    }
}