using System.Collections.Generic;
using System.Linq;
using Domain.Services.DTO;
using DomainModel;
using DomainModel.Catalog;
using DomainModel.Customers;
using DomainModel.Offices;
using DomainModel.Requests;
using DomainModel.Vehicles;

namespace Domain.Services.Implementation
{
    public class OfficeService: IOfficeService
    {
        private readonly IRepository<Customer, long> _customerRepository;
        private readonly IRepository<Vehicle, long> _vehicleRepository;
        private readonly IRepository<Office, long> _officeRepository;
        private readonly IRepository<DiagnosticItem, long> _diagnosticItemsRepository;
        private readonly IRepository<Request, long> _requestRepository;

        public OfficeService(
            IRepository<Customer, long> customerRepository, 
            IRepository<Vehicle, long> vehicleRepository, 
            IRepository<Office, long> officeRepository, 
            IRepository<DiagnosticItem, long> diagnosticItemsRepository, 
            IRepository<Request, long> requestRepository)
        {
            _customerRepository = customerRepository;
            _vehicleRepository = vehicleRepository;
            _officeRepository = officeRepository;
            _diagnosticItemsRepository = diagnosticItemsRepository;
            _requestRepository = requestRepository;
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

        public List<DiagnosticItemDto> GetDiagnosticItems(long requestId)
        {
            return _diagnosticItemsRepository.FindAll()
                .Select(x => new DiagnosticItemDto {Id = x.Id, DisplayName = x.ToString()}).ToList();
        }
        
        public ICollection<long> GetSelectedDiagnosticItems(long requestId)
        {
            var diagnosticItemIds = _requestRepository.FindAll().Where(x => x.Id == requestId).SelectMany(x => x.DiagnosticItems.Select(i => i.Id)).ToList();
            return diagnosticItemIds;
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

        public Request UpdateRequest(long requestId, IEnumerable<long> diagnosticItems)
        {
            var request = _requestRepository.FindById(requestId);
            request.DiagnosticItems = new List<DiagnosticItem>();
            var addedItems = _diagnosticItemsRepository.FindAll().Where(x => diagnosticItems.Contains(x.Id));
            request.DiagnosticItems.AddRange(addedItems);
            return request;
        }

        public Request UpdateRequest(long requestId, long customerId)
        {
            var request = _requestRepository.FindById(requestId);
            request.CustomerId = customerId;
            return request;
        }
    }
}