using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.InputModels;
using Application.Services;
using Application.ViewModels;
using AutoMapper;
using Domain.Services.DTO;
using DomainModel;
using DomainModel.Customers;
using DomainModel.Offices;
using DomainModel.Vehicles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepair.Controllers
{
    public class OfficeController : Controller
    {
        private readonly IRepository<Office,long> _officeRepository;
        private readonly IRepository<Address,long> _addressRepository;
        private readonly IRepository<Customer,long> _customerRepository;
        private readonly IRepository<Vehicle,long> _vehicleRepository;
        private readonly IRepository<Manager, string> _managerRepository;
        private readonly IOfficeControllerService _officeControllerService;

        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public OfficeController(IRepository<Office, long> officeRepository, IMapper mapper, IRepository<Address, long> addressRepository, UserManager<User> userManager, IOfficeControllerService officeControllerService, IRepository<Customer, long> customerRepository, IRepository<Vehicle, long> vehicleRepository, IRepository<Manager, string> managerRepository)
        {
            _officeRepository = officeRepository;
            _addressRepository = addressRepository;
            _userManager = userManager;
            _officeControllerService = officeControllerService;
            _customerRepository = customerRepository;
            _vehicleRepository = vehicleRepository;
            _managerRepository = managerRepository;
            _mapper = mapper;
        }

        [Route("office/{officeId}")]
        public IActionResult Edit(long officeId)
        {
            if (officeId == default)
                return View();
            var office = _officeRepository.FindById(officeId);
            //TODO здесь должна быть ViewModel а не InputModel
            var inputModel = _mapper.Map<EditOfficeInputModel>(office);
            
            var address = _addressRepository.FindById(office.AddressId);
            _mapper.Map(address, inputModel); 
            
            return View(inputModel);
        }

        [HttpPost]
        [Route("office/{officeId}")]
        public IActionResult Edit(EditOfficeInputModel model)
        {
            if (!model.IsValid())
            {
                ModelState.AddModelError("failed",
                    "Возникли ошибки при заполнении формы. Проверьте, пожалуйста, правильность и полноту заполнения.");
                return View(model);
            }

            var office = Office.Create(model.Name, model.City, model.Street, model.Home,
                model.Flat, model.Phone, model.Inn);
            _officeRepository.Add(office);
            return View(model);
        }
        
        [HttpGet("office/{officeId}/manager/edit/{managerId?}")]
        public async Task<IActionResult> EditManager(long officeId, string managerId)
        {
            var manager = _managerRepository.FindById(managerId);
            if (manager == null) return View(new EditManagerInputModel {OfficeId = officeId});
            var model = new EditManagerInputModel { Id = manager.Id, Firstname = manager.Firstname, Lastname = manager.Lastname, Password = manager.PasswordHash, OfficeId = manager.OfficeId, Email = manager.Email, Year = manager.Year};
            return View(model);
        }
        
        [HttpGet("offices")]
        public async Task<IEnumerable<OfficeSearchResult>> SearchOffices(string term)
        {
            return _officeControllerService.RetrieveOffices(term);
        }
        
        [HttpPost("office/{officeId}/manager/edit")]
        public async Task<IActionResult> EditManager(EditManagerInputModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO переписать с открытого интерфейса
                // на метод Create
                model.OfficeId = 1;
                var manager = new Manager {Email = model.Email, Firstname = model.Firstname, Lastname = model.Lastname, UserName = model.Email, Year = model.Year, OfficeId = model.OfficeId.Value};
                var result = await _userManager.CreateAsync(manager, model.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
        
        // можно передавать OfficeId в модель когда на странице офиса нажимаем Регистрация Клиента
        [HttpGet("office/{officeId}/customer/edit/{customerId?}")]
        public IActionResult EditCustomer(long officeId,long? customerId)
        {
            if (customerId.HasValue)
            {
                var customer = _customerRepository.FindById(customerId.Value);
                //TODO не распознается адрес
                var vm = _mapper.Map<CustomerViewModel>(customer);
                return View(vm);
            }
            var model = new CustomerViewModel
            {
                Id = customerId,
                OfficeId = officeId
            };
            return View(model);
        }
        
        [HttpPost("office/{officeId}/customer/edit")]
        public async Task<IActionResult> EditCustomer(EditCustomerInputModel model)
        {
            if (ModelState.IsValid) 
            {
                if (model.Id == default)
                {
                    var manager = await _userManager.GetUserAsync(HttpContext.User);
                    var succeeded = _officeControllerService.RegisterNewCustomer(model, manager.Id);
                    if (succeeded) return RedirectToAction("Index", "Home");
                }

                var editSucceeded = _officeControllerService.EditCustomer(model);
                if (editSucceeded) return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("failed",
                "Возникли ошибки при заполнении формы. Проверьте, пожалуйста, правильность и полноту заполнения.");
            
            // TODO пересмотреть подход к InputModel и ViewModel
            return View(model);
        }

        [HttpGet("office/{officeId}/request/{requestId?}")]
        public async Task<IActionResult> EditRequest(long officeId, long? requestId)
        {
            var manager = await _userManager.GetUserAsync(HttpContext.User);
            var viewModel = _officeControllerService.RetrieveRequestInitialization(officeId, requestId, manager.Id);
            //TODO заполнить View с помощью контрола https://codewithmukesh.com/blog/select2-jquery-plugin-in-aspnet-core/
            return View(viewModel);
        }
       
        [HttpGet("office/{officeId}/search/customers")]
        public async Task<IEnumerable<CustomerSearchResult>> SearchCustomers(long officeId, string term)
        {
            return _officeControllerService.RetrieveCustomers(officeId, term);
        }
        
        [HttpGet("customer/{customerId}/search/vehicles")]
        public async Task<IEnumerable<VehicleSearchResult>> SearchVehicles(long customerId,string term)
        {
            return _officeControllerService.RetrieveVehicles(customerId, term);
        }

        [HttpPost("office/{officeId}/request")]
        public async Task<IActionResult> EditRequest(EditRequestInputModel model)
        {
            if (ModelState.IsValid)
            {
                if (!model.RequestId.HasValue)
                {
                    var manager = await _userManager.GetUserAsync(HttpContext.User);
                    var result = _officeControllerService.CreateRequest(model, manager.Id);
                    if (result.Item2) return RedirectToAction("Index", "Home");
                }
                
                // var editSucceeded = _officeService.EditCustomer(model);
                // if (editSucceeded) return RedirectToAction("Index", "Home");
                return Ok();
            }
            
            ModelState.AddModelError("failed",
                "Возникли ошибки при заполнении формы. Проверьте, пожалуйста, правильность и полноту заполнения.");
            return View(model);
        }

        [HttpGet]
        public IActionResult Vehicles(long customerId)
        {
            var vehicles = _vehicleRepository.FindAll().Where(x => x.CustomerId == customerId);
            return View(vehicles);
        }

        [HttpGet("customer/{customerId}/vehicle/edit/{vehicleId?}")]
        public IActionResult EditVehicle(long officeId, long customerId, long? vehicleId)
        {
            if (vehicleId.HasValue)
            {
                var vehicle = _vehicleRepository.FindById(vehicleId.Value);
                //TODO не распознается адрес
                var vm = _mapper.Map<VehicleViewModel>(vehicle);
                return View(vm);
            }
            
            var model = new VehicleViewModel()
            {
                Id = vehicleId,
                CustomerId = customerId,
                OfficeId = officeId
            };
            return View(model);
        }

        [HttpPost("customer/{customerId}/vehicle/edit")]
        public async Task<IActionResult> EditVehicle(EditVehicleInputModel model)
        {
            if (ModelState.IsValid) 
            {
                if (model.Id == default)
                {
                    var succeeded = _officeControllerService.RegisterNewVehicle(model);
                    if (succeeded) return RedirectToAction("Index", "Home");
                }

                var editSucceeded = _officeControllerService.EditVehicle(model);
                if (editSucceeded) return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("failed",
                "Возникли ошибки при заполнении формы. Проверьте, пожалуйста, правильность и полноту заполнения.");
            
            // TODO пересмотреть подход к InputModel и ViewModel
            return View(model);
        }

        [HttpGet("request/{requestId}/diagnostic/edit")]
        public IActionResult EditDiagnostic(long requestId)
        {
            return View();
        }
    }
}