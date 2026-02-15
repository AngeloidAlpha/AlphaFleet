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
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Fleet> allFleets = _context
                .Fleets
                .Include(f => f.Ships)
                .AsSplitQuery()
                .AsNoTracking()
                .ToArray();
            return this.View(allFleets);
        }
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            Fleet? fleet = _context
                .Fleets
                .Include(f => f.Ships)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefault(f => f.Id == id);
            if (fleet == null)
            {
                return this.View("BadRequest");
            }
            return this.View(fleet);
        }
    }
}
