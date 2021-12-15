using DomainModel.Offices;

namespace DomainModel.Catalog
{
    public class DiagnosticItem: IIdentifier<long>
    {
        public long Id { get; set; }        
        public long? DiagnosticId { get; set; }
        public Diagnostic Diagnostic { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public long OfficeId { get; set; }
        public Office Office { get; set; }
    }
}