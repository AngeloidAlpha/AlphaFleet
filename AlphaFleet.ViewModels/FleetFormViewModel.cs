using System.ComponentModel.DataAnnotations;
using static AlphaFleet.Common.EntityValidation;

namespace AlphaFleet.ViewModels
{
    public class FleetFormViewModel
    {
        [Required]
        [MinLength(FleetNameMinLength)]
        [MaxLength(FleetNameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [MinLength(FleetLocationNameMinLength)]
        [MaxLength(FleetLocationNameMaxLength)]
        public string Location { get; set; } = null!;
    }
}
