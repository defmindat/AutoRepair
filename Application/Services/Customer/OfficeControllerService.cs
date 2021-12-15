using System;
using System.Collections.Generic;
using System.Linq;
using Application.InputModels;
using Application.ViewModels;
using AutoMapper;
using Domain.Services;
using Domain.Services.DTO;
using DomainModel;
using DomainModel.Customers;
using DomainModel.Offices;
using DomainModel.Requests;
using DomainModel.Vehicles;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class OfficeControllerService : IOfficeControllerService
    {
        private readonly IRepository<Manager, string> _managerRepository;
        private readonly IRepository<Address, long> _addressRepository;
        private readonly IRepository<Customer, long> _customerRepository;
        private readonly IRepository<Office, long> _officeRepository;
        private readonly IRepository<Request, long> _requestRepository;
        private readonly IRepository<Vehicle, long> _vehicleRepository;
        private readonly UserManager<User> _userManager;
        private readonly IOfficeService _officeService;
        private readonly IMapper _mapper;

        public OfficeControllerService(IRepository<Customer,long> customerRepository, IMapper mapper,
            IRepository<Address, long> addressRepository, IRepository<Manager, string> managerRepository, IRepository<Office, long> officeRepository, IRepository<Request, long> requestRepository, IOfficeService officeService, IRepository<Vehicle, long> vehicleRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _managerRepository = managerRepository;
            _officeRepository = officeRepository;
            _requestRepository = requestRepository;
            _officeService = officeService;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public EditCustomerInputModel GetCustomer(long id)
        {
            if (id <= 0)
                throw new ArgumentException("Id клиента не определен");
            var customer = _customerRepository.FindById(id);
            customer.Address = _addressRepository.FindById(customer.AddressId);

            var model = _mapper.Map<EditCustomerInputModel>(customer);
            return model;
        }

        public bool RegisterNewCustomer(EditCustomerInputModel model, string managerId)
        {
            if (!model.IsValid())
                return false;

            var manager = _managerRepository.FindById(managerId);
            var office = _officeRepository.FindById(manager.OfficeId);
            var customer = Office.CreateCustomer(model.FirstName, model.LastName, model.City, model.Street, model.Home,
                model.Flat, model.Email, model.Phone, office.Id);
            return _customerRepository.Add(customer);
        }

        public bool RegisterNewVehicle(EditVehicleInputModel model)
        {
            if (!model.IsValid())
                return false;

            var vehicle = Office.CreateVehicle(model.CustomerId, model.Firm, model.ModelName, model.Year, model.EngineVolume, model.HandSide);
            return _vehicleRepository.Add(vehicle);
        }

        public bool EditCustomer(EditCustomerInputModel model)
        {
            if (!model.IsValid())
                return false;

            var customer = _mapper.Map<Customer>(model);
            var address = _mapper.Map<Address>(model);

            _addressRepository.Update(address);
            _customerRepository.Update(customer);
            return true;
        }

        public bool EditVehicle(EditVehicleInputModel model)
        {
            if (!model.IsValid())
                return false;

            var vehicle = _mapper.Map<Vehicle>(model);
            var customer = _mapper.Map<Customer>(model);
            
            _customerRepository.Update(customer);
            _vehicleRepository.Update(vehicle);
            return true;
        }

        public RequestInitializationViewModel RetrieveRequestInitialization(long officeId, long? requestId, string managerId)
        {
            if (!requestId.HasValue)
            {
                var manager = _managerRepository.FindById(managerId);
                var customers = _customerRepository.FindAll().Where(x => x.OfficeId == manager.OfficeId);
                return new RequestInitializationViewModel
                {
                    Customers = customers,
                    ManagerId = managerId,
                    OfficeId = officeId
                };
            }

            var request = _requestRepository.FindById(requestId.Value);
            var customer = _customerRepository.FindById(request.CustomerId);
            var vehicle = _vehicleRepository.FindById(request.VehicleId);
            return new RequestInitializationViewModel{CustomerId = customer.Id, OfficeId = officeId, VehicleId = vehicle.Id, CustomerFullName = customer.ToString(), VehicleName = vehicle.ToString(), ManagerId= request.ManagerId};
        }

        public (Request,bool) CreateRequest(EditRequestInputModel model, string managerId)
        {
            if (!model.IsValid())
                return (null, false);

            var office = _officeRepository.FindById(model.OfficeId);
            var manager = _managerRepository.FindById(managerId);
            var customer = _customerRepository.FindById(model.CustomerId);
            var vehicle = _vehicleRepository.FindById(model.VehicleId);

            var request = Office.CreateRequest(office, manager, customer, vehicle);
            _requestRepository.Add(request);
            
            return (request, true);
        }

        public IEnumerable<CustomerSearchResult> RetrieveCustomers(long officeId, string term)
        {
            if (officeId == default)
            {
                throw new Exception("Не указан Id офиса");
            }

            return _officeService.GetCustomers(officeId, term);
        }

        public IEnumerable<VehicleSearchResult> RetrieveVehicles(long customerId, string term)
        {
            if (customerId == default)
                throw new Exception("Не указан Id клиента");
            return _officeService.GetVehicles(customerId, term);
        }
        
        public IEnumerable<OfficeSearchResult> RetrieveOffices(string term)
        {
            return _officeService.GetOffices(term);
        }
        
    }
}