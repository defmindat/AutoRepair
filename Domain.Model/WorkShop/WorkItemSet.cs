using System.Collections.Generic;

namespace DomainModel.WorkShops
{
    public class WorkItemSet
    {
        // Это для объектов типа Диагностика Двигателя
        // Она состоит из нескольких работ 
        // 1. Визуальный Осмотр
        // 2. Проверка поршневой группы
        // 3. и т.д.
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<WorkItemTemplate> WorkItemTemplates { get; set; }
    }
}