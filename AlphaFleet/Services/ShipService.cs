using AlphaFleet.Models;
using AlphaFleet.Models.Enums;

namespace AlphaFleet.Services
{
    public class ShipService
    {
        private readonly List<Ship> _ships = new List<Ship>
        {
            new Ship {Id = 1, Name = "Common Rarity", Rarity = ShipRarity.Common },
            new Ship {Id = 2, Name = "Rare Rarity", Rarity = ShipRarity.Rare },
            new Ship {Id = 3, Name = "Epic Rarity", Rarity = ShipRarity.Epic },
            new Ship {Id = 4, Name = "Legendary Rarity", Rarity = ShipRarity.Legendary },
        };
        public  List<Ship> GetShipByRarity(ShipRarity rarity)
        {
            return _ships.Where(s => s.Rarity == rarity)
                .ToList();
        }
        public List<Ship> GetAllShips()
        {
            return _ships;
        }
    }
}
