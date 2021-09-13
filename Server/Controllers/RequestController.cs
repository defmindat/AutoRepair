using System.Threading.Tasks;
using Application;
using Application.InputModels;
using DomainModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutoRepair.Controllers
{
    //TODO добавить функционал с Identity
    public class RequestController : Controller
    {
        private readonly ILogger<RequestController> _logger;

        private readonly IRequestControllerService _requestControllerService;
        private readonly UserManager<User> _userManager;

        public RequestController(
            ILogger<RequestController> logger,
            UserManager<User> userManager,
            IRequestControllerService requestControllerService)
        {
            _logger = logger;
            _requestControllerService = requestControllerService;
            _userManager = userManager;
        }

        // [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateRequestInputModel inputModel)
        {
            var currentUser = _userManager.GetUserId(HttpContext.User);

            _requestControllerService.CreateRequestFromCustomer(inputModel);
            // return View();
            return null;
        }
    }
}