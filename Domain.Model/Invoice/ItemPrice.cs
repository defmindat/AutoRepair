namespace DomainModel.Invoices
{
    public class ItemPrice
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        // цена либо за набор сразу
        // либо за каждую позицию работы
        public int WorkItemTemplate { get; set; }
        public int WorkItemSet { get; set; }
        public decimal TotalPrice
        {
            get { return Price * Count; }
        }
    }
}