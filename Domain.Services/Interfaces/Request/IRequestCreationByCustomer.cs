using DomainModel.Customers;
using DomainModel.Vehicles;

namespace Domain.Services.Interfaces.Request
{
    public interface IRequestCreationByCustomer
    {
        void Execute(Customer customer, Vehicle vehicle, string description, SourceInfo sourceInfo);
    }
}