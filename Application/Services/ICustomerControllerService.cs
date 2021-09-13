using Application.InputModels;

namespace Application.Services
{
    public interface ICustomerControllerService
    {
        bool Register(EditCustomerInputModel model);
        bool Edit(EditCustomerInputModel model);
        EditCustomerInputModel GetCustomer(long id);
    }
}