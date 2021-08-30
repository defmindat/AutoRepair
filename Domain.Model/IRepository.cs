using System.Collections;
using System.Collections.Generic;

namespace DomainModel
{
    public interface IRepository<TAggregate>
    {
        IList<TAggregate> FindAll();
    }
}