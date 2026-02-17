using System.ComponentModel.DataAnnotations;

namespace AlphaFleet.Data.Models
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
        public virtual ICollection<Ship> Ships { get; set; } = new HashSet<Ship>();
        public virtual Admiral? Admiral { get; set; }
    }
}
