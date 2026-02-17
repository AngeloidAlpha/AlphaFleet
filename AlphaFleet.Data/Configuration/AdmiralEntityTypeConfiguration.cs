using AlphaFleet.Data.Models;
using AlphaFleet.Data.Models.Enums;
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
            new Admiral { Id = new Guid("e7f9adaa-f6ba-4d6d-a560-d383ef9dda3e"), FirstName = "Aleksei", LastName = "Volkov", Rank = AdmiralRank.GrandAdmiral, Bio = "Grand Admiral Volkov is the supreme commander overseeing all fleet operations. A former fighter pilot turned tactician, he earned the highest rank after orchestrating the decisive victory at the Siege of Sirius Gate. His word is law across every division.", ImageUrl = "/images/admirals/volkov.jpg", FleetId = new Guid("44dee55a-f48f-419f-884b-943355bbde32") },
            new Admiral { Id = new Guid("b7c3d8a1-5e4f-4a92-8d16-7f3b2c9e1d04"), FirstName = "Nadia", LastName = "Reyes", Rank = AdmiralRank.Admiral, Bio = "Nadia Reyes is a former intelligence officer who transitioned to fleet command after uncovering a pirate syndicate in the Andromeda corridor. Her sharp instincts and network of informants make Zeta Patrol the most well-informed unit in the navy.", ImageUrl = "/images/admirals/reyes.jpg", FleetId = new Guid("c8186cc3-573a-411b-b2d7-a5fd40b9beaf") },
            new Admiral { Id = new Guid("4e8a1f6c-d293-47b5-a81e-9c5f0e7d2a38"), FirstName = "Henrik", LastName = "Stålberg", Rank = AdmiralRank.RearAdmiral, Bio = "Henrik Stålberg is a logistics genius who keeps the supply lines running no matter the circumstances. Under his command, Eta Convoy has never lost a single cargo shipment, earning him the nickname 'The Unbreakable Chain'.", ImageUrl = "/images/admirals/stalberg.jpg", FleetId = new Guid("9ddf8528-35eb-433f-8486-29fc4123f4ff") },
            new Admiral { Id = new Guid("a2d9c7e5-1b84-4f63-90ae-6d8b3f5c4e17"), FirstName = "Priya", LastName = "Sharma", Rank = AdmiralRank.ViceAdmiral, Bio = "Vice Admiral Sharma is a decorated combat pilot who flew over 300 sorties before taking command of Theta Squadron. Her hands-on leadership style and refusal to send her crews anywhere she wouldn't go herself have earned her fierce loyalty.", ImageUrl = "/images/admirals/sharma.jpg", FleetId = new Guid("596dc552-0964-4298-baa7-34bee5b255b3") },
            new Admiral { Id = new Guid("6f1e4b8d-c5a2-49d7-b3f0-8e2d7a9c6b51"), FirstName = "Kofi", LastName = "Mensah", Rank = AdmiralRank.FleetAdmiral, Bio = "Fleet Admiral Mensah is a visionary who championed the construction of Laniakea Hub as a forward operating base. His bold expansionist strategy doubled the navy's operational range and opened new territories for exploration.", ImageUrl = "/images/admirals/mensah.jpg", FleetId = new Guid("6c6294c1-d329-4240-9620-d4bebed89fd3") },
            new Admiral { Id = new Guid("c8d3a5f2-7e19-4b06-a4d8-1f9e6c3b5d72"), FirstName = "Svetlana", LastName = "Petrov", Rank = AdmiralRank.Admiral, Bio = "Admiral Petrov commands Kappa Division from the remote Orpheus Station, where he oversees deep-space patrol and border defense. A master of asymmetric warfare, she has repelled incursions from forces ten times her fleet's size.", ImageUrl = "/images/admirals/petrov.jpg", FleetId = new Guid("1ad72291-5fa1-4744-9db8-19a382b269fd") }
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
