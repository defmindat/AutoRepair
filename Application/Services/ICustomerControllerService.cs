using Application.InputModels;

namespace Application.Services
{
    public interface ICustomerControllerService
    {
        bool Register(RegisterInputModel model);
    }
}