using AlphaFleet.Models;
using AlphaFleet.Models.Enums;

namespace AlphaFleet.Services
{
    public class ShipService
    {
        private readonly List<Ship> _ships = new List<Ship>
        {
            new Ship {Id = Guid.NewGuid(), Name = "Common Rarity", Rarity = ShipRarity.Common },
            new Ship {Id = Guid.NewGuid(), Name = "Rare Rarity", Rarity = ShipRarity.Rare },
            new Ship {Id = Guid.NewGuid(), Name = "Epic Rarity", Rarity = ShipRarity.Epic },
            new Ship {Id = Guid.NewGuid(), Name = "Legendary Rarity", Rarity = ShipRarity.Legendary },
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
