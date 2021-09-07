using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Repositories;
using DomainModel.Vehicles;
using Microsoft.EntityFrameworkCore;
using Persistence.Facade;

namespace Persistence.Repositories
{
    public class VehicleRepository: IVehicleRepository
    {
        private readonly DomainModelFacade _dbContext;
        public VehicleRepository(DomainModelFacade dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Vehicle> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Add(Vehicle aggregate)
        {
            _dbContext.Vehicles.Add(aggregate);
            return _dbContext.SaveChanges() >0;
        }

        public Vehicle FindById(int id)
        {
            
            try
            {
                var vehicle = (from c in _dbContext.Vehicles where c.Id == id select c).Single();
                return vehicle;
            }
            catch (InvalidOperationException)
            {
                // return new MissingCustomer();
            }            

            return null;
        }
    }
}