using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel;
using DomainModel.Repositories;
using Persistence.Facade;

namespace Persistence.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly DomainModelFacade _dbContext;

        public ManagerRepository(DomainModelFacade dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Update(Manager aggregate)
        {
            _dbContext.Managers.Update(aggregate);
            return _dbContext.SaveChanges() > 0;
        }

        public Manager FindById(long id)
        {
            try
            {
                var manager = (from c in _dbContext.Managers where c.Year == id select c).Single();
                return manager;
            }
            catch (InvalidOperationException)
            {
                // return new MissingCustomer();
            }

            return null;
        }

        public IList<Manager> FindAll()
        {
            return _dbContext.Managers.ToList();
        }

        public bool Add(Manager aggregate)
        {
            _dbContext.Managers.Add(aggregate);
            return _dbContext.SaveChanges() > 0;
        }
    }
}