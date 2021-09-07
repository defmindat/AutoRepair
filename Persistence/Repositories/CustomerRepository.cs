using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Customers;
using DomainModel.Repositories;
using Persistence.Facade;

namespace Persistence.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly DomainModelFacade _dbContext;
        public CustomerRepository(DomainModelFacade dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer FindById(int id)
        {            
            try
            {
                var customer = (from c in _dbContext.Customers where c.Id == id select c).Single();
                return customer;
            }
            catch (InvalidOperationException)
            {
                // return new MissingCustomer();
            }
            return null;
        }

        public IList<Customer> FindAll()
        {
            throw new NotImplementedException();
        }

        public bool Add(Customer aggregate)
        {
            _dbContext.Customers.Add(aggregate);
            return _dbContext.SaveChanges() >0;
        }
    }
}