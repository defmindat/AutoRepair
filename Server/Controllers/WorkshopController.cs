using Application.InputModels;
using AutoMapper;
using DomainModel;
using DomainModel.Customers;
using DomainModel.WorkShops;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepair.Controllers
{
    public class WorkshopController : Controller
    {
        private readonly IRepository<Workshop, long> _workshopRepository;
        private readonly IRepository<Address, long> _addressRepository;
        private readonly IMapper _mapper;

        public WorkshopController(IRepository<Workshop, long> workshopRepository, IMapper mapper, IRepository<Address, long> addressRepository)
        {
            _workshopRepository = workshopRepository;
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            if (id == default)
                return View();
            var workshop = _workshopRepository.FindById(id);
            var inputModel = _mapper.Map<EditWorkshopInputModel>(workshop);
            
            var address = _addressRepository.FindById(workshop.AddressId);
            _mapper.Map(address, inputModel); 
            
            return View(inputModel);
        }
        
        [HttpPost]
        public IActionResult Edit(EditWorkshopInputModel model)
        {
            if (!model.IsValid())
            {
                ModelState.AddModelError("failed",
                    "Возникли ошибки при заполнении формы. Проверьте, пожалуйста, правильность и полноту заполнения.");
                return View(model);
            }

            var workshop = Workshop.Create(model.Name, model.City, model.Street, model.Home,
                model.Flat, null, null);
            _workshopRepository.Add(workshop);
            return View(model);
        }
    }
}