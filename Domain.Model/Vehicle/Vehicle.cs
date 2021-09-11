namespace DomainModel.Vehicles
{
    public class Vehicle: IAggregateRoot
    {
        public long Id { get; set; }
        public string Firm { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal EngineVolume { get; set; }
        public HandSide HandSide { get; set; }
    }
    
    public enum HandSide{
        LHD,
        RHD
    }
}