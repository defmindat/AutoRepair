using System.ComponentModel.DataAnnotations;

namespace Application.InputModels
{
    public class EditCustomerInputModel
    {
        public long? Id { get; set; }
        public long? AddressId { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите город")]
        [Display(Name = "город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Введите улицу")]
        [Display(Name = "улица")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Введите дом")]
        [Display(Name = "дом")]
        public string Home { get; set; }

        [Required(ErrorMessage = "Введите квартиру")]
        [Display(Name = "квартира")]
        public string Flat { get; set; }

        [Required(ErrorMessage = "Введите email")]
        [Display(Name = "email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите телефон")]
        [Display(Name = "телефон")]
        public string Phone { get; set; }

        public bool IsValid()
        {
            return !Globals.IsAnyNullOrEmpty(FirstName, LastName, Phone);
        }
    }
}