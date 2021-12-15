using DomainModel.Customers;

namespace Application.InputModels
{
    public class EditRequestInputModel
    {
        public long? RequestId { get; set; }
        public long CustomerId { get; set; }
        public long VehicleId { get; set; }
        public long OfficeId { get; set; }
        public SourceInfo? SourceInfo { get; set; }
        public string Description { get; set; }
        
        public bool IsValid() => !(CustomerId == default || VehicleId == default || OfficeId == default);
    }
}