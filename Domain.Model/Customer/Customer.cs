using System;
using DomainModel.Vehicles;

namespace DomainModel.Customers
{
    public class Customer: IAggregateRoot
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get;set; }
        public Address Address { get; set; }

        public Request CreateRequest(Vehicle vehicle, string description, SourceInfo sourceInfo)
        {
            var request = new Request
            {
                Vehicle = vehicle,
                Description = description,
                Source = sourceInfo,
                Date = DateTime.Now,
                Customer = this
            };
            return request;
        }
    }
}