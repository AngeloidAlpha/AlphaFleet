using AlphaFleet.Models;
using AlphaFleet.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaFleet.Data.Configuration
{
    public class ShipEntityTypeConfiguratuion : IEntityTypeConfiguration<Ship>
    {
        // Seed data defined once at type level so it's not recreated every time Configure is called.
        private readonly Ship[] SeedShips = new[]
        {
            new Ship { Id = 1, Name = "Vanguard", Class = "Interceptor", ShipProductionYear = 2225, ShipHullClass = ShipHullClass.Interceptor, Rarity = ShipRarity.Common, ImageUrl = "/images/vanguard.jpg", FleetId = new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), IsAvailable = true },
            new Ship { Id = 2, Name = "Corsair", Class = "Fighter", ShipProductionYear = 2228, ShipHullClass = ShipHullClass.Fighter, Rarity = ShipRarity.Rare, ImageUrl = "/images/corsair.jpg", FleetId = new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), IsAvailable = true },
            new Ship { Id = 3, Name = "Harbinger", Class = "Corvette", ShipProductionYear = 2215, ShipHullClass = ShipHullClass.Corvette, Rarity = ShipRarity.Epic, ImageUrl = "/images/harbinger.jpg", FleetId = new Guid("4241c74f-092c-4249-b731-954fb7658830"), IsAvailable = false },
            new Ship { Id = 4, Name = "Aegis", Class = "Frigate", ShipProductionYear = 2230, ShipHullClass = ShipHullClass.Frigate, Rarity = ShipRarity.Rare, ImageUrl = "/images/aegis.jpg", FleetId = new Guid("4241c74f-092c-4249-b731-954fb7658830"), IsAvailable = true },
            new Ship { Id = 5, Name = "Leviathan", Class = "Destroyer", ShipProductionYear = 2240, ShipHullClass = ShipHullClass.Destroyer, Rarity = ShipRarity.Legendary, ImageUrl = "/images/leviathan.jpg", FleetId = new Guid("86634405-36a8-4727-93bd-97273e947361"), IsAvailable = false }
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
