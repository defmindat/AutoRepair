using DomainModel.Vehicles;

namespace DomainModel.Repositories
{
    public interface IVehicleRepository: IRepository<Vehicle>
    {
        Vehicle FindById(int id);
    }
}