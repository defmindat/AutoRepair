using System.ComponentModel.DataAnnotations;
using DomainModel.Vehicles;

namespace Application.ViewModels
{
    public class VehicleViewModel
    {
        public long? Id { get; set; }
        public long OfficeId { get; set; }
        public long CustomerId { get; set; }
        
        [Required(ErrorMessage = "Введите марку")]
        [Display(Name = "марка")]
        public string Firm { get; set; }

        [Required(ErrorMessage = "Введите модель")]
        [Display(Name = "модель")]
        public string ModelName { get; set; }
        
        [Required(ErrorMessage = "Введите год")]
        [Display(Name = "год")]
        public short Year { get; set; }
        
        [Required(ErrorMessage = "Введите объем двигателя")]
        [Display(Name = "объем двигателя")]
        public float EngineVolume { get; set; }
        
        [Required(ErrorMessage = "Выберите сторону руля")]
        [Display(Name = "сторона руля")]
        public HandSide? HandSide { get; set; }
    }
}