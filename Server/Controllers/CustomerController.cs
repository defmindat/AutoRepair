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

        [HttpGet]
        public IActionResult Edit(long id)
        {
            return View(id != default ? _service.GetCustomer(id) : null);
        }

        [HttpPost]
        public IActionResult Edit(EditCustomerInputModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == default)
                {
                    var succeeded = _service.Register(model);
                    if (succeeded) return RedirectToAction("Index", "Home");
                }

                var editSucceeded = _service.Edit(model);
                if (editSucceeded) return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("failed",
                "Возникли ошибки при заполнении формы. Проверьте, пожалуйста, правильность и полноту заполнения.");
            return View(model);
        }
    }
}