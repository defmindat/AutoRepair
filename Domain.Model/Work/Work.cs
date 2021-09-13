using System.Collections.Generic;
using DomainModel.Employees;

namespace DomainModel.Works
{
    public class Work : IAggregateRoot
    {
        public ICollection<WorkItem> WorkItems { get; set; }
        public Employee Supervisor { get; set; }

        public Work Create(ICollection<WorkItem> workItems, Employee supervisor)
        {
            var work = new Work
            {
                WorkItems = workItems,
                Supervisor = supervisor
            };
            return work;
        }
    }
}