using AlphaFleet.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace AlphaFleet.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Faction Faction { get; set; } = Faction.None;
    }
}
