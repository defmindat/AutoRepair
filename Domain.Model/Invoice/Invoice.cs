using DomainModel.Orders;

namespace DomainModel.Invoices
{
    public class Invoice
    {
        public long Id { get; set; }
        public Order Order { get; set; }        
    }
}