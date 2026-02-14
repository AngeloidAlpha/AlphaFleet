using AlphaFleet.Models;
using AlphaFleet.Models.Enums;

namespace AlphaFleet.Services
{
    public class GachaService
    {
        private readonly ShipService _shipService;
        private readonly Random _random = new Random();
        private readonly Dictionary<ShipRarity, double> _rarityProbabilities = new Dictionary<ShipRarity, double>
        {
            { ShipRarity.Common, 70.0 },
            { ShipRarity.Rare, 20.0 },
            { ShipRarity.Epic, 9.0 },
            { ShipRarity.Legendary, 1.00 }
        };
        public GachaService(ShipService shipService)
        {
            _shipService = shipService;
        }
        public Ship PullShip()
        {
            double roll = _random.NextDouble() * 100;
            double cumulativeProbability = 0;
            foreach (var rarity in _rarityProbabilities)
            {
                cumulativeProbability += rarity.Value;
                if (roll < cumulativeProbability)
                {
                    var shipsOfRarity = _shipService.GetShipByRarity(rarity.Key);
                    if (shipsOfRarity.Count == 0)
                    {
                        throw new InvalidOperationException($"No ships available for rarity {rarity.Key}");
                    }
                    int shipIndex = _random.Next(shipsOfRarity.Count);
                    return shipsOfRarity[shipIndex];
                }
            }
            // This should never happen if probabilities are correctly defined
            return _shipService.GetShipByRarity(ShipRarity.Common).FirstOrDefault();
        }
    }
    

}
