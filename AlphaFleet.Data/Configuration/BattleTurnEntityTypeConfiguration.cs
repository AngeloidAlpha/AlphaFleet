using AlphaFleet.Common;
using AlphaFleet.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaFleet.Data.Configuration
{
    public class BattleTurnEntityTypeConfiguration : IEntityTypeConfiguration<BattleTurn>
    {
        public void Configure(EntityTypeBuilder<BattleTurn> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TurnNumber).IsRequired();
            builder.Property(t => t.DamageDealt).IsRequired();
            builder.Property(t => t.DefenderRemainingHealth).IsRequired();
            builder.Property(t => t.Notes).HasMaxLength(EntityValidation.BattleTurnNotesMaxLength);

            builder.HasOne(t => t.Battle)
                .WithMany(b => b.BattleTurns)
                .HasForeignKey(t => t.BattleId)
                .OnDelete(DeleteBehavior.Cascade); // Turns are deleted with the battle
        }
    }
}
