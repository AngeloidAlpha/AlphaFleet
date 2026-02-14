using System.ComponentModel.DataAnnotations;

namespace AlphaFleet.Models
{
    using static Common.EntityValidation;
    public class Fleet
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MinLength(FleetNameMinLength)]
        [MaxLength(FleetNameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [MinLength(FleetLocationNameMinLength)]
        [MaxLength(FleetLocationNameMaxLength)]
        public string Location { get; set; } = null!;
        public virtual ICollection<Fleet> Fleets { get; set; } 
            = new HashSet<Fleet>();
    }
}
