using AlphaFleet.Common;
using AlphaFleet.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static AlphaFleet.Common.EntityValidation;

namespace AlphaFleet.Data.Configuration
{
    public class StationEntityTypeConfiguration : IEntityTypeConfiguration<Station>
    {
        private readonly Station[] SeedStations = new[]
        {
            new Station { Id = new Guid("a1b2c3d4-e5f6-7890-1234-56789abcdef0"), Name = "Orion Outpost", Location = "Orion Sector", Description = "A strategic outpost located in the Orion Sector, serving as a hub for fleet operations and logistics.", Health = 100, ImageUrl = "/images/stations/orion_outpost.jpg", IsDestroyed = false },
            new Station { Id = new Guid("b1c2d3e4-f5a6-7890-2345-6789abcdef01"), Name = "Vega Station", Location = "Vega System", Description = "A heavily fortified station in the Vega System, known for its advanced defense systems and research facilities.", Health = 100, ImageUrl = "/images/stations/vega_station.jpg", IsDestroyed = false },
            new Station { Id = new Guid("c1d2e3f4-a5b6-7890-3456-789abcdef012"), Name = "Centauri Reach", Location = "Centauri System", Description = "A remote station in the Centauri System, primarily used for deep-space exploration and scientific research.", Health = 100, ImageUrl = "/images/stations/centauri_reach.jpg", IsDestroyed = false },
            new Station { Id = new Guid("d1e2f3a4-b5c6-7890-4567-89abcdef0123"), Name = "Sirius Gate", Location = "Sirius System", Description = "A critical station located at the Sirius Gate, serving as a key transit point for fleet movements between sectors.", Health = 100, ImageUrl = "/images/stations/sirius_gate.jpg", IsDestroyed = false },
            new Station { Id = new Guid("e1f2a3b4-c5d6-7890-5678-9abcdef01234"), Name = "Andromeda Port", Location = "Andromeda Galaxy", Description = "A bustling station in the Andromeda Galaxy, known for its commercial activity and vibrant community of traders and mercenaries.", Health = 100, ImageUrl = "/images/stations/andromeda_port.jpg", IsDestroyed = false }
        };
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(EntityValidation.StationNameMaxLength);
            builder.Property(s => s.Location).IsRequired().HasMaxLength(EntityValidation.StationLocationMaxLength);
            builder.Property(s => s.Health).IsRequired();
            builder.Property(s => s.Description).HasMaxLength(EntityValidation.StationDescriptionMaxLength);
            builder.HasData(SeedStations);
        }
    }
}