using System.Collections.Generic;

namespace Application.InputModels
{
    public class EditRequestDiagnosticInputModel
    {
        public long RequestId { get; set; }
        public long OfficeId { get; set; }
        public IEnumerable<long> DiagnosticItems { get; set; }
    }
}