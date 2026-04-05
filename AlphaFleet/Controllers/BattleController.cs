using AlphaFleet.Data.Models;
using AlphaFleet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InitiateBattle(Guid attackingFleetID, Guid defendingStationId)
        {
            var outcome = await _battleService.SimulateBattleAsync(attackingFleetID, defendingStationId);
            return Json(new { outcome = outcome.ToString() });
        }
    }
}
