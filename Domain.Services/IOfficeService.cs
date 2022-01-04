using System.Collections.Generic;
using Domain.Services.DTO;
using DomainModel.Requests;

namespace Domain.Services
{
    public interface IOfficeService
    {
        IEnumerable<CustomerSearchResult> GetCustomers(long officeId, string term);
        IEnumerable<VehicleSearchResult> GetVehicles(long customerId, string term);
        IEnumerable<OfficeSearchResult> GetOffices(string term);
        ICollection<long> GetSelectedDiagnosticItems(long requestId);
        List<DiagnosticItemDto> GetDiagnosticItems(long officeId);
        Request UpdateRequest(long requestId, IEnumerable<long> diagnosticItems);
        Request UpdateRequest(long requestId, long customerId);
    }
}