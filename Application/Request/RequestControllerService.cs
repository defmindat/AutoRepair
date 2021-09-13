using Application.InputModels;
using DomainModel.Repositories;
using DomainModel.Vehicles;

namespace Application.Request
{
    public class RequestControllerService : IRequestControllerService
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

        public void CreateRequestFromCustomer(CreateRequestInputModel inputModel)
        {
            // проверка возможности осуществления ремонта
            // создание заявки
            var customer = _customerRepository.FindById(inputModel.CustomerId);
            var vehicle = inputModel.VehicleId.HasValue ? _vehicleRepository.FindById(inputModel.VehicleId.Value) : new Vehicle();
            customer.CreateRequest(vehicle, inputModel.Description, inputModel.SourceInfo);
        }
    }
}