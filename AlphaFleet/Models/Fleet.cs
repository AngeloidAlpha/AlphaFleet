using System.ComponentModel.DataAnnotations;

namespace AlphaFleet.Models
{
    public class Fleet
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public virtual ICollection<Fleet> Fleets { get; set; } 
            = new HashSet<Fleet>();
    }
}
