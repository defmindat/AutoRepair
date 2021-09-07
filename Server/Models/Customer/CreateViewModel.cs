namespace AutoRepair.Models.Customer
{
    public class CreateViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get;set; }
        public AddressDto Address { get; set; }
    }
    
    public class AddressDto
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Flat { get; set; }
    }
}