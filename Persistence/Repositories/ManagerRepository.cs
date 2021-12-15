using DomainModel;
using Microsoft.EntityFrameworkCore;
using Persistence.Facade;

namespace Persistence.Repositories
{
    public class ManagerRepository : Repository<Manager, string>
    {
        public ManagerRepository(DomainModelFacade domainModelFacade) : base(domainModelFacade)
        {
        }


        protected override DbSet<Manager> GetDbSet() => _dbContext.Managers;
    }
}