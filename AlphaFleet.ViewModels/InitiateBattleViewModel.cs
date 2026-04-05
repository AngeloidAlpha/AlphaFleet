using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AlphaFleet.ViewModels
{
    public class InitiateBattleViewModel
    {
        [Required(ErrorMessage = "Please select an attacking fleet.")]
        [Display(Name = "Attacking Fleet")]
        public Guid? AttackingFleetId { get; set; }

        [Required(ErrorMessage = "Please select a defending fleet.")]
        [Display(Name = "Defending Fleet")]
        public Guid? DefendingFleetId { get; set; }

        [Required(ErrorMessage = "Please select a defending station.")]
        [Display(Name = "Defending Station")]
        public Guid? DefendingStationId { get; set; }

        // Populated by the controller on GET and on validation failure re-render
        public IEnumerable<SelectListItem> FleetOptions { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> StationOptions { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
