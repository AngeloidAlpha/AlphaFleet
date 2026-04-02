using AlphaFleet.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaFleet.Services
{
    public interface IStationService
    {
        Task<IEnumerable<Station>> GetAllStationAsync(string? search);
        Task<Station?> GetStationByIdAsync(Guid id);
        Task CreateStationAsync(Station station);
        Task UpdateStationAsync(Station station);
        Task DeleteStationAsync(Guid id);

    }
}
