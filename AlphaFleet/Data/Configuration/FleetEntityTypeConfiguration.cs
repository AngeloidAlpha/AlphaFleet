using AlphaFleet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaFleet.Data.Configuration
{
    public class FleetEntityTypeConfiguration : IEntityTypeConfiguration<Fleet>
    {
        // Seed data defined at the type level so it's not recreated on every Configure call
        private static readonly Fleet[] SeedFleets = new[]
        {
            new Fleet { Id = new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), Name = "Alpha Fleet", Location = "Sol System" },
            new Fleet { Id = new Guid("4241c74f-092c-4249-b731-954fb7658830"), Name = "Beta Squadron", Location = "Orion Outpost" },
            new Fleet { Id = new Guid("86634405-36a8-4727-93bd-97273e947361"), Name = "Gamma Wing", Location = "Vega Station" },
            new Fleet { Id = new Guid("e40fcb34-fda4-4f52-889b-996b0040a7ce"), Name = "Delta Fleet", Location = "Centauri Reach" },
            new Fleet { Id = new Guid("44dee55a-f48f-419f-884b-943355bbde32"), Name = "Epsilon Armada", Location = "Sirius Gate" },
            new Fleet { Id = new Guid("c8186cc3-573a-411b-b2d7-a5fd40b9beaf"), Name = "Zeta Patrol", Location = "Andromeda Port" },
            new Fleet { Id = new Guid("9ddf8528-35eb-433f-8486-29fc4123f4ff"), Name = "Eta Convoy", Location = "Tau Outpost" },
            new Fleet { Id = new Guid("596dc552-0964-4298-baa7-34bee5b255b3"), Name = "Theta Squadron", Location = "Delta Quadrant" },
            new Fleet { Id = new Guid("6c6294c1-d329-4240-9620-d4bebed89fd3"), Name = "Iota Fleet", Location = "Laniakea Hub" },
            new Fleet { Id = new Guid("1ad72291-5fa1-4744-9db8-19a382b269fd"), Name = "Kappa Division", Location = "Orpheus Station" }
        };
        public void Configure(EntityTypeBuilder<Fleet> entity)
        {
            entity.HasKey(f => f.Id);

            // Basic property configuration (optional - ensures consistency with data annotations)
            entity.Property(f => f.Name).IsRequired();
            entity.Property(f => f.Location).IsRequired();
            // Use the shared seed data defined at type level
            entity.HasData(SeedFleets);
        }
    }
}
