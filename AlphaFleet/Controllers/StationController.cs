using AlphaFleet.Data.Models;
using AlphaFleet.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace AlphaFleet.Controllers
{
    public class StationController : Controller
    {
        private readonly IStationService _stationService;
        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? search)
        {
            IEnumerable<Station> stations = await _stationService.GetAllStationAsync(search);
            ViewData["CurrentSerach"] = search;
            return View(stations);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            Station? station = await _stationService.GetStationByIdAsync(id);
            if (station == null)
            {
                return View("BadRequest");
            }
            return View(station);
        }
        // TODO: Add Create, Edit, Delete actions similarly to ShipController
    }
}
