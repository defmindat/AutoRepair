using Application.InputModels;
using Application.ViewModels;
using AutoMapper;
using DomainModel.Customers;
using DomainModel.Offices;
using DomainModel.Vehicles;
using DomainModel.WorkShops;

namespace AutoRepair.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // EditCustomerInputModel
            CreateMap<Customer, EditCustomerInputModel>().IncludeMembers(x => x.Office, x => x.Address);
            CreateMap<Address, EditCustomerInputModel>(MemberList.None);
            CreateMap<Office, EditCustomerInputModel>(MemberList.None);
            
            CreateMap<Vehicle, EditVehicleInputModel>().IncludeMembers(x => x.Customer);
            CreateMap<Customer, EditVehicleInputModel>(MemberList.None);

            CreateMap<Customer, CustomerViewModel>().IncludeMembers(x => x.Office, x => x.Address);
            CreateMap<Address, CustomerViewModel>(MemberList.None);
            CreateMap<Office, CustomerViewModel>(MemberList.None);
            
            CreateMap<Customer, VehicleViewModel>();
            CreateMap<Vehicle, VehicleViewModel>().IncludeMembers(x => x.Customer);

            CreateMap<EditCustomerInputModel, Customer>();
            CreateMap<EditCustomerInputModel, Address>();
            
            CreateMap<EditVehicleInputModel, Customer>();

            // EditOfficeInputModel
            CreateMap<Office, EditOfficeInputModel>().IncludeMembers(x => x.Address);
            CreateMap<Address, EditOfficeInputModel>(MemberList.None);
            
            CreateMap<EditOfficeInputModel, Office>();
            CreateMap<EditOfficeInputModel, Address>();

            CreateMap<CustomerViewModel, Customer>();
            CreateMap<CustomerViewModel, Address>();
            
            CreateMap<VehicleViewModel, Customer>();
            
            // EditWorkshopInputModel
            CreateMap<Workshop, EditWorkshopInputModel>().IncludeMembers(x => x.Address);
            CreateMap<Workshop, EditWorkshopInputModel>().IncludeMembers(x => x.Office);
            
            CreateMap<Address, EditWorkshopInputModel>(MemberList.None);
            CreateMap<Office, EditWorkshopInputModel>(MemberList.None);

            CreateMap<EditWorkshopInputModel, Workshop>();
            CreateMap<EditWorkshopInputModel, Address>();
            // CreateMap<EditWorkshopInputModel, Office>();
            
        }
    }
}