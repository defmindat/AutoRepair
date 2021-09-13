using DomainModel.Customers;

namespace Application.InputModels
{
    public class CreateRequestInputModel
    {
        public int CustomerId { get; set; }
        public int? VehicleId { get; set; }
        public string Description { get; set; }
        public SourceInfo SourceInfo { get; set; }
    }
}