using Application.InputModels;
using AutoMapper;
using DomainModel.Customers;

namespace AutoRepair.Mapper
{
    public class MappingProfile: Profile
    { 
        public MappingProfile() {
            // Add as many of these lines as you need to map your objects
            CreateMap<Customer, RegisterInputModel>().IncludeMembers(x => x.Address);
            CreateMap<Address, RegisterInputModel>(MemberList.None);
            CreateMap<RegisterInputModel, Customer>();
            CreateMap<RegisterInputModel, Address>();
        }
        
    }
}