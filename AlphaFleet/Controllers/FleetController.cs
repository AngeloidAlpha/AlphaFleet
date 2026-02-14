using AlphaFleet.Data;
using AlphaFleet.Data.Configuration;
using AlphaFleet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlphaFleet.Controllers
{
    public class FleetController : Controller
    {
        private readonly ApplicationDbContext _context;
        /* Constructor Injection - Most commonly used */
        /* Pattern to remember: Register in Collection then Consume */
        public FleetController(ApplicationDbContext dbContext)
        {
            /* Store the injected instance in a local field */
            _context = dbContext;
        }
        public IActionResult Index()
        {
            Fleet[] allFleets = _context
                .Fleets
                .Include(f => f.Ships)
                .AsNoTracking()
                .ToArray();
            return this.Json(allFleets);
        }
    }
}
