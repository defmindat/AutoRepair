using System.Collections.Generic;

namespace DomainModel.WorkShops
{
    public class WorkShop
    {
        public ICollection<WorkItemSet> WorkItemSets { get; set; }
        public ICollection<WorkItemTemplate> WorkItemTemplates { get; set; }
    }
}