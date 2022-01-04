using System.Collections.Generic;
using DomainModel.Catalog;
using DomainModel.Customers;
using DomainModel.Offices;
using DomainModel.Vehicles;

namespace DomainModel.Requests
{
    public class Request: IAggregateRoot, IIdentifier<long>
    {
        public long Id { get; set; }
        public Customer Customer { get; set; }
        public long CustomerId { get; set; }
        public Office Office { get; set; }
        public long OfficeId { get; set; }
        public Manager Manager { get; set; }
        public string ManagerId { get; set; }
        public Vehicle Vehicle { get; set; }
        public long VehicleId { get; set; }
        public SourceInfo SourceInfo { get; set; }
        // private ICollection<WorkItem> _workItems { get; set; }
        public List<DiagnosticItem> DiagnosticItems { get; set; }
        
        public static Request Create(Customer customer, Office office, Manager manager, Vehicle vehicle, SourceInfo info)
        {
            var request = new Request
            {
                CustomerId = customer.Id, 
                OfficeId = office.Id, 
                ManagerId = manager.Id, 
                VehicleId = vehicle.Id, 
                SourceInfo = info,
                DiagnosticItems = new List<DiagnosticItem>(), 
                // _workItems = new List<WorkItem>(),
                
            };
            return request;
        }

        // public Request AddWorkItem(WorkItem workItem)
        // {
        //     _workItems.Add(workItem);
        //     return this;
        // }
        
        // public Request AddDiagnosticItem(DiagnosticItem diagnosticItem)
        // {
        //     _diagnosticItems.Add(diagnosticItem);
        //     return this;
        // }
    }
}