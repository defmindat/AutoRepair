using System;
using System.Collections.Generic;
using DomainModel.Employees;
using DomainModel.WorkShops;

namespace DomainModel.Works
{
    public class WorkItem
    {
        public Employee Employee { get; set; }
        public DateTime Date { get; set; }
        public ICollection<SparePartLine> SparePartLines { get; set; }
        public WorkItemTemplate WorkItemTemplate { get; set; }

        public static WorkItem CreateNewForWork(Work work, ICollection<SparePartLine> lines, WorkItemTemplate template,
            Employee employee)
        {
            var item = new WorkItem
            {
                WorkItemTemplate = template,
                Date = DateTime.Now,
                Employee = employee,
                SparePartLines = lines
            };
            return item;
        }

        public void SetEmployee(Employee employee)
        {
            Employee = employee;
        }
    }
}