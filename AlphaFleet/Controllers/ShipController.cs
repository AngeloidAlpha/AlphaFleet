using AlphaFleet.Data.Models;
using AlphaFleet.Data.Models.ViewModels;
using AlphaFleet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlphaFleet.Controllers
{
    [Authorize]
    public class ShipController : Controller
    {
        private readonly IShipService _shipService;
        private readonly IGachaService _gachaService;

        public ShipController(IShipService shipService, IGachaService gachaService)
        {
            _shipService = shipService;
            _gachaService = gachaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? search)
        {
            IEnumerable<Ship> allShips = await _shipService.GetAllShipsAsync(search);
            ViewData["CurrentSearch"] = search;
            return View(allShips);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            Ship? ship = await _shipService.GetShipByIdAsync(id);
            if (ship == null) 
                return View("BadRequest");
            return View(ship);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new ShipFormViewModel
            {
                Fleets = await _shipService.GetAllFleetsAsync()
            };
            return View(model);
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
        public async Task<IActionResult> Create(ShipFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Fleets = await _shipService.GetAllFleetsAsync();
                return View(model);
            }

            var ship = new Ship
            {
                Name = model.Name,
                Class = model.ShipHullClass.ToString(),
                ShipHullClass = model.ShipHullClass,
                Rarity = model.Rarity,
                ShipProductionYear = model.ShipProductionYear,
                ImageUrl = model.ImageUrl ?? string.Empty,
                History = model.History ?? string.Empty,
                FleetId = model.FleetId,
                IsAvailable = model.IsAvailable
            };

            await _shipService.CreateShipAsync(ship);
            return RedirectToAction("Details", new { id = ship.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            Ship? ship = await _shipService.GetShipByIdAsync(id);
            if (ship == null) 
                return View("BadRequest");

            var model = new ShipFormViewModel
            {
                Name = ship.Name,
                ShipHullClass = ship.ShipHullClass,
                Rarity = ship.Rarity,
                ShipProductionYear = ship.ShipProductionYear,
                ImageUrl = ship.ImageUrl,
                History = ship.History,
                FleetId = ship.FleetId,
                IsAvailable = ship.IsAvailable,
                Fleets = await _shipService.GetAllFleetsAsync()
            };

            ViewData["ShipId"] = id;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ShipFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Fleets = await _shipService.GetAllFleetsAsync();
                ViewData["ShipId"] = id;
                return View(model);
            }

            Ship? ship = await _shipService.GetShipByIdAsync(id);
            if (ship == null) 
                return View("BadRequest");

            ship.Name = model.Name;
            ship.Class = model.ShipHullClass.ToString();
            ship.ShipHullClass = model.ShipHullClass;
            ship.Rarity = model.Rarity;
            ship.ShipProductionYear = model.ShipProductionYear;
            ship.ImageUrl= model.ImageUrl ?? string.Empty;
            ship.History = model.History ?? string.Empty;
            ship.FleetId = model.FleetId;
            ship.IsAvailable = model.IsAvailable;

            await _shipService.UpdateShipAsync(ship);
            return RedirectToAction("Details", new { id = ship.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            Ship? ship = await _shipService.GetShipByIdAsync(id);
            if (ship == null) return View("BadRequest");
            return View(ship);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, Ship model)
        {
            await _shipService.DeleteShipAsync(id);
            return RedirectToAction("Index");
        }
    }
}
