using System.Collections.Generic;
using DomainModel.Customers;
using DomainModel.Requests;

namespace DomainModel.Vehicles
{
    public class Vehicle : IAggregateRoot, IIdentifier<long>
    {
        public long Id { get; set; }
        public string Firm { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public float EngineVolume { get; set; }
        public HandSide HandSide { get; set; }
        public Customer Customer { get; set; }
        public long CustomerId { get; set; }
        public override string ToString() => Firm + " " + Model;
        public List<Request> Requests { get; set; }
    }

    public enum HandSide
    {
        LHD,
        RHD
    }
}