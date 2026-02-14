using AlphaFleet.Models.Enums;
using static AlphaFleet.Common.EntityValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaFleet.Models
{
    public class Ship
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(ShipNameMinLength)]
        [MaxLength(ShipNameMaxLength)]
        public string Name { get; set; } =null!;
        [Required]
        public string Class { get; set; } = null!;
        [Required]
        public ShipRarity Rarity { get; set; }
        [Required]
        [Range(ShipProductionYearMinValue, ShipProductionYearMaxValue, ErrorMessage = "Production year must be {1} before {2}.")]
        public int ShipProductionYear { get; set; }
        [Required]
        public ShipHullClass ShipHullClass { get; set; }
        public string ImageUrl { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Fleet))]
        public Guid FleetId { get; set; }
        public bool IsAvailable { get; set; }
        public virtual Fleet Fleet { get; set; } = null!;
    }
}
