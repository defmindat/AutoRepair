using System;
using System.Collections.Generic;
using DomainModel.Vehicles;
using DomainModel.WorkShops;

namespace DomainModel.Customers
{
    public class Request
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Vehicle Vehicle { get; set; }
        public SourceInfo Source { get; set; }
        public Customer Customer { get; set; }
    }
}