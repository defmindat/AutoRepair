using System.ComponentModel.DataAnnotations;

namespace Application.InputModels
{
    public class RegisterInputModel
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Flat { get; set; }
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        
        public bool IsValid()
        {
            return Globals.IsAnyNullOrEmpty(FirstName, LastName, Phone);
        }
    }
}