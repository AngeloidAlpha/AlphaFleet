using AlphaFleet.Data;
using AlphaFleet.Data.Models;
using AlphaFleet.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace AlphaFleet.Services
{
    public class ShipService : IShipService
    {
        private readonly ApplicationDbContext _dbContext;

        public ShipService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all ships with optional search filter
        public async Task<IEnumerable<Ship>> GetAllShipsAsync(string? search)
        {
            IQueryable<Ship> query = _dbContext
                .Ships
                .Include(s => s.Fleet)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                string searchTerm = search.Trim().ToLower();
                query = query.Where(s =>
                    s.Name.ToLower().Contains(searchTerm) ||
                    s.Class.ToLower().Contains(searchTerm));
            }

            return await query
                .OrderBy(s => s.Name)
                .ThenBy(s => s.ShipHullClass)
                .ThenBy(s => s.Rarity)
                .ThenByDescending(s => s.IsAvailable)
                .ThenByDescending(s => s.ShipProductionYear)
                .ToListAsync();
        }

        // Get a single ship by ID
        public async Task<Ship?> GetShipByIdAsync(Guid id)
        {
            return await _dbContext
                .Ships
                .Include(s => s.Fleet)
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        // Create a new ship
        public async Task CreateShipAsync(Ship ship)
        {
            _dbContext.Ships.Add(ship);
            await _dbContext.SaveChangesAsync();
        }

        // Update an existing ship
        public async Task UpdateShipAsync(Ship ship)
        {
            _dbContext.Ships.Update(ship);
            await _dbContext.SaveChangesAsync();
        }

        // 5. Delete a ship by ID
        public async Task DeleteShipAsync(Guid id)
        {
            Ship? ship = await _dbContext.Ships.FindAsync(id);
            if (ship != null)
            {
                _dbContext.Ships.Remove(ship);
                await _dbContext.SaveChangesAsync();
            }
        }

        // 6. Get all fleets for dropdowns
        public async Task<IEnumerable<Fleet>> GetAllFleetsAsync()
        {
            return await _dbContext
                .Fleets
                .AsNoTracking()
                .OrderBy(f => f.Name)
                .ToListAsync();
        }

        // 7. Get ships by rarity - sync for GachaService
        public List<Ship> GetShipByRarity(ShipRarity rarity)
        {
            return _dbContext
                .Ships
                .Where(s => s.Rarity == rarity)
                .ToList();
        }
    }
}
