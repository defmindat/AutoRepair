using System.Collections.Generic;
using DomainModel.Offices;
using DomainModel.Vehicles;

namespace DomainModel.Customers
{
    public class Customer : IAggregateRoot, IIdentifier<long>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public long AddressId { get; set; }
        public long? OfficeId { get; set; }
        public Office Office { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }

        public Customer AddVehicle(Vehicle vehicle)
        {
            if (vehicle != null)
                Vehicles.Add(vehicle);
            return this;
        }

        public override string ToString() => LastName + " " + FirstName;
    }
}