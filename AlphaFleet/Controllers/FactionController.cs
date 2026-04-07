using AlphaFleet.Data.Models;
using AlphaFleet.Data.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlphaFleet.Controllers
{
    [Authorize]
    public class FactionController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public FactionController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Choose()
        {
            ApplicationUser? user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            ViewData["CurrentFaction"] = user.Faction;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Choose(Faction faction)
        {
            if (faction == Faction.None)
            {
                ModelState.AddModelError(string.Empty, "Please select a valid faction.");
                return View();
            }

            ApplicationUser? user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            user.Faction = faction;
            await _userManager.UpdateAsync(user);

            TempData["FactionMessage"] = $"You have pledged your allegiance to the {faction}!";
            return RedirectToAction("Choose");
        }
    }
}
