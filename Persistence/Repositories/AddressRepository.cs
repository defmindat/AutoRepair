using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Customers;
using DomainModel.Repositories;
using Persistence.Facade;

namespace Persistence.Repositories
{
    public class AddressRepository: IAddressRepository
    {
        private readonly DomainModelFacade _dbContext;

        public AddressRepository(DomainModelFacade dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Address> FindAll() => _dbContext.Addresses.ToList();

        public bool Add(Address aggregate)
        {
            _dbContext.Addresses.Add(aggregate);
            return _dbContext.SaveChanges() >0;
        }

        public bool Update(Address aggregate)
        {
            _dbContext.Addresses.Update(aggregate);
            return _dbContext.SaveChanges() > 0;
        }

        public Address FindById(long id)
        {
            try
            {
                var address = (from c in _dbContext.Addresses where c.Id == id select c).Single();
                return address;
            }
            catch (InvalidOperationException)
            {
                // return new MissingCustomer();
            }
            return null;
        }
    }
}