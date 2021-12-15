using System.Linq;

namespace DomainModel
{
    public interface IRepository<TAggregate, IdType>
    {
        IQueryable<TAggregate> FindAll();
        bool Add(TAggregate aggregate);
        bool Update(TAggregate aggregate);
        TAggregate FindById(IdType id);
    }
}