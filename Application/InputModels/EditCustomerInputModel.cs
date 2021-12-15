namespace Application.InputModels
{
    public class EditCustomerInputModel
    {
        public long? Id { get; set; }
        public long? AddressId { get; set; }
        public long OfficeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Flat { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool IsValid()
        {
            return !Globals.IsAnyNullOrEmpty(FirstName, LastName, Phone);
        }
    }
}