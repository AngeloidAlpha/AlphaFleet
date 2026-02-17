using AlphaFleet.Models;
using AlphaFleet.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaFleet.Data.Configuration
{
    public class AdmiralEntityTypeConfiguration : IEntityTypeConfiguration<Admiral>
    {
        private readonly Admiral[] SeedAdmirals = new[]
        {
            new Admiral { Id = new Guid("99d05329-8efe-42b1-8d7e-aed411921502"), FirstName = "Marcus", LastName = "Varro", Rank = AdmiralRank.FleetAdmiral, Bio = "A veteran of the Sol Campaigns, Marcus Varro has commanded Alpha Fleet since its inception. Known for his tactical brilliance and unwavering composure under fire, he transformed a ragtag patrol group into the most decorated fleet in the sector.", ImageUrl = "/images/admirals/varro.jpg", FleetId = new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef") },
            new Admiral { Id = new Guid("3aebb0e2-4ec1-460d-aa0c-81ada509f2e8"), FirstName = "Elena", LastName = "Krieger", Rank = AdmiralRank.ViceAdmiral, Bio = "Elena Krieger rose through the ranks after the Battle of Orion Outpost, where she single-handedly coordinated the defense of three stations simultaneously. Her aggressive tactics and quick decision-making earned her command of Beta Squadron.", ImageUrl = "/images/admirals/krieger.jpg", FleetId = new Guid("4241c74f-092c-4249-b731-954fb7658830") },
            new Admiral { Id = new Guid("f510dfdb-07f8-4788-9b02-cec3cb7f9e26"), FirstName = "Idris", LastName = "Okonkwo", Rank = AdmiralRank.Admiral, Bio = "Idris Okonkwo is a strategist who prefers diplomacy over direct confrontation. His leadership of Gamma Wing has kept the Vega Station corridor open for trade during some of the most turbulent periods in recent memory.", ImageUrl = "/images/admirals/okonkwo.jpg", FleetId = new Guid("86634405-36a8-4727-93bd-97273e947361") },
            new Admiral { Id = new Guid("d34671ee-08b7-42f4-9e58-bd03298ba489"), FirstName = "Yuki", LastName = "Tanaka", Rank = AdmiralRank.RearAdmiral, Bio = "The youngest flag officer in the fleet, Yuki Tanaka was promoted after her daring rescue of the civilian convoy near Centauri Reach. She now commands Delta Fleet with a focus on exploration and humanitarian operations.", ImageUrl = "/images/admirals/tanaka.jpg", FleetId = new Guid("e40fcb34-fda4-4f52-889b-996b0040a7ce") },
            new Admiral { Id = new Guid("e7f9adaa-f6ba-4d6d-a560-d383ef9dda3e"), FirstName = "Aleksei", LastName = "Volkov", Rank = AdmiralRank.GrandAdmiral, Bio = "Grand Admiral Volkov is the supreme commander overseeing all fleet operations. A former fighter pilot turned tactician, he earned the highest rank after orchestrating the decisive victory at the Siege of Sirius Gate. His word is law across every division.", ImageUrl = "/images/admirals/volkov.jpg", FleetId = new Guid("44dee55a-f48f-419f-884b-943355bbde32") }
        };

        public void Configure(EntityTypeBuilder<Admiral> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(Common.EntityValidation.AdmiralNameMaxLength);

            builder.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(Common.EntityValidation.AdmiralNameMaxLength);

            builder.Property(a => a.Rank).IsRequired();

            builder.Property(a => a.Bio)
                .HasMaxLength(Common.EntityValidation.AdmiralBioMaxLength);

            builder.HasOne(a => a.Fleet)
                .WithOne(f => f.Admiral)
                .HasForeignKey<Admiral>(a => a.FleetId);

            builder.HasData(SeedAdmirals);
        }
    }
}
