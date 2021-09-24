using System;
using Application.InputModels;
using AutoMapper;
using DomainModel.Customers;
using DomainModel.Repositories;

namespace Application.Services
{
    public class CustomerControllerService : ICustomerControllerService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerControllerService(ICustomerRepository customerRepository, IMapper mapper,
            IAddressRepository addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
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

        public bool Register(EditCustomerInputModel model)
        {
            if (!model.IsValid())
                return false;

            var customer = Customer.Create(model.FirstName, model.LastName, model.City, model.Street, model.Home,
                model.Flat, model.Email, model.Phone);
            return _customerRepository.Add(customer);
        }

        public bool Edit(EditCustomerInputModel model)
        {
            if (!model.IsValid())
                return false;

            var customer = _mapper.Map<Customer>(model);
            var address = _mapper.Map<Address>(model);

            _addressRepository.Update(address);
            _customerRepository.Update(customer);
            return true;
        }
    }
}