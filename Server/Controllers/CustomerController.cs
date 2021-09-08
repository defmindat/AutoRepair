using Application.InputModels;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepair.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerControllerService _service;

        public CustomerController(ICustomerControllerService customerControllerService)
        {
            _service = customerControllerService;
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RegisterInputModel model)
        {
            var succeeded = _service.Register(model);
            if (succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("failed", "Возникли ошибки при заполнении формы. Проверьте, пожалуйста, правильность и полноту заполнения.");
            return View(model);
        }
    }
}