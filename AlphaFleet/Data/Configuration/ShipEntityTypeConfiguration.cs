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
            new Ship { Id = 1, Name = "Vanguard", Class = "Interceptor", ShipProductionYear = 2225, ShipHullClass = ShipHullClass.Interceptor, Rarity = ShipRarity.Common, ImageUrl = "/images/vanguard.jpg", History = "The Vanguard was the first interceptor-class vessel produced by the Sol Shipyards in 2225. Originally designed for rapid reconnaissance missions, it quickly became the backbone of Alpha Fleet's patrol operations. Its lightweight frame and advanced sensor array made it ideal for early-warning deployments along the outer rim.", FleetId = new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), IsAvailable = true },
            new Ship { Id = 2, Name = "Corsair", Class = "Fighter", ShipProductionYear = 2228, ShipHullClass = ShipHullClass.Fighter, Rarity = ShipRarity.Rare, ImageUrl = "/images/corsair.jpg", History = "Commissioned in 2228, the Corsair was built to fill the gap between interceptors and corvettes. Armed with dual plasma cannons and reinforced hull plating, it earned its reputation during the Orion Skirmishes where a squadron of Corsairs held off an entire enemy flotilla for 72 hours.", FleetId = new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), IsAvailable = true },
            new Ship { Id = 3, Name = "Harbinger", Class = "Corvette", ShipProductionYear = 2215, ShipHullClass = ShipHullClass.Corvette, Rarity = ShipRarity.Epic, ImageUrl = "/images/harbinger.jpg", History = "The Harbinger is one of the oldest active vessels in the fleet, launched in 2215 from the Centauri Reach drydocks. It served as a testbed for experimental stealth technology and was instrumental in covert operations during the Vega Conflict. Currently decommissioned for a major refit of its propulsion systems.", FleetId = new Guid("4241c74f-092c-4249-b731-954fb7658830"), IsAvailable = false },
            new Ship { Id = 4, Name = "Aegis", Class = "Frigate", ShipProductionYear = 2230, ShipHullClass = ShipHullClass.Frigate, Rarity = ShipRarity.Rare, ImageUrl = "/images/aegis.jpg", History = "The Aegis was designed as a defensive powerhouse, equipped with multi-layered shield generators and point-defense systems. Launched in 2230, it has served as the flagship escort for Beta Squadron, protecting capital ships during large-scale fleet engagements across the Orion Sector.", FleetId = new Guid("4241c74f-092c-4249-b731-954fb7658830"), IsAvailable = true },
            new Ship { Id = 5, Name = "Leviathan", Class = "Destroyer", ShipProductionYear = 2240, ShipHullClass = ShipHullClass.Destroyer, Rarity = ShipRarity.Legendary, ImageUrl = "/images/leviathan.jpg", History = "The Leviathan is a destroyer of unmatched firepower, completed in 2240 at the classified Sirius Gate facility. Its main battery can cripple a space station in a single salvo. Only one was ever built due to the immense cost. Currently undergoing repairs after sustaining heavy damage in the Battle of Andromeda Port.", FleetId = new Guid("86634405-36a8-4727-93bd-97273e947361"), IsAvailable = false }
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

            builder.Property(s => s.History)
                .HasMaxLength(Common.EntityValidation.ShipDescriptionMaxLength);

            // Use EF Core's HasData for model seeding
            builder.HasData(SeedShips);
        }
    }
}
