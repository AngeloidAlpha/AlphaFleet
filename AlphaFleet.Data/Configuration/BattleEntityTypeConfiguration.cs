using AlphaFleet.Common;
using AlphaFleet.Data.Models;
using AlphaFleet.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaFleet.Data.Configuration
{
    public class BattleEntityTypeConfiguration : IEntityTypeConfiguration<Battle>
    {
        private readonly Battle[] SeedBattles = new[]
        {
            new Battle
            {
                Id = new Guid("f1e2d3c4-b5a6-7890-1234-56789abcdef0"),
                AttackingFleetId = new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"),   // Alpha Fleet
                DefendingFleetId = new Guid("4241c74f-092c-4249-b731-954fb7658830"),   // Beta Squadron
                DefendingStationId = new Guid("a1b2c3d4-e5f6-7890-1234-56789abcdef0"), // Orion Outpost
                StartTime = new DateTime(2026, 4, 1, 12, 0, 0, DateTimeKind.Utc),
                EndTime = new DateTime(2026, 4, 1, 14, 0, 0, DateTimeKind.Utc),
                Outcome = BattleOutcome.Victory,
                DamageDealt = 2500,
                TurnsPlayed = 3,
                Description = "Alpha Fleet successfully captured Orion Outpost."
            }
        };

        public void Configure(EntityTypeBuilder<Battle> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.StartTime).IsRequired();
            builder.Property(b => b.Outcome).IsRequired();
            builder.Property(b => b.DamageDealt).HasDefaultValue(0);
            builder.Property(b => b.TurnsPlayed).HasDefaultValue(0);
            builder.Property(b => b.Description).HasMaxLength(EntityValidation.BattleDescriptionMaxLength);

            builder.HasOne(b => b.AttackingFleet)
                .WithMany()
                .HasForeignKey(b => b.AttackingFleetId)
                .OnDelete(DeleteBehavior.Restrict);

            // Nullable FK — IsRequired(false) keeps the column nullable in the DB
            builder.HasOne(b => b.DefendingFleet)
                .WithMany()
                .HasForeignKey(b => b.DefendingFleetId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne(b => b.DefendingStation)
                .WithMany()
                .HasForeignKey(b => b.DefendingStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(SeedBattles);
        }
    }
}
