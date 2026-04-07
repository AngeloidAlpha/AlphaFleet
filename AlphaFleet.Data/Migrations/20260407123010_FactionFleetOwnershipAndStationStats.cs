using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaFleet.Data.Migrations
{
    /// <inheritdoc />
    public partial class FactionFleetOwnershipAndStationStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Attack",
                table: "Stations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defense",
                table: "Stations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Fleets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Faction",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("1ad72291-5fa1-4744-9db8-19a382b269fd"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("4241c74f-092c-4249-b731-954fb7658830"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("44dee55a-f48f-419f-884b-943355bbde32"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("596dc552-0964-4298-baa7-34bee5b255b3"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("6c6294c1-d329-4240-9620-d4bebed89fd3"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("86634405-36a8-4727-93bd-97273e947361"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("9ddf8528-35eb-433f-8486-29fc4123f4ff"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("c8186cc3-573a-411b-b2d7-a5fd40b9beaf"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("e40fcb34-fda4-4f52-889b-996b0040a7ce"),
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-56789abcdef0"),
                columns: new[] { "Attack", "Defense", "Health" },
                values: new object[] { 640, 64, 6400 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("b1c2d3e4-f5a6-7890-2345-6789abcdef01"),
                columns: new[] { "Attack", "Defense", "Health" },
                values: new object[] { 1280, 128, 12800 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("c1d2e3f4-a5b6-7890-3456-789abcdef012"),
                columns: new[] { "Attack", "Defense", "Health" },
                values: new object[] { 320, 32, 3200 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("d1e2f3a4-b5c6-7890-4567-89abcdef0123"),
                columns: new[] { "Attack", "Defense", "Health" },
                values: new object[] { 2560, 256, 25600 });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("e1f2a3b4-c5d6-7890-5678-9abcdef01234"),
                columns: new[] { "Attack", "Defense", "Description", "Health" },
                values: new object[] { 5120, 512, "A bustling station in the Andromeda Galaxy, known for its commercial activity and vibrant community of traders.", 51200 });

            migrationBuilder.CreateIndex(
                name: "IX_Fleets_UserId",
                table: "Fleets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fleets_AspNetUsers_UserId",
                table: "Fleets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fleets_AspNetUsers_UserId",
                table: "Fleets");

            migrationBuilder.DropIndex(
                name: "IX_Fleets_UserId",
                table: "Fleets");

            migrationBuilder.DropColumn(
                name: "Attack",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "Defense",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Fleets");

            migrationBuilder.DropColumn(
                name: "Faction",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-56789abcdef0"),
                column: "Health",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("b1c2d3e4-f5a6-7890-2345-6789abcdef01"),
                column: "Health",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("c1d2e3f4-a5b6-7890-3456-789abcdef012"),
                column: "Health",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("d1e2f3a4-b5c6-7890-4567-89abcdef0123"),
                column: "Health",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: new Guid("e1f2a3b4-c5d6-7890-5678-9abcdef01234"),
                columns: new[] { "Description", "Health" },
                values: new object[] { "A bustling station in the Andromeda Galaxy, known for its commercial activity and vibrant community of traders and mercenaries.", 100 });
        }
    }
}
