using AlphaFleet.Data.Models;

namespace AlphaFleet.Services
{
    public interface IBattleService
    {
        Task<IEnumerable<Battle>> GetAllBattlesAsync(string? search);
        Task<Battle?> GetBattleByIdAsync(Guid id);
        Task CreateBattleAsync(Battle battle);
        Task UpdateBattleAsync(Battle battle);
        Task DeleteBattleAsync(Guid id);

        /// Simulates a turn-based battle (max 15 turns). Returns the saved Battle with its full turn log.
        /// TODO: Add support for multiple attacking and defending fleets (many-to-many).
        /// TODO: Implement per-ship stats (attack rolls, accuracy, crits, ship destruction mid-battle).
        Task<Battle> SimulateBattleAsync(Guid attackingFleetId, Guid defendingFleetId, Guid defendingStationId);
    }
}
