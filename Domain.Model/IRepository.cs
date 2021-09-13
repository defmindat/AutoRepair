using System.Collections.Generic;

namespace DomainModel
{
    public interface IRepository<TAggregate>
    {
        IList<TAggregate> FindAll();
        bool Add(TAggregate aggregate);
        bool Update(TAggregate aggregate);
        TAggregate FindById(long id);
    }
}