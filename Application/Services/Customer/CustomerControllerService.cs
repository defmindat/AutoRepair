using Application.InputModels;
using DomainModel.Customers;
using DomainModel.Repositories;

namespace Application.Services
{
    public class CustomerControllerService: ICustomerControllerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerControllerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool Register(RegisterInputModel model)
        {
            if (model.IsValid())
                return false;
            
            var customer = Customer.Create(model.FirstName, model.LastName, model.City, model.Street, model.Home, model.Flat);
            return _customerRepository.Add(customer);
        }
    }
}