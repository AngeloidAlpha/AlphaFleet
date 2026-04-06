using AlphaFleet.Data.Models;
using AlphaFleet.Services;
using AlphaFleet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlphaFleet.Controllers
{
    [Authorize]
    public class BattleController : Controller
    {
        private readonly IBattleService _battleService;
        private readonly IFleetService _fleetService;
        private readonly IStationService _stationService;
        public BattleController(IBattleService battleService, IFleetService fleetService, IStationService stationService)
        {
            _battleService = battleService;
            _fleetService = fleetService;
            _stationService = stationService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? search)
        {
            IEnumerable<Battle> battles = await _battleService.GetAllBattlesAsync(search);
            ViewData["CurrentSearch"] = search;
            return View(battles);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            Battle? battle = await _battleService.GetBattleByIdAsync(id);
            if (battle == null)
            {
                return NotFound();
            }
            return View(battle);
        }
        [HttpGet]
        public async Task<IActionResult> InitiateBattle()
        {
            var model = await BuildInitiateViewModelAsync();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InitiateBattle(InitiateBattleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var rebuilt = await BuildInitiateViewModelAsync();
                model.FleetOptions = rebuilt.FleetOptions;
                model.StationOptions = rebuilt.StationOptions;
                return View(model);
            }
            var battle = await _battleService.SimulateBattleAsync(
                model.AttackingFleetId!.Value,
                model.DefendingFleetId!.Value,
                model.DefendingStationId!.Value);

            return RedirectToAction(nameof(Details), new { id = battle.Id });
        }
        private async Task<InitiateBattleViewModel> BuildInitiateViewModelAsync()
        {
            var fleets = await _fleetService.GetAllFleetsAsync(null);
            var stations = await _stationService.GetAllStationAsync(null);

            return new InitiateBattleViewModel
            {
                FleetOptions = fleets.Select(f => new SelectListItem(f.Name, f.Id.ToString())),
                StationOptions = stations.Select(s => new SelectListItem(s.Name, s.Id.ToString()))
            };
        }
    }
}
