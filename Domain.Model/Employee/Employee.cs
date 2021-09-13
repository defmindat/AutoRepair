using DomainModel.Offices;

namespace DomainModel.Employees
{
    public class Employee : IAggregateRoot
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string UserId { get; set; }
        public long OfficeId { get; set; }
        public Office Office { get; set; }
        public User User { get; set; }
    }
}