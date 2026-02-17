using AlphaFleet.Data;
using AlphaFleet.Data.Models;
using AlphaFleet.Data.Models.ViewModels;
using AlphaFleet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlphaFleet.Controllers
{
    [Authorize]
    public class ShipController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly GachaService _gachaService;
        /* Constructor Injection - Most commonly used */
        /* Pattern to remember: Register in Collection then Consume */
        public ShipController(ApplicationDbContext dbContext, GachaService gachaService)
        {
            /* Store the injected instance in a local field */
            _context = dbContext;
            _gachaService = gachaService;
        }
        [HttpGet]
        public IActionResult Index(string? search)
        {
            IQueryable<Ship> query = _context
                .Ships
                .Include(s => s.Fleet)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                string searchTerm = search
                    .Trim()
                    .ToLower();
                query = query.Where(s =>
                    s.Name.ToLower().Contains(searchTerm) ||
                    s.Class.ToLower().Contains(searchTerm));
            }

            IEnumerable<Ship> allShips = query
                .OrderBy(s => s.Name)
                .ThenBy(s => s.ShipHullClass)
                .ThenBy(s => s.Rarity)
                .ThenByDescending(s => s.IsAvailable)
                .ThenByDescending(s => s.ShipProductionYear)
                .ToArray();

            ViewData["CurrentSearch"] = search;
            return this.View(allShips);
        }
        [HttpGet]
        public IActionResult Details(Guid id)
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
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ShipFormViewModel
            {
                Fleets = _context
                .Fleets
                .AsNoTracking()
                .OrderBy(f => f.Name)
                .ToList()
            };
            return this.View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RollRarity()
        {
            var rarity = _gachaService.RollRarity();
            return Json(new { rarity = rarity.ToString(), value = (int)rarity });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ShipFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Fleets = _context
                    .Fleets
                    .AsNoTracking()
                    .OrderBy(f => f.Name)
                    .ToList();
                return this.View(model);
            }

            var ship = new Ship
            {
                Name = model.Name,
                Class = model.Class,
                ShipHullClass = model.ShipHullClass,
                Rarity = model.Rarity,
                ShipProductionYear = model.ShipProductionYear,
                ImageUrl = model.ImageUrl ?? string.Empty,
                History = model.History ?? string.Empty,
                FleetId = model.FleetId,
                IsAvailable = model.IsAvailable
            };

            _context.Ships.Add(ship);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = ship.Id });
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Ship? ship = _context.Ships.Find(id);
            if (ship == null)
            {
                return this.View("BadRequest");
            }

            var model = new ShipFormViewModel
            {
                Name = ship.Name,
                Class = ship.Class,
                ShipHullClass = ship.ShipHullClass,
                Rarity = ship.Rarity,
                ShipProductionYear = ship.ShipProductionYear,
                ImageUrl = ship.ImageUrl,
                History = ship.History,
                FleetId = ship.FleetId,
                IsAvailable = ship.IsAvailable,
                Fleets = _context.Fleets.AsNoTracking().OrderBy(f => f.Name).ToList()
            };

            ViewData["ShipId"] = id;
            return this.View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, ShipFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Fleets = _context.Fleets.AsNoTracking().OrderBy(f => f.Name).ToList();
                ViewData["ShipId"] = id;
                return this.View(model);
            }

            Ship? ship = _context.Ships.Find(id);
            if (ship == null)
            {
                return this.View("BadRequest");
            }

            ship.Name = model.Name;
            ship.Class = model.Class;
            ship.ShipHullClass = model.ShipHullClass;
            ship.Rarity = model.Rarity;
            ship.ShipProductionYear = model.ShipProductionYear;
            ship.ImageUrl = model.ImageUrl ?? string.Empty;
            ship.History = model.History ?? string.Empty;
            ship.FleetId = model.FleetId;
            ship.IsAvailable = model.IsAvailable;

            _context.SaveChanges();

            return RedirectToAction("Details", new { id = ship.Id });
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, Ship model)
        {
            Ship? ship = _context.Ships.Find(id);
            if (ship == null)
            {
                return this.View("BadRequest");
            }

            _context.Ships.Remove(ship);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
