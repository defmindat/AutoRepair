using DomainModel.Customers;
using Microsoft.EntityFrameworkCore;
using Persistence.Facade;

namespace Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer, long>
    {
        public CustomerRepository(DomainModelFacade dbContext):base(dbContext)
        {
        }
        protected override DbSet<Customer> GetDbSet() => _dbContext.Customers;
    }
}