using System.Collections.Generic;
using Domain.Services.DTO;

namespace Domain.Services
{
    public interface IOfficeService
    {
        IEnumerable<CustomerSearchResult> GetCustomers(long officeId, string term);
        IEnumerable<VehicleSearchResult> GetVehicles(long customerId, string term);
        IEnumerable<OfficeSearchResult> GetOffices(string term);
    }
}