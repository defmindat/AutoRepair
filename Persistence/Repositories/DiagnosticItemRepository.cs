using DomainModel.Catalog;
using Microsoft.EntityFrameworkCore;
using Persistence.Facade;

namespace Persistence.Repositories
{
    public class DiagnosticItemRepository: Repository<DiagnosticItem, long>
    {
        public DiagnosticItemRepository(DomainModelFacade dbContext):base(dbContext)
        {
        }
        protected override DbSet<DiagnosticItem> GetDbSet() => _dbContext.DiagnosticItems;
    }
}