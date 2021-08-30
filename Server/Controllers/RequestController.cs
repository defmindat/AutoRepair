using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.InputModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistence.Models;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //TODO добавить функционал с Identity
    public class RequestController : Controller
    {
        private readonly ILogger<RequestController> _logger;
        private readonly UserManager<User> _userManager;

        private readonly IRequestControllerService _requestControllerService;
    
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
        public async Task<IActionResult> Create(CreateRequestModel model)
        {
            var currentUser = _userManager.GetUserId(HttpContext.User);
            
            _requestControllerService.CreateRequestFromCustomer(model);
            // return View();
            return null;
        }
    }
}