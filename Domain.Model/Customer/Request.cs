using System;
using DomainModel.Vehicles;

namespace DomainModel.Customers
{
    public class Request
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Vehicle Vehicle { get; set; }
        public SourceInfo Source { get; set; }
        public Customer Customer { get; set; }
    }
}