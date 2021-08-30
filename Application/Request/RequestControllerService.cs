using System.Reflection.Metadata;
using Application.InputModels;
using DomainModel.Repositories;
using DomainModel.Vehicles;

namespace Application.Request
{
    public class RequestControllerService: IRequestControllerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IVehicleRepository _vehicleRepository;
        
        public RequestControllerService(
            ICustomerRepository customerRepository,
            IVehicleRepository vehicleRepository)
        {
            _customerRepository = customerRepository;
            _vehicleRepository = vehicleRepository;
        }
        public void CreateRequestFromCustomer(CreateRequestModel model)
        {
            // проверка возможности осуществления ремонта
            // создание заявки
            var customer = _customerRepository.FindById(model.CustomerId);
            var vehicle = model.VehicleId.HasValue ? _vehicleRepository.FindById(model.VehicleId.Value) : new Vehicle();
            customer.CreateRequest(vehicle, model.Description, model.SourceInfo);
        }
    }
}