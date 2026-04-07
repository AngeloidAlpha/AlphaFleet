using AlphaFleet.Data.Models;
using AlphaFleet.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaFleet.Data.Configuration
{
    public class ShipEntityTypeConfiguratuion : IEntityTypeConfiguration<Ship>
    {
        // Stats are pre-calculated from ShipStatsHelper logic:
        // Base stats double per hull class (Fighter=10/1/50), then × rarity multiplier.
        // Common=×1.10 | Rare=×1.20 | Epic=×1.40 | Legendary=×1.80
        private readonly Ship[] SeedShips = new[]
        {
            // Fighter — base 10/1/50 — Common ×1.10 → 11/1/55
            new Ship
            {
                Id = new Guid("f7d4e8a2-5c19-4b7e-9f21-a8c3b6d1e9f4"),
                Name = "Sparrow",
                Class = "Fighter",
                ShipHullClass = ShipHullClass.Fighter,
                Rarity = ShipRarity.Common,
                Attack = 11, Defense = 1, Health = 55,
                ShipProductionYear = 2235,
                ImageUrl = "/images/ships/default.png",
                History = "The Sparrow is the most mass-produced fighter in the Sol Defence Force. Cheap, fast, and expendable, entire wings of Sparrows are launched ahead of larger vessels to screen against incoming missile volleys and probe enemy formations.",
                FleetId = new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"),
                IsAvailable = true
            },
            // Interceptor — base 20/2/100 — Rare ×1.20 → 24/2/120
            new Ship
            {
                Id = new Guid("3e9a4c7b-8f2d-4a56-b1c9-7d5e3a2f6b8c"),
                Name = "Vanguard",
                Class = "Interceptor",
                ShipHullClass = ShipHullClass.Interceptor,
                Rarity = ShipRarity.Rare,
                Attack = 24, Defense = 2, Health = 120,
                ShipProductionYear = 2225,
                ImageUrl = "/images/ships/default.png",
                History = "The Vanguard was the first interceptor-class vessel produced by the Sol Shipyards in 2225. Originally designed for rapid reconnaissance missions, it quickly became the backbone of Alpha Fleet's patrol operations. Its lightweight frame and advanced sensor array made it ideal for early-warning deployments along the outer rim.",
                FleetId = new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"),
                IsAvailable = true
            },
            // Corvette — base 40/4/200 — Epic ×1.40 → 56/6/280
            new Ship
            {
                Id = new Guid("2a6f1b8e-4d9c-4e3f-a5b2-c1d7e8f9a3b5"),
                Name = "Harbinger",
                Class = "Corvette",
                ShipHullClass = ShipHullClass.Corvette,
                Rarity = ShipRarity.Epic,
                Attack = 56, Defense = 6, Health = 280,
                ShipProductionYear = 2215,
                ImageUrl = "/images/ships/default.png",
                History = "The Harbinger is one of the oldest active vessels in the fleet, launched in 2215 from the Centauri Reach drydocks. It served as a testbed for experimental stealth technology and was instrumental in covert operations during the Vega Conflict.",
                FleetId = new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"),
                IsAvailable = false
            },
            // Frigate — base 80/8/400 — Common ×1.10 → 88/9/440
            new Ship
            {
                Id = new Guid("9c5b3d7e-6a1f-4c8a-b3d4-e9f2a5c6b8d1"),
                Name = "Aegis",
                Class = "Frigate",
                ShipHullClass = ShipHullClass.Frigate,
                Rarity = ShipRarity.Common,
                Attack = 88, Defense = 9, Health = 440,
                ShipProductionYear = 2230,
                ImageUrl = "/images/ships/default.png",
                History = "The Aegis was designed as a defensive powerhouse, equipped with multi-layered shield generators and point-defence systems. Launched in 2230, it has served as the flagship escort for Beta Squadron across the Orion Sector.",
                FleetId = new Guid("4241c74f-092c-4249-b731-954fb7658830"),
                IsAvailable = true
            },
            // Destroyer — base 160/16/800 — Legendary ×1.80 → 288/29/1440
            new Ship
            {
                Id = new Guid("7f4a9c2d-e3b1-4a7f-9d5c-2e8a4b6f1c9e"),
                Name = "Leviathan",
                Class = "Destroyer",
                ShipHullClass = ShipHullClass.Destroyer,
                Rarity = ShipRarity.Legendary,
                Attack = 288, Defense = 29, Health = 1440,
                ShipProductionYear = 2240,
                ImageUrl = "/images/ships/default.png",
                History = "The Leviathan is a destroyer of unmatched firepower, completed in 2240 at the classified Sirius Gate facility. Its main battery can cripple a space station in a single salvo. Only one was ever built due to the immense cost.",
                FleetId = new Guid("4241c74f-092c-4249-b731-954fb7658830"),
                IsAvailable = false
            },
            // Cruiser — base 320/32/1600 — Rare ×1.20 → 384/38/1920
            new Ship
            {
                Id = new Guid("a1d4f8c3-5e2b-4d9a-8f1c-6a3e7b2f5d8a"),
                Name = "Corsair",
                Class = "Cruiser",
                ShipHullClass = ShipHullClass.Cruiser,
                Rarity = ShipRarity.Rare,
                Attack = 384, Defense = 38, Health = 1920,
                ShipProductionYear = 2228,
                ImageUrl = "/images/ships/default.png",
                History = "Commissioned in 2228, the Corsair was built to fill the gap between destroyers and heavy cruisers. Armed with quad plasma cannons and reinforced hull plating, it earned its reputation during the Orion Skirmishes where it held off an enemy flotilla for 72 hours.",
                FleetId = new Guid("86634405-36a8-4727-93bd-97273e947361"),
                IsAvailable = true
            },
            // HeavyCruiser — base 640/64/3200 — Common ×1.10 → 704/70/3520
            new Ship
            {
                Id = new Guid("d2b6f9a7-4c8e-4b3f-a1d5-9e7c2a5f8b1d"),
                Name = "Ironclad",
                Class = "HeavyCruiser",
                ShipHullClass = ShipHullClass.HeavyCruiser,
                Rarity = ShipRarity.Common,
                Attack = 704, Defense = 70, Health = 3520,
                ShipProductionYear = 2238,
                ImageUrl = "/images/ships/default.png",
                History = "The Ironclad lives up to its name. Its hull is layered with seven centimetres of ablative armour plating, making it near impervious to light weapons fire. It has served as a forward assault vessel in every major fleet engagement since its commissioning.",
                FleetId = new Guid("86634405-36a8-4727-93bd-97273e947361"),
                IsAvailable = true
            },
            // Battlecruiser — base 1280/128/6400 — Epic ×1.40 → 1792/179/8960
            new Ship
            {
                Id = new Guid("e8c3a5b9-6d2f-4a1e-9c7d-3f8b5a2e6c9a"),
                Name = "Nemesis",
                Class = "Battlecruiser",
                ShipHullClass = ShipHullClass.Battlecruiser,
                Rarity = ShipRarity.Epic,
                Attack = 1792, Defense = 179, Health = 8960,
                ShipProductionYear = 2244,
                ImageUrl = "/images/ships/default.png",
                History = "The Nemesis was conceived as a warship that could hunt down and destroy anything short of a capital ship. Its long-range siege cannons can engage targets at distances that render enemy return fire nearly impossible.",
                FleetId = new Guid("86634405-36a8-4727-93bd-97273e947361"),
                IsAvailable = true
            },
            // CapitalShip — base 2560/256/12800 — Rare ×1.20 → 3072/307/15360
            new Ship
            {
                Id = new Guid("b4f7d1c8-9a3e-4d6b-a2f5-7e1c4b8d3a6f"),
                Name = "Sovereign",
                Class = "CapitalShip",
                ShipHullClass = ShipHullClass.CapitalShip,
                Rarity = ShipRarity.Rare,
                Attack = 3072, Defense = 307, Health = 15360,
                ShipProductionYear = 2250,
                ImageUrl = "/images/ships/default.png",
                History = "The Sovereign is the command vessel of the First Fleet, renowned across all sectors as a symbol of Sol's naval dominance. Its bridge houses a crew of four hundred officers, and its presence alone has ended conflicts before the first shot was fired.",
                FleetId = new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"),
                IsAvailable = true
            },
            // AircraftCarrier — base 5120/512/25600 — Legendary ×1.80 → 9216/922/46080
            new Ship
            {
                Id = new Guid("6c9e2d4a-7f1b-4c5a-b8e3-1d9a6f2c5b8e"),
                Name = "Colossus",
                Class = "AircraftCarrier",
                ShipHullClass = ShipHullClass.AircraftCarrier,
                Rarity = ShipRarity.Legendary,
                Attack = 9216, Defense = 922, Health = 46080,
                ShipProductionYear = 2255,
                ImageUrl = "/images/ships/default.png",
                History = "The Colossus is the largest vessel ever constructed by humanity. Its cavernous flight deck houses over three hundred fighters and interceptors. It was built in secret over fifteen years at a classified Kuiper Belt facility, and its maiden deployment ended the Andromeda War in a single engagement.",
                FleetId = new Guid("4241c74f-092c-4249-b731-954fb7658830"),
                IsAvailable = true
            },
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

            builder.HasData(SeedShips);
        }
    }
}
