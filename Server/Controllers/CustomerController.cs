using Microsoft.AspNetCore.Mvc;

namespace AutoRepair.Controllers
{
    public class CustomerController : Controller
    {
        // private readonly ICustomerControllerService _service;
        // private readonly UserManager<User> _userManager;
        //
        // public CustomerController(ICustomerControllerService customerControllerService, UserManager<User> userManager)
        // {
        //     _service = customerControllerService;
        //     _userManager = userManager;
        // }

        // [HttpGet]
        // public IActionResult Edit(long id)
        // {
        //     return View(id != default ? _service.GetCustomer(id) : null);
        // }
        //
        // [HttpPost]
        // public async Task<IActionResult> Edit(EditCustomerInputModel model)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         if (model.Id == default)
        //         {
        //             var manager = await _userManager.GetUserAsync(HttpContext.User);
        //             var succeeded = _service.Register(model, manager.Id);
        //             if (succeeded) return RedirectToAction("Index", "Home");
        //         }
        //
        //         var editSucceeded = _service.Edit(model);
        //         if (editSucceeded) return RedirectToAction("Index", "Home");
        //     }
        //
        //     ModelState.AddModelError("failed",
        //         "Возникли ошибки при заполнении формы. Проверьте, пожалуйста, правильность и полноту заполнения.");
        //     return View(model);
        // }
    }
}