namespace DomainModel.Customers
{
    public class Address : IIdentifier<long>
    {
        public long Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Flat { get; set; }
    }
}