using AlphaFleet.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using static AlphaFleet.Common.EntityValidation;

namespace AlphaFleet.Data.Models.ViewModels
{
    public class ShipFormViewModel
    {
        [Required]
        [MinLength(ShipNameMinLength)]
        [MaxLength(ShipNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string Class { get; set; } = null!;

        [Required]
        public ShipHullClass ShipHullClass { get; set; }

        public ShipRarity Rarity { get; set; }

        [Required]
        [Range(ShipProductionYearMinValue, ShipProductionYearMaxValue, ErrorMessage = "Production year must be between {1} and {2}.")]
        public int ShipProductionYear { get; set; }

        public string? ImageUrl { get; set; }

        [MaxLength(ShipDescriptionMaxLength)]
        public string? History { get; set; }

        [Required]
        public Guid FleetId { get; set; }

        public bool IsAvailable { get; set; } = true;

        public IEnumerable<Fleet> Fleets { get; set; } = new List<Fleet>();
    }
}
