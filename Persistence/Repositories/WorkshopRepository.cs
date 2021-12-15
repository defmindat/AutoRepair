using DomainModel.WorkShops;
using Microsoft.EntityFrameworkCore;
using Persistence.Facade;

namespace Persistence.Repositories
{
    public class WorkshopRepository: Repository<Workshop, long>
    {
        public WorkshopRepository(DomainModelFacade dbContext): base(dbContext)
        {
            
        }

        protected override DbSet<Workshop> GetDbSet() => _dbContext.WorkShops;
    }
}