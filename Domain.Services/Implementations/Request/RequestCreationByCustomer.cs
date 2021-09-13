using Domain.Services.Interfaces.Request;
using DomainModel.Customers;
using DomainModel.Vehicles;

namespace Domain.Services.Implementations.Request
{
    public class RequestCreationByCustomer : IRequestCreationByCustomer
    {
        public void Execute(Customer customer, Vehicle vehicle, string description, SourceInfo sourceInfo)
        {
            customer.CreateRequest(vehicle, description, sourceInfo);
        }
    }
}