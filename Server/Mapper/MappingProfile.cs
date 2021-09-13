using Application.InputModels;
using AutoMapper;
using DomainModel.Customers;
using DomainModel.Offices;
using DomainModel.WorkShops;

namespace AutoRepair.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // EditCustomerInputModel
            CreateMap<Customer, EditCustomerInputModel>().IncludeMembers(x => x.Address);
            CreateMap<Address, EditCustomerInputModel>(MemberList.None);
            
            CreateMap<EditCustomerInputModel, Customer>();
            CreateMap<EditCustomerInputModel, Address>();
            
            // EditWorkshopInputModel
            CreateMap<WorkShop, EditWorkshopInputModel>();
            CreateMap<Address, EditWorkshopInputModel>(MemberList.None);
            CreateMap<Office, EditWorkshopInputModel>(MemberList.None);

            CreateMap<EditWorkshopInputModel, WorkShop>();
            CreateMap<EditWorkshopInputModel, Office>();
            CreateMap<EditWorkshopInputModel, Address>();
        }
    }
}