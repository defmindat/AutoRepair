using Application.InputModels;

namespace Application.Services
{
    public interface ICustomerControllerService
    {
        bool Register(RegisterInputModel model);
        bool Edit(RegisterInputModel model);
        RegisterInputModel GetCustomer(long id);
    }
}