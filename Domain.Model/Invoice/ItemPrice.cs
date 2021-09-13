namespace DomainModel.Invoices
{
    public class ItemPrice
    {
        public long Id { get; set; }
        public decimal Price { get; set; }

        public int Count { get; set; }

        // цена либо за набор сразу
        // либо за каждую позицию работы
        public int WorkItemTemplate { get; set; }
        public int WorkItemSet { get; set; }

        public decimal TotalPrice => Price * Count;
    }
}