using System.ComponentModel.DataAnnotations;
using DomainModel.Customers;

namespace Application.InputModels
{
    public class EditWorkshopInputModel
    {
        public long? Id { get; set; }
        [Required(ErrorMessage = "Введите название")]
        [Display(Name = "название")]
        public string Name { get; set; }

        public long? AddressId { get; set; }
        // public Address Address { get; set; }
        
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
        
        [Display(Name = "Адрес офиса совпадает с мастерской")]
        public bool OfficeAddressSameWorkshop { get; set; }
        public long? OfficeId { get; set; }
        
        [Display(Name = "город")]
        public string OfficeCity { get; set; }

        [Display(Name = "улица")]
        public string OfficeStreet { get; set; }
        
        [Display(Name = "дом")]
        public string OfficeHome { get; set; }

        [Display(Name = "квартира")]
        public string OfficeFlat { get; set; }
        
        // public Office Office { get; set; }
        // public ICollection<Employee> Repairmans { get; set; }
        // public Employee SeniorEmployee { get; set; }
        // public List<WorkItemSet> WorkSets { get; set; }
        // public List<WorkItemTemplate> WorkItems { get; set; }
        
        public bool IsValid()
        {
            return !Globals.IsAnyNullOrEmpty(Name, City, Street, Home);
        }
    }
}