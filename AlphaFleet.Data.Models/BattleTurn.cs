using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AlphaFleet.Common.EntityValidation;

namespace AlphaFleet.Data.Models
{
    public class BattleTurn
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(Battle))]
        public Guid BattleId { get; set; }
        public virtual Battle Battle { get; set; } = null!;

        [Required]
        public int TurnNumber { get; set; }

        // Attacker → Defender (net of defender's defense)
        [Required]
        public int DamageDealt { get; set; }

        // Defender + Station → Attacker (net of attacker's defense)
        [Required]
        public int CounterDamageDealt { get; set; }

        [Required]
        public int AttackerRemainingHealth { get; set; }

        [Required]
        public int DefenderRemainingHealth { get; set; }

        [MaxLength(BattleTurnNotesMaxLength)]
        public string? Notes { get; set; }
    }
}
