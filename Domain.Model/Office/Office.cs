﻿using System.Collections.Generic;
using DomainModel.Customers;
using DomainModel.Employees;

namespace DomainModel.Offices
{
    public class Office : IAggregateRoot
    {
        public long Id { get; set; }
        public Address Address { get;set; }

        public string Phone { get; set; }
        public string Inn { get; set;}
        public virtual ICollection<Employee> Managers { get; set; }
    }
}