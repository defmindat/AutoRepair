using System;
using System.Linq;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using Persistence.Facade;

namespace Persistence.Repositories
{
    public abstract class Repository<T, IdType> : IRepository<T, IdType>
        where T : class, IIdentifier<IdType> 
        where IdType : IEquatable<IdType>
    {
    protected readonly DomainModelFacade _dbContext;
    private readonly DbSet<T> _dbSet;
    protected abstract DbSet<T> GetDbSet();

    protected Repository(DomainModelFacade domainModelFacade)
    {
        _dbContext = domainModelFacade;
        _dbSet = GetDbSet();
    }

    public IQueryable<T> FindAll()
    {
        return _dbSet.AsQueryable();
    }

    public bool Add(T aggregate)
    {
        _dbSet.Add(aggregate);
        return _dbContext.SaveChanges() > 0;
    }

    public bool Update(T aggregate)
    {
        _dbSet.Update(aggregate);
        return _dbContext.SaveChanges() > 0;
    }

    public T FindById(IdType id)
    {
        try
        {
            var aggregate = (from c in _dbSet where c.Id.Equals(id) select c).First();
            return aggregate;
        }
        catch (InvalidOperationException)
        {
            // return new MissingCustomer();
        }

        return null;
    }
    }
}