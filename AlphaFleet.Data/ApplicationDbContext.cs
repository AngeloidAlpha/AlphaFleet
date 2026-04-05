using AlphaFleet.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlphaFleet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ship> Ships { get; set; }
        public virtual DbSet<Fleet> Fleets { get; set; }
        public virtual DbSet<Admiral> Admirals { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Battle> Battles { get; set; }
        public virtual DbSet<BattleTurn> BattleTurns { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
