

using AlphaFleet.Data;
using AlphaFleet.Data.Models;
using AlphaFleet.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace AlphaFleet.Services
{
    public class BattleService : IBattleService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Random _random = new Random();
        public async Task<IEnumerable<Battle>> GetAllBattlesAsync(string? search)
        {
            IQueryable<Battle> query = _dbContext.Battles
                .Include(b => b.AttackingFleet)
                .Include(b => b.DefendingStation)
                .AsNoTracking();
            if (!String.IsNullOrWhiteSpace(search))
            {
                string term = search.Trim().ToLower();
                query = query.Where(b =>
                    b.AttackingFleet.Name.ToLower().Contains(term) ||
                    b.DefendingStation.Name.ToLower().Contains(term)
            }
            return await query.OrderByDescending(b => b.StartTime).ToListAsync();
        }
        public async Task<Battle?> GetBattleByIdAsync(Guid id)
        {
            return await _dbContext.Battles
                .Include(b => b.AttackingFleet)
                .Include(b => b.DefendingStation)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task CreateBattleAsync(Battle battle)
        {
            _dbContext.Battles.Add(battle);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateBattleAsync(Battle battle)
        {
            _dbContext.Battles.Update(battle);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBattleAsync(Guid id)
        {
            Battle? battle = await _dbContext.Battles.FindAsync(id);
            if (battle != null)
            {
                _dbContext.Battles.Remove(battle);
                await _dbContext.SaveChangesAsync();
            }
        }
        // Simulating a simple battle
        public async Task<BattleOutcome> SimulateBattleAsync(Guid attackerShipId, Guid defenderShipId)
        {
            Fleet? fleet = await _dbContext.Fleets
                .Include(f => f.Ships)
                .SingleOrDefaultAsync(f => f.Id == attackerShipId);
            Station? station = await _dbContext.Stations
                .SingleOrDefaultAsync(s => s.Id == defenderShipId);
            if (fleet == null || station == null) throw new InvalidOperationException("Invalid Fleet or Station.");

            int fleetPower = fleet.Ships.Sum(s => (int)s.Rarity*100);
            int stationDefense = station.Health;
            Battle battle = new Battle
            {
                AttackingFleetId = attackerShipId,
                DefendingStationId = defenderShipId,
                DamageDealt = Math.Min(fleetPower, stationDefense),
                Outcome = fleetPower > stationDefense ? BattleOutcome.Victory :
                          fleetPower < stationDefense ? BattleOutcome.Defeat :
                          BattleOutcome.Draw,
                EndTime = DateTime.UtcNow
            };
            if (battle.Outcome == BattleOutcome.Victory)
            {
                station.Health -= battle.DamageDealt;
                if (station.Health <= 0)
                {
                    station.IsDestroyed = true;
                    station.Health = 0;
                }
            }
            await CreateBattleAsync(battle);
            await _dbContext.SaveChangesAsync();
            return battle.Outcome;
        }

    }
}
