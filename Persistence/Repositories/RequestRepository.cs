using DomainModel.Requests;
using Microsoft.EntityFrameworkCore;
using Persistence.Facade;

namespace Persistence.Repositories
{
    public class RequestRepository: Repository<Request, long>
    {
        public RequestRepository(DomainModelFacade dbContext): base(dbContext)
        {
        }

        protected override DbSet<Request> GetDbSet() => _dbContext.Requests;
    }
}