using System;
using System.Collections.Generic;
using System.Text;
using AlphaFleet.Data.Models;
using AlphaFleet.Data.Models.Enums;

namespace AlphaFleet.Services
{
    public interface IShipService
    {
        Task<IEnumerable<Ship>> GetAllShipsAsync(string? search);
        Task<Ship?> GetShipByIdAsync(Guid id);
        Task CreateShipAsync(Ship ship);
        Task UpdateShipAsync(Ship ship);
        Task DeleteShipAsync(Guid id);
        Task<IEnumerable<Fleet>> GetAllFleetsAsync();
        List<Ship> GetShipByRarity(ShipRarity rarity);  // sync - used by Gacha
    }
}
