using System.Collections.Generic;
using System.Linq;

namespace DomainModel.Catalog
{
    public class Diagnostic: IIdentifier<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
        public List<DiagnosticItem> DiagnosticItems { get; set; }
        
        public int TotalHours => DiagnosticItems?.Sum(x => x.Hours) ?? 0;
    }
}