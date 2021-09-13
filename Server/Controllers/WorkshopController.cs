using Application.InputModels;
using AutoMapper;
using Domain.Services;
using DomainModel.Repositories;
using DomainModel.WorkShops;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepair.Controllers
{
    public class WorkshopController : Controller
    {
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IMapper _mapper;

        public WorkshopController(IWorkshopRepository workshopRepository, IMapper mapper)
        {
            _workshopRepository = workshopRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            if (id == default)
                return View();
            var workshop = _workshopRepository.FindById(id);
            var inputModel = _mapper.Map<EditWorkshopInputModel>(workshop);
            return View(inputModel);
        }
        
        [HttpPost]
        public IActionResult Edit(EditWorkshopInputModel model)
        {
            if (ModelState.IsValid)
            {
                var workshop = _mapper.Map<WorkShop>(model);
                if (model.Id == default)
                {
                    var succeeded = _workshopRepository.Add(workshop);
                    if (succeeded) return RedirectToAction("Index", "Home");
                }
 
                var editSucceeded = _workshopRepository.Update(workshop);
                if (editSucceeded) return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("failed",
                "Возникли ошибки при заполнении формы. Проверьте, пожалуйста, правильность и полноту заполнения.");
            return View(model);
        }
    }
}