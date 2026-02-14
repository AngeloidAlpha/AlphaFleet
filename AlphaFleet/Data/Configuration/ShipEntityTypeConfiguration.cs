using AlphaFleet.Models;
using AlphaFleet.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaFleet.Data.Configuration
{
    public class ShipEntityTypeConfiguratuion : IEntityTypeConfiguration<Ship>
    {
        // Seed data defined once at type level so it's not recreated every time Configure is called.
        private static readonly Ship[] SeedShips = new[]
        {
            new Ship { Id = 1, Name = "Vanguard", Class = "Interceptor", ShipProductionYear = 2225, ShipHullClass = ShipHullClass.Interceptor, Rarity = ShipRarity.Common, IsAvailable = true },
            new Ship { Id = 2, Name = "Corsair", Class = "Fighter", ShipProductionYear = 2228, ShipHullClass = ShipHullClass.Fighter, Rarity = ShipRarity.Rare, IsAvailable = true },
            new Ship { Id = 3, Name = "Harbinger", Class = "Corvette", ShipProductionYear = 2215, ShipHullClass = ShipHullClass.Corvette, Rarity = ShipRarity.Epic, IsAvailable = false },
            new Ship { Id = 4, Name = "Aegis", Class = "Frigate", ShipProductionYear = 2230, ShipHullClass = ShipHullClass.Frigate, Rarity = ShipRarity.Rare, IsAvailable = true },
            new Ship { Id = 5, Name = "Leviathan", Class = "Destroyer", ShipProductionYear = 2240, ShipHullClass = ShipHullClass.Destroyer, Rarity = ShipRarity.Legendary, IsAvailable = false }
        };

        public void Configure(EntityTypeBuilder<Ship> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(Common.EntityValidation.ShipNameMaxLength);

            builder.Property(s => s.Class)
                .IsRequired();

            builder.Property(s => s.ShipProductionYear).IsRequired();

            builder.Property(s => s.ShipHullClass).IsRequired();

            builder.Property(s => s.IsAvailable).HasDefaultValue(true);

            // Use EF Core's HasData for model seeding
            builder.HasData(SeedShips);
        }
    }
}
