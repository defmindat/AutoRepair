using System;
using System.Collections.Generic;
using DomainModel.Vehicles;

namespace DomainModel.Customers
{
    public class Customer: IAggregateRoot
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get;set; }
        public Address Address { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }

        public static Customer Create(string firstname, string lastname, string city, string street, string home, string flat)
        {
            var address = new Address
            {
                City = city,
                Street = street,
                Home = home,
                Flat = flat
            };
            
            var customer = new Customer
            {
                FirstName = firstname,
                LastName = lastname,
                Address = address
            };
            
            return customer;
        }
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