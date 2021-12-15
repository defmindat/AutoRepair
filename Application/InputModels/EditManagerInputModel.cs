namespace Application.InputModels
{
    public class EditManagerInputModel
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Year { get; set; }
        public long? OfficeId { get; set; }
    }
}