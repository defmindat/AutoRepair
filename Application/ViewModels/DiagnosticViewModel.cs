using System.Collections.Generic;
using Domain.Services.DTO;

namespace Application.ViewModels
{
    public class DiagnosticViewModel
    {
        public long RequestId { get; set; }
        public long OfficeId { get; set; }
        public ICollection<long> SelectedDiagnosticItemIds { get; set; }
        public List<DiagnosticItemDto> Items { get; set; }
    }
}