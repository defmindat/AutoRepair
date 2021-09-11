using System;
using System.Collections.Generic;
using DomainModel.Vehicles;

namespace DomainModel.Customers
{
    public class Customer: IAggregateRoot
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get;set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public long AddressId { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }

        public static Customer Create(string firstname, string lastname, string city, string street, string home, string flat, string email, string phone)
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
                Address = address,
                Email = email,
                Phone = phone
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