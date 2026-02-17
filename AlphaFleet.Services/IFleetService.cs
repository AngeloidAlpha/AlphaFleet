using AlphaFleet.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaFleet.Services
{
    public interface IFleetService
    {
        Task<IEnumerable<Fleet>> GetAllFleetsAsync(string? search);
        Task<Fleet?> GetFleetByIdAsync(Guid id);
    }
}
