using AlphaFleet.Data.Models;
using AlphaFleet.Services;
using AlphaFleet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlphaFleet.Controllers
{
    [Authorize]
    public class FleetController : Controller
    {
        private readonly IFleetService _fleetService;
        private readonly UserManager<ApplicationUser> _userManager;

        public FleetController(IFleetService fleetService, UserManager<ApplicationUser> userManager)
        {
            _fleetService = fleetService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Fleet> allFleets = await _fleetService.GetAllFleetsAsync(null);
            return this.View(allFleets);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            Fleet? fleet = await _fleetService.GetFleetByIdAsync(id);
            if (fleet == null)
            {
                return this.View("BadRequest");
            }
            return this.View(fleet);
        }
        [HttpGet]
        public async Task<IActionResult> MyFleet()
        {
            string userId = _userManager.GetUserId(User);
            Fleet? fleet = await _fleetService.GetUserFleetAsync(userId);
            if (fleet == null)
            {
                return RedirectToAction("Create");
            }
            return RedirectToAction("Details", new { id = fleet.Id });
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            string userId = _userManager.GetUserId(User)!;
            Fleet? existingFleet = await _fleetService.GetUserFleetAsync(userId);
            if (existingFleet != null)
            {
                TempData["FleetError"] = "You already command a fleet. A commander can only lead one fleet.";
                return RedirectToAction("MyFleet");
            }
            return View(new FleetFormViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FleetFormViewModel model)
        {
            string userId = _userManager.GetUserId(User)!;
            Fleet? existingFleet = await _fleetService.GetUserFleetAsync(userId);
            if (existingFleet != null)
            {
                TempData["FleetError"] = "You already command a fleet. A commander can only lead one fleet.";
                return RedirectToAction("MyFleet");
            }
            if (!ModelState.IsValid)
                return View(model);
            var fleet = new Fleet
            {
                Name = model.Name,
                Location = model.Location,
                UserId = userId,
            };

            await _fleetService.CreateFleetAsync(fleet);
            return RedirectToAction("Details", new { id = fleet.Id });
        }
    }
}
