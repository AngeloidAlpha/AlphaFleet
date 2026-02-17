using AlphaFleet.Data.Models;
using AlphaFleet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlphaFleet.Controllers
{
    [Authorize]
    public class FleetController : Controller
    {
        private readonly IFleetService _fleetService;

        public FleetController(IFleetService fleetService)
        {
            _fleetService = fleetService;
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
    }
}
