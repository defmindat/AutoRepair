using Application.InputModels;

namespace Application
{
    public interface IRequestControllerService
    {
        void CreateRequestFromCustomer(CreateRequestInputModel inputModel);
    }
}