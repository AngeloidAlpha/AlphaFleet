using AlphaFleet.Data;
using AlphaFleet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlphaFleet.Controllers
{
    public class ShipController : Controller
    {
        private readonly ApplicationDbContext _context;
        /* Constructor Injection - Most commonly used */
        /* Pattern to remember: Register in Collection then Consume */
        public ShipController(ApplicationDbContext dbContext)
        {
            /* Store the injected instance in a local field */
            _context = dbContext;
        }
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Ship> allShips = _context
                .Ships
                .AsNoTracking()
                .OrderBy(s => s.Name)
                .ThenBy(s => s.ShipHullClass)
                .ThenBy(s => s.Rarity)
                .ThenByDescending(s => s.IsAvailable) 
                .ThenByDescending (s => s.ShipProductionYear)
                .ToArray();
            return this.View(allShips);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Ship? ship = _context
                .Ships
                .Include(s => s.Fleet)
                .AsNoTracking()
                .SingleOrDefault(s => s.Id == id);
            if (ship == null)
            {
                return this.View("BadRequest");
            }
            return this.View(ship);
        }
    }
}
