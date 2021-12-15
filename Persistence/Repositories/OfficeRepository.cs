using DomainModel.Offices;
using Microsoft.EntityFrameworkCore;
using Persistence.Facade;

namespace Persistence.Repositories
{
    public class OfficeRepository: Repository<Office, long>
    {
        public OfficeRepository(DomainModelFacade dbContext): base(dbContext)
        {
        }

        protected override DbSet<Office> GetDbSet() => _dbContext.Offices;
    }
}