using System.Threading.Tasks;
using Application;
using Application.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepair.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestControllerService _requestControllerService;

        public RequestController(IRequestControllerService requestControllerService)
        {
            _requestControllerService = requestControllerService;
        }
        
        [HttpGet]
        public IActionResult CreateRequest()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateRequest(CreateRequestModel model)
        {
            _requestControllerService.CreateRequestFromCustomer(model);
            return View();
        }
    }
}