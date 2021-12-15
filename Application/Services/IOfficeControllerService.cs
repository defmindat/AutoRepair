using System.Collections.Generic;
using Application.InputModels;
using Application.ViewModels;
using Domain.Services.DTO;
using DomainModel.Requests;

namespace Application.Services
{
    public interface IOfficeControllerService
    {
        bool RegisterNewCustomer(EditCustomerInputModel model, string managerId);
        bool RegisterNewVehicle(EditVehicleInputModel model);
        RequestInitializationViewModel RetrieveRequestInitialization(long officeId, long? requestId, string managerId);
        bool EditCustomer(EditCustomerInputModel model);
        bool EditVehicle(EditVehicleInputModel model);
        EditCustomerInputModel GetCustomer(long id);
        IEnumerable<OfficeSearchResult> RetrieveOffices(string term);
        IEnumerable<CustomerSearchResult> RetrieveCustomers(long officeId, string term);
        IEnumerable<VehicleSearchResult> RetrieveVehicles(long customerId, string term);
        (Request,bool) CreateRequest(EditRequestInputModel model, string managerId);
    }
}