using System.Collections.Generic;
using System.Linq;
using DomainModel.Catalog;
using DomainModel.Customers;
using DomainModel.Employees;
using DomainModel.Requests;
using DomainModel.Vehicles;
using DomainModel.WorkShops;

namespace DomainModel.Offices
{
    public sealed class Office : IAggregateRoot, IIdentifier<long>
    {
        public long Id { get; set; }
        public string Name { get; private set; }
        public long AddressId { get; private set;}
        public Address Address { get; set;}
        public string Phone { get; private set; }
        public string Inn { get; private set;}
        public List<Workshop> Workshops { get; set; }
        public List<Employee> Managers { get; set; }
        public List<Request> Requests { get; set; }
        public List<Customer> Customers { get; set; }
        public List<DiagnosticItem> DiagnosticItems { get; set; }

        public static Office Create(string name, string city, string street, string home,
            string flat, string phone, string inn)
        {
            var office = new Office();
            var address = new Address
            {
                City = city,
                Street = street,
                Home = home,
                Flat = flat
            };
            office.SetAddress(address);
            office.Name = name;
            office.Phone = phone;
            office.Inn = inn;
            office.Workshops = new List<Workshop>();
            office.Managers = new List<Employee>();
            office.Requests = new List<Request>();
            office.Customers = new List<Customer>();
            office.DiagnosticItems = new List<DiagnosticItem>();
            return office;
        }
        public Office SetAddress(Address address)
        {
            if (address != null)
                Address = address;

            return this;      
        }

        public Address GetAddress()
        {
            return Address;
        }

        public Office SetManager(Employee manager)
        {
            if (manager != null)
                Managers.Add(manager);
            return this;
        }

        public IEnumerable<Customer> GetCustomers() => Customers;

        public Office AddCustomer(Customer customer)
        {
            Customers.Add(customer);
            return this;
        }
        public IEnumerable<WorkItem> GetAvailableWorkItems()
        {
            var workItems = Workshops.SelectMany(x => x.WorkItems);
            return workItems;
        }

        // public IEnumerable<DiagnosticItem> GetAvailableDiagnosticItems()
        // {
        //     var diagnostics = Workshops.SelectMany(x => x.DiagnosticItems);
        //     return diagnostics;
        // }

        public static Customer CreateCustomer(string firstname, string lastname, string city, string street, string home,
            string flat, string email, string phone, long officeId)
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
                Phone = phone,
                OfficeId = officeId,
                Vehicles = new List<Vehicle>()
            };

            return customer;
        }
        public static Request CreateRequest(Office office, Manager manager, Customer customer, Vehicle vehicle)
        {
            var request = Request.Create(customer, office, manager, vehicle, SourceInfo.Internet);

            return request;
        }
        
        public static Vehicle CreateVehicle(long customerId, string firm, string model, short year, float engineVolume, HandSide handSide)
        {
            var vehicle = new Vehicle()
            {
                CustomerId = customerId,
                Firm = firm,
                Model = model, 
                Year = year,
                EngineVolume = engineVolume,
                HandSide = handSide
            };

            return vehicle;
        }

        public override string ToString() => $"{Name} {Address?.City} {Address?.Street} {Address?.Flat}";
    }
}