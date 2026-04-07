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

            // Attacker stats
            int attackPower  = attackingFleet.Ships.Sum(s => s.Attack);
            int attackerDef  = attackingFleet.Ships.Sum(s => s.Defense);
            int attackerHp   = attackingFleet.Ships.Sum(s => s.Health);

            // Defender stats: fleet ships + station combined
            int defenderDef      = defendingFleet.Ships.Sum(s => s.Defense) + station.Defense;
            int counterAttack    = defendingFleet.Ships.Sum(s => s.Attack)  + station.Attack;
            int defenderHp       = defendingFleet.Ships.Sum(s => s.Health)  + station.Health;

            // Net damage per turn (clamped to 0 — defense cannot heal) ────────
            // TODO: Replace with per-ship accuracy rolls and critical hits later
            int effectiveDamage = Math.Max(0, attackPower  - defenderDef);
            int counterDamage   = Math.Max(0, counterAttack - attackerDef);

            int totalDamage = 0;
            int turnsPlayed = 0;
            BattleOutcome outcome = BattleOutcome.Draw; // Default if 15 turns expire
            var turns = new List<BattleTurn>();

            for (int turn = 1; turn <= EntityValidation.BattleMaxTurns; turn++)
            {
                turnsPlayed = turn;

                // Both sides fire simultaneously each turn
                defenderHp -= effectiveDamage;
                attackerHp -= counterDamage;
                totalDamage += effectiveDamage;

                bool defenderDefeated = defenderHp <= 0;
                bool attackerDefeated = attackerHp <= 0;

                turns.Add(new BattleTurn
                {
                    Id = Guid.NewGuid(),
                    TurnNumber = turn,
                    DamageDealt = effectiveDamage,
                    CounterDamageDealt = counterDamage,
                    AttackerRemainingHealth = Math.Max(attackerHp, 0),
                    DefenderRemainingHealth = Math.Max(defenderHp, 0),
                    Notes =
                        $"⚔️ [{attackingFleet.Name}] ATK {attackPower} − DEF {defenderDef} = {effectiveDamage:N0} dmg dealt. " +
                        $"🛡️ [{defendingFleet.Name} + {station.Name}] CTR {counterAttack} − DEF {attackerDef} = {counterDamage:N0} dmg dealt. " +
                        $"| Attacker HP: {Math.Max(attackerHp, 0):N0} | Defender HP: {Math.Max(defenderHp, 0):N0}"
                });

                // Simultaneous destruction → Draw
                if (defenderDefeated && attackerDefeated) { outcome = BattleOutcome.Draw;    break; }
                if (defenderDefeated)                     { outcome = BattleOutcome.Victory;  break; }
                if (attackerDefeated)                     { outcome = BattleOutcome.Defeat;   break; }
            }

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
