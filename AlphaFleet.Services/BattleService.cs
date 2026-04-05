using AlphaFleet.Common;
using AlphaFleet.Data;
using AlphaFleet.Data.Models;
using AlphaFleet.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace AlphaFleet.Services
{
    public class BattleService : IBattleService
    {
        private readonly ApplicationDbContext _dbContext;

        public BattleService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Battle>> GetAllBattlesAsync(string? search)
        {
            IQueryable<Battle> query = _dbContext.Battles
                .Include(b => b.AttackingFleet)
                .Include(b => b.DefendingFleet)
                .Include(b => b.DefendingStation)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                string term = search.Trim().ToLower();
                query = query.Where(b =>
                    b.AttackingFleet.Name.ToLower().Contains(term) ||
                    (b.DefendingFleet != null && b.DefendingFleet.Name.ToLower().Contains(term)) ||
                    b.DefendingStation.Name.ToLower().Contains(term));
            }

            return await query.OrderByDescending(b => b.StartTime).ToListAsync();
        }

        public async Task<Battle?> GetBattleByIdAsync(Guid id)
        {
            return await _dbContext.Battles
                .Include(b => b.AttackingFleet)
                    .ThenInclude(f => f.Ships)
                .Include(b => b.DefendingFleet)
                    .ThenInclude(f => f!.Ships)
                .Include(b => b.DefendingStation)
                .Include(b => b.BattleTurns.OrderBy(t => t.TurnNumber))
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

        public async Task<Battle> SimulateBattleAsync(Guid attackingFleetId, Guid defendingFleetId, Guid defendingStationId)
        {
            Fleet? attackingFleet = await _dbContext.Fleets
                .Include(f => f.Ships)
                .SingleOrDefaultAsync(f => f.Id == attackingFleetId);

            Fleet? defendingFleet = await _dbContext.Fleets
                .Include(f => f.Ships)
                .SingleOrDefaultAsync(f => f.Id == defendingFleetId);

            Station? station = await _dbContext.Stations
                .SingleOrDefaultAsync(s => s.Id == defendingStationId);

            if (attackingFleet == null || defendingFleet == null || station == null)
                throw new InvalidOperationException("Invalid fleet or station selection.");

            // Attack power: sum of each ship's rarity value * 100
            // TODO: Replace with per-ship Attack stat for complex logic
            int attackPower = attackingFleet.Ships.Sum(s => (int)s.Rarity * 100);

            // Defender HP: combined fleet power + station health
            // TODO: Replace fleet portion with per-ship HP stat; add station shield layers
            int remainingHp = defendingFleet.Ships.Sum(s => (int)s.Rarity * 100) + station.Health;

            int totalDamage = 0;
            int turnsPlayed = 0;
            BattleOutcome outcome = BattleOutcome.Draw; // Default if 15 turns expire
            var turns = new List<BattleTurn>();

            for (int turn = 1; turn <= EntityValidation.BattleMaxTurns; turn++)
            {
                turnsPlayed = turn;
                int damage = Math.Max(0, Math.Min(attackPower, remainingHp));
                remainingHp -= attackPower;
                totalDamage += damage;

                turns.Add(new BattleTurn
                {
                    Id = Guid.NewGuid(),
                    TurnNumber = turn,
                    DamageDealt = damage,
                    DefenderRemainingHealth = Math.Max(remainingHp, 0),
                    Notes = $"{attackingFleet.Name} deals {damage:N0} damage. " +
                            $"Defender HP remaining: {Math.Max(remainingHp, 0):N0}"
                });

                if (remainingHp <= 0)
                {
                    outcome = BattleOutcome.Victory;
                    break;
                }
            }
            // If the loop completes without hitting the break, outcome stays Draw

            Battle battle = new Battle
            {
                Id = Guid.NewGuid(),
                AttackingFleetId = attackingFleetId,
                DefendingFleetId = defendingFleetId,
                DefendingStationId = defendingStationId,
                DamageDealt = totalDamage,
                TurnsPlayed = turnsPlayed,
                Outcome = outcome,
                EndTime = DateTime.UtcNow,
                BattleTurns = turns
            };

            _dbContext.Battles.Add(battle);
            await _dbContext.SaveChangesAsync();

            return battle;
        }
    }
}
