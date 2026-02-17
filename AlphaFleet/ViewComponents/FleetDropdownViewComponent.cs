using AlphaFleet.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlphaFleet.ViewComponents
{
    public class FleetDropdownViewComponent : ViewComponent
    {
        private readonly IFleetService _fleetService;

        public FleetDropdownViewComponent(IFleetService fleetService)
        {
            _fleetService = fleetService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var fleets = await _fleetService.GetAllFleetsAsync(null);
            return View(fleets);
        }
    }
}
