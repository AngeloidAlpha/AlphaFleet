using AlphaFleet.Data.Models.Enums;
using static AlphaFleet.Common.EntityValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AlphaFleet.Data.Models
{
    public class Admiral
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MinLength(AdmiralNameMinLength)]
        [MaxLength(AdmiralNameMaxLength)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MinLength(AdmiralNameMinLength)]
        [MaxLength(AdmiralNameMaxLength)]
        public string LastName { get; set; } = null!;
        [Required]
        public AdmiralRank Rank { get; set; }
        [MaxLength(AdmiralBioMaxLength)]
        public string Bio { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(Fleet))]
        public Guid FleetId { get; set; }
        [JsonIgnore]
        public virtual Fleet Fleet { get; set; } = null!;
    }
}
