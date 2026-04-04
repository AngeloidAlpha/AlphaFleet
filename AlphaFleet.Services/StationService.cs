using AlphaFleet.Data;
using AlphaFleet.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaFleet.Services
{
    public class StationService : IStationService
    {
        private readonly ApplicationDbContext _dbContext;
        public StationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Station>> GetAllStationAsync(string? search)
        {
            IQueryable<Station> query = _dbContext.Stations.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(search))
            {
                string term = search.Trim().ToLower();
                query = query.Where(s => s.Name.ToLower().Contains(term) || s.Location.ToLower().Contains(term));
            }
            return await query.OrderBy(s => s.Name).ToListAsync();
        }
        public async Task<Station?> GetStationByIdAsync(Guid id)
        {
            return await _dbContext.Stations.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task CreateStationAsync(Station station)
        {
            _dbContext.Stations.Add(station);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateStationAsync(Station station)
        {
            _dbContext.Stations.Update(station);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteStationAsync(Guid id)
        {
            Station? station = await _dbContext.Stations.FindAsync(id);
            if (station != null)
            {
                _dbContext.Stations.Remove(station);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
