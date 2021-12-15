using System.ComponentModel.DataAnnotations;

namespace Application.InputModels
{
    public class EditOfficeInputModel
    {
        // public Address Address { get; private set;}
        public long? Id { get; set; }
        public long? AddressId { get; set; }
        [Required(ErrorMessage = "Введите название")]
        [Display(Name = "название")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Введите телефон")]
        [Display(Name = "телефон")]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "Введите ИНН")]
        [Display(Name = "ИНН")]
        public string Inn { get; set;}
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
        
        public bool IsValid()
        {
            return !Globals.IsAnyNullOrEmpty(Name, Phone, City, Street, Home, Flat);
        }
    }
}