using DomainModel.Customers;

namespace Application.InputModels
{
    public class CreateRequestModel
    {
        public int CustomerId { get; set; }
        public int? VehicleId { get; set; } 
        public string Description { get; set; }
        public SourceInfo SourceInfo{ get; set; }
    }
}