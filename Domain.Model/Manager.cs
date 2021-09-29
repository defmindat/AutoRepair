using DomainModel.Offices;

namespace DomainModel
{
    public class Manager: User
    {
        public Office Office { get; set; }
    }
}