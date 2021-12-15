using System.Collections.Generic;
using DomainModel.Customers;

namespace Application.ViewModels
{
    public class RequestInitializationViewModel
    {
        public long? RequestId { get; set; }
        public long OfficeId { get; set; }
        public string ManagerId { get; set; }
        public long? CustomerId { get; set; }
        public long? VehicleId { get; set; }
        public string CustomerFullName { get; set; }
        public string VehicleName { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}