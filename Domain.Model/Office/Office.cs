using DomainModel.Employees;

namespace DomainModel.Offices
{
    public class Office: IAggregateRoot
    {
        public Employee Manager { get; set; }
    }
}