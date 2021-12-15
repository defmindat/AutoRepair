using System.Threading.Tasks;
using Application.InputModels;
using DomainModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepair.Controllers
{
    public class ManagerController : Controller
    {
        private readonly UserManager<User> _userManager;

        public ManagerController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        // GET
        
        
        [HttpPost]
        public async Task<IActionResult> Create(EditManagerInputModel model)
        {
            if (ModelState.IsValid)
            {
                var manager = new Manager {Email = model.Email, Firstname = model.Firstname, Lastname = model.Lastname, UserName = model.Email, Year = model.Year, OfficeId = model.OfficeId.Value};
                var result = await _userManager.CreateAsync(manager, model.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
        public async Task<IActionResult> Edit(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var model = new EditUserInputModel {Id = user.Id, Email = user.Email, Year = user.Year};
            return View(model);
        }
    }
}