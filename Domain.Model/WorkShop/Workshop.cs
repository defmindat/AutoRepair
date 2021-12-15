using System.Collections.Generic;
using DomainModel.Catalog;
using DomainModel.Customers;
using DomainModel.Employees;
using DomainModel.Offices;

namespace DomainModel.WorkShops
{
    public class Workshop : IIdentifier<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long AddressId { get; set; }
        public Address Address { get; set; }
        
        public long? OfficeId { get; set; }
        public Office Office { get; set; }
        public ICollection<Employee> Repairmans { get; set; }
        public Employee SeniorEmployee { get; set; }
        public List<WorkItem> WorkItems { get; set; }
        // public List<DiagnosticItem> DiagnosticItems { get; set; }
        public void AppointSeniorEmployee(Employee employee)
        {
            SeniorEmployee = employee;
        }

        public void TakeRepairman(Employee employee)
        {
            Repairmans.Add(employee);
        }

        // public void AddWorkItems(ICollection<WorkItemTemplate> workItemTemplates)
        // {
        //     WorkItems.AddRange(workItemTemplates);
        // }
        //
        // public void AddWorkSet(ICollection<WorkItemSet> WorkItemSets)
        // {
        //     WorkSets.AddRange(WorkItemSets);
        // }
        
        public static Workshop Create(string name, string city, string street, string home,
            string flat, string email, string phone)
        {
            var address = new Address
            {
                City = city,
                Street = street,
                Home = home,
                Flat = flat
            };

            var workshop = new Workshop
            {
                Name = name,
                Address = address,
                // Email = email,
                // Phone = phone
            };

            return workshop;
        }
    }
}