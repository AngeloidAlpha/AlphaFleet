using AlphaFleet.Data.Models;
using AlphaFleet.Data.Models.Enums;

namespace AlphaFleet.Services
{
    public static class ShipStatsHelper
    {
        // Base stats per hull class — each entry is exactly 2× the previous.
        private static readonly Dictionary<ShipHullClass, (int Attack, int Defense, int Health)> BaseStats = new()
        {
            { ShipHullClass.Fighter,         (10,    1,     50)    },
            { ShipHullClass.Interceptor,     (20,    2,     100)   },
            { ShipHullClass.Corvette,        (40,    4,     200)   },
            { ShipHullClass.Frigate,         (80,    8,     400)   },
            { ShipHullClass.Destroyer,       (160,   16,    800)   },
            { ShipHullClass.Cruiser,         (320,   32,    1_600) },
            { ShipHullClass.HeavyCruiser,    (640,   64,    3_200) },
            { ShipHullClass.Battlecruiser,   (1_280, 128,   6_400) },
            { ShipHullClass.CapitalShip,     (2_560, 256,   12_800)},
            { ShipHullClass.AircraftCarrier, (5_120, 512,   25_600)},
        };

        // Rarity percentage multipliers: +10 %, +20 %, +40 %, +80 %.
        private static readonly Dictionary<ShipRarity, double> RarityMultipliers = new()
        {
            { ShipRarity.Common,    1.10 },
            { ShipRarity.Rare,      1.20 },
            { ShipRarity.Epic,      1.40 },
            { ShipRarity.Legendary, 1.80 },
        };

        public static void ApplyStats(Ship ship)
        {
            if (!BaseStats.TryGetValue(ship.ShipHullClass, out var baseStats) ||
                !RarityMultipliers.TryGetValue(ship.Rarity, out double multiplier))
            {
                return;
            }

            ship.Attack  = (int)Math.Round(baseStats.Attack  * multiplier);
            ship.Defense = (int)Math.Round(baseStats.Defense * multiplier);
            ship.Health  = (int)Math.Round(baseStats.Health  * multiplier);
        }
    }
}