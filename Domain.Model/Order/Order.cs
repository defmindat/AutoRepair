using System;
using System.Collections.Generic;
using DomainModel.Customers;
using DomainModel.Employees;
using DomainModel.Vehicles;
using DomainModel.Works;
using DomainModel.WorkShops;

namespace DomainModel.Orders
{
    public class Order: IAggregateRoot
    {
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
        public Work Work { get; set; }
        public DateTime Date { get; set; }
        public Employee Manager { get; set; }
        
        public Order CreateFromRequest(Request request, Employee manager, ICollection<WorkItemTemplate> workItemTemplates)
        {
            Work work = new Work();
            foreach (var workItemTemplate in workItemTemplates)
            {
                WorkItem.CreateNewForWork(work, new List<SparePartLine>(), workItemTemplate, null);
            }
            var order = new Order
            {
                Customer = request.Customer,
                Date = DateTime.Now,
                Vehicle = request.Vehicle,
                Work = work,
                Manager = manager
            };

            return order;
        }
    }
}