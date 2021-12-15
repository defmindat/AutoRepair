using DomainModel.Offices;

namespace DomainModel
{
    public class Manager: User, IIdentifier<string>
    {
        public Office Office { get; set; }
        public long OfficeId { get; set; }
    }
}