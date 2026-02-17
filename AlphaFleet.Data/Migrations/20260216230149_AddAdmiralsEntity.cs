using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlphaFleet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAdmiralsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admirals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FleetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admirals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admirals_Fleets_FleetId",
                        column: x => x.FleetId,
                        principalTable: "Fleets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admirals",
                columns: new[] { "Id", "Bio", "FirstName", "FleetId", "ImageUrl", "LastName", "Rank" },
                values: new object[,]
                {
                    { new Guid("99d05329-8efe-42b1-8d7e-aed411921502"), "A veteran of the Sol Campaigns, Marcus Varro has commanded Alpha Fleet since its inception. Known for his tactical brilliance and unwavering composure under fire, he transformed a ragtag patrol group into the most decorated fleet in the sector.", "Marcus", new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), "/images/admirals/varro.jpg", "Varro", 3 },
                    { new Guid("3aebb0e2-4ec1-460d-aa0c-81ada509f2e8"), "Elena Krieger rose through the ranks after the Battle of Orion Outpost, where she single-handedly coordinated the defense of three stations simultaneously. Her aggressive tactics and quick decision-making earned her command of Beta Squadron.", "Elena", new Guid("4241c74f-092c-4249-b731-954fb7658830"), "/images/admirals/krieger.jpg", "Krieger", 1 },
                    { new Guid("f510dfdb-07f8-4788-9b02-cec3cb7f9e26"), "Idris Okonkwo is a strategist who prefers diplomacy over direct confrontation. His leadership of Gamma Wing has kept the Vega Station corridor open for trade during some of the most turbulent periods in recent memory.", "Idris", new Guid("86634405-36a8-4727-93bd-97273e947361"), "/images/admirals/okonkwo.jpg", "Okonkwo", 2 },
                    { new Guid("d34671ee-08b7-42f4-9e58-bd03298ba489"), "The youngest flag officer in the fleet, Yuki Tanaka was promoted after her daring rescue of the civilian convoy near Centauri Reach. She now commands Delta Fleet with a focus on exploration and humanitarian operations.", "Yuki", new Guid("e40fcb34-fda4-4f52-889b-996b0040a7ce"), "/images/admirals/tanaka.jpg", "Tanaka", 0 },
                    { new Guid("e7f9adaa-f6ba-4d6d-a560-d383ef9dda3e"), "Grand Admiral Volkov is the supreme commander overseeing all fleet operations. A former fighter pilot turned tactician, he earned the highest rank after orchestrating the decisive victory at the Siege of Sirius Gate. His word is law across every division.", "Aleksei", new Guid("44dee55a-f48f-419f-884b-943355bbde32"), "/images/admirals/volkov.jpg", "Volkov", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admirals_FleetId",
                table: "Admirals",
                column: "FleetId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admirals");
        }
    }
}
