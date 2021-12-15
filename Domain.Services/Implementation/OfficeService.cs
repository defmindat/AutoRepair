using System.Collections.Generic;
using System.Linq;
using Domain.Services.DTO;
using DomainModel;
using DomainModel.Customers;
using DomainModel.Offices;
using DomainModel.Vehicles;

namespace Domain.Services.Implementation
{
    public class OfficeService: IOfficeService
    {
        private readonly IRepository<Customer, long> _customerRepository;
        private readonly IRepository<Vehicle, long> _vehicleRepository;
        private readonly IRepository<Office, long> _officeRepository;

        public OfficeService(
            IRepository<Customer, long> customerRepository, 
            IRepository<Vehicle, long> vehicleRepository, 
            IRepository<Office, long> officeRepository)
        {
            _customerRepository = customerRepository;
            _vehicleRepository = vehicleRepository;
            _officeRepository = officeRepository;
        }

        public IEnumerable<CustomerSearchResult> GetCustomers(long officeId, string term)
        {
            return _customerRepository.FindAll()
                .Where(c =>
                c.OfficeId == officeId && 
                c.LastName.Contains(term) ||
                c.FirstName.Contains(term))
                .Select(c => new CustomerSearchResult
                {
                    Id = c.Id,
                    DisplayName = c.ToString()
                });
        }

        public IEnumerable<VehicleSearchResult> GetVehicles(long customerId, string term)
        {
            return _vehicleRepository.FindAll()
                .Where(c =>
                    c.CustomerId == customerId && 
                    c.Firm.Contains(term) ||
                    c.Model.Contains(term))
                .Select(c => new VehicleSearchResult
                {
                    Id = c.Id,
                    DisplayName = c.ToString()
                });
        }
        
        public IEnumerable<OfficeSearchResult> GetOffices(string term)
        {
            return _officeRepository.FindAll()
                .Where(c =>
                    c.Name.Contains(term) || string.IsNullOrEmpty(term))
                .Select(c => new OfficeSearchResult()
                {
                    Id = c.Id,
                    DisplayName = c.ToString()
                });
        }
    }
}