namespace Application.InputModels
{
    public class RegisterInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Flat { get; set; }
        
        public bool IsValid()
        {
            return Globals.IsAnyNullOrEmpty(FirstName, LastName);
        }
    }
}