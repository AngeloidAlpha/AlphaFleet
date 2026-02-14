using AlphaFleet.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AlphaFleet.Models
{
    public class Ship
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public ShipRarity Rarity { get; set; }
        public int ShipProductionYear { get; set; }
        public ShipHullClass ShipHullClass { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAvaible { get; set; }
        public Guid FleetID { get; set; }
        public virtual Fleet Fleet { get; set; }


    }
}
