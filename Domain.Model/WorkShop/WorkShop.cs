using System.Collections;
using System.Collections.Generic;
using DomainModel.Customers;
using DomainModel.Employees;
using DomainModel.Offices;

namespace DomainModel.WorkShops
{
    public class WorkShop
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long AddressId { get; set; }
        public Address Address { get; set; }
        
        public long OfficeId { get; set; }
        public Office Office { get; set; }
        public ICollection<Employee> Repairmans { get; set; }
        public Employee SeniorEmployee { get; set; }
        public List<WorkItemSet> WorkSets { get; set; }
        public List<WorkItemTemplate> WorkItems { get; set; }
        public void AppointSeniorEmployee(Employee employee)
        {
            SeniorEmployee = employee;
        }

        public void TakeRepairman(Employee employee)
        {
            Repairmans.Add(employee);
        }

        public void AddWorkItems(ICollection<WorkItemTemplate> workItemTemplates)
        {
            WorkItems.AddRange(workItemTemplates);
        }
        
        public void AddWorkSet(ICollection<WorkItemSet> WorkItemSets)
        {
            WorkSets.AddRange(WorkItemSets);
        }
        
    }
}