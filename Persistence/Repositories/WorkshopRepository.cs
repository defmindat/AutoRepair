using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Repositories;
using DomainModel.Vehicles;
using DomainModel.WorkShops;
using Persistence.Facade;

namespace Persistence.Repositories
{
    public class WorkshopRepository: IWorkshopRepository
    {
        private readonly DomainModelFacade _dbContext;

        public WorkshopRepository(DomainModelFacade dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IList<Workshop> FindAll()
        {
            return _dbContext.WorkShops.ToList();
        }

        public bool Add(Workshop aggregate)
        {
            _dbContext.WorkShops.Add(aggregate);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(Workshop aggregate)
        {
            _dbContext.WorkShops.Update(aggregate);
            return _dbContext.SaveChanges() > 0;
        }

        public Workshop FindById(long id)
        {
            try
            {
                var workshop = (from c in _dbContext.WorkShops where c.Id == id select c).Single();
                return workshop;
            }
            catch (InvalidOperationException)
            {
                // return new MissingCustomer();
            }

            return null;
        }
    }
}