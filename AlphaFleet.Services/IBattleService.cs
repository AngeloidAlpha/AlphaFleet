using AlphaFleet.Data.Models;
using AlphaFleet.Data.Models.Enums;

namespace AlphaFleet.Services
{
    public interface IBattleService
    {
        Task<IEnumerable<Battle>> GetAllBattlesAsync(string? search);
        Task<Battle?> GetBattleByIdAsync(Guid id);
        Task CreateBattleAsync(Battle battle);
        Task UpdateBattleAsync(Battle battle);
        Task DeleteBattleAsync(Guid id);
        Task<BattleOutcome> SimulateBattleAsync(Guid attackerShipId, Guid defenderShipId); // for game logic
    }
}
