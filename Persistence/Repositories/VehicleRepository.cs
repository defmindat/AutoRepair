using DomainModel.Vehicles;
using Microsoft.EntityFrameworkCore;
using Persistence.Facade;

namespace Persistence.Repositories
{
    public class VehicleRepository : Repository<Vehicle, long>
    {
        public VehicleRepository(DomainModelFacade dbContext): base(dbContext)
        {
        }

        protected override DbSet<Vehicle> GetDbSet() => _dbContext.Vehicles;
    }
}