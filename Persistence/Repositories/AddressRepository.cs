using DomainModel.Customers;
using Microsoft.EntityFrameworkCore;
using Persistence.Facade;

namespace Persistence.Repositories
{
    public class AddressRepository : Repository<Address, long>
    {
        public AddressRepository(DomainModelFacade domainModelFacade) : base(domainModelFacade)
        {
        }

        protected override DbSet<Address> GetDbSet() => _dbContext.Addresses;
    }
}