using DomainModel.Customers;

namespace DomainModel.Repositories
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Customer FindById(int id);
    }
}