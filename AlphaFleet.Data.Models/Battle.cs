using static AlphaFleet.Common.EntityValidation;
using AlphaFleet.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaFleet.Data.Models
{
    public class Battle
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey(nameof(AttackingFleet))]
        public Guid AttackingFleetId { get; set; }
        public virtual Fleet AttackingFleet { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(DefendingStation))]
        public Guid DefendingStationId { get; set; }
        public virtual Station DefendingStation { get; set; } = null!;
        [Required]
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        public DateTime? EndTime { get; set; }
        [Required]
        public BattleOutcome Outcome { get; set; } = BattleOutcome.Ongoing;
        [Range(BattleDamageMinValue, BattleDamageMaxValue)]
        public int DamageDealt { get; set; } = 0;
        [MaxLength(BattleDescriptionMaxLength)]
        public string? Description { get; set; }
    }
}
