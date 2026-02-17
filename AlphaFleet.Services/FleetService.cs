using AlphaFleet.Data;
using AlphaFleet.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AlphaFleet.Services
{
    public class FleetService : IFleetService
    {
        private readonly ApplicationDbContext _dbContext;

        public FleetService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Get all fleets with optional search filter (async)
        public async Task<IEnumerable<Fleet>> GetAllFleetsAsync(string? search)
        {
            IQueryable<Fleet> query = _dbContext
                .Fleets
                .Include(f => f.Ships)
                .AsSplitQuery()
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                string searchTerm = search.Trim().ToLower();
                query = query.Where(f =>
                    f.Name.ToLower().Contains(searchTerm) ||
                    f.Location.ToLower().Contains(searchTerm));
            }

            return await query.ToListAsync();
        }

        // 2. Get a single fleet by ID (async)
        public async Task<Fleet?> GetFleetByIdAsync(Guid id)
        {
            return await _dbContext
                .Fleets
                .Include(f => f.Ships)
                .AsSplitQuery()
                .AsNoTracking()
                .SingleOrDefaultAsync(f => f.Id == id);
        }
    }
}
