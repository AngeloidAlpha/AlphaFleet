using AlphaFleet.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AlphaFleet.Services
{
    public interface IFleetService
    {
        Task<IEnumerable<Fleet>> GetAllFleetsAsync(string? search);
        Task<Fleet?> GetFleetByIdAsync(Guid id);
        Task<Fleet?> GetUserFleetAsync(string userId);
        Task<bool> UserHasFleetAsync(string userId);
        Task CreateFleetAsync(Fleet fleet);
    }
}