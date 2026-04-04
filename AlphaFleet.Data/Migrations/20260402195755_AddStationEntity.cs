using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlphaFleet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDestroyed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Description", "Health", "ImageUrl", "IsDestroyed", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-1234-56789abcdef0"), "A strategic outpost located in the Orion Sector, serving as a hub for fleet operations and logistics.", 100, "/images/stations/orion_outpost.jpg", false, "Orion Sector", "Orion Outpost" },
                    { new Guid("b1c2d3e4-f5a6-7890-2345-6789abcdef01"), "A heavily fortified station in the Vega System, known for its advanced defense systems and research facilities.", 100, "/images/stations/vega_station.jpg", false, "Vega System", "Vega Station" },
                    { new Guid("c1d2e3f4-a5b6-7890-3456-789abcdef012"), "A remote station in the Centauri System, primarily used for deep-space exploration and scientific research.", 100, "/images/stations/centauri_reach.jpg", false, "Centauri System", "Centauri Reach" },
                    { new Guid("d1e2f3a4-b5c6-7890-4567-89abcdef0123"), "A critical station located at the Sirius Gate, serving as a key transit point for fleet movements between sectors.", 100, "/images/stations/sirius_gate.jpg", false, "Sirius System", "Sirius Gate" },
                    { new Guid("e1f2a3b4-c5d6-7890-5678-9abcdef01234"), "A bustling station in the Andromeda Galaxy, known for its commercial activity and vibrant community of traders and mercenaries.", 100, "/images/stations/andromeda_port.jpg", false, "Andromeda Galaxy", "Andromeda Port" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
