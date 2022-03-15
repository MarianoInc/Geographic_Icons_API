using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Geographic_Icons_API.Migrations
{
    public partial class CreateGeographicIconsDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    ContinentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContinentPicture = table.Column<byte[]>(nullable: true),
                    ContinentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.ContinentId);
                });

            migrationBuilder.CreateTable(
                name: "GeographicIcons",
                columns: table => new
                {
                    GeographicIconId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeographicIconPicture = table.Column<byte[]>(nullable: true),
                    FinishingDate = table.Column<DateTime>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    History = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeographicIcons", x => x.GeographicIconId);
                });

            migrationBuilder.CreateTable(
                name: "CitiesCountries",
                columns: table => new
                {
                    CityCountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityCountryPicture = table.Column<byte[]>(nullable: true),
                    CityCountryName = table.Column<string>(nullable: true),
                    Population = table.Column<decimal>(nullable: false),
                    TotalLandArea = table.Column<decimal>(nullable: false),
                    ContinentId = table.Column<int>(nullable: true),
                    GeographicIconId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitiesCountries", x => x.CityCountryId);
                    table.ForeignKey(
                        name: "FK_CitiesCountries_Continents_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continents",
                        principalColumn: "ContinentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitiesCountries_GeographicIcons_GeographicIconId",
                        column: x => x.GeographicIconId,
                        principalTable: "GeographicIcons",
                        principalColumn: "GeographicIconId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitiesCountries_ContinentId",
                table: "CitiesCountries",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_CitiesCountries_GeographicIconId",
                table: "CitiesCountries",
                column: "GeographicIconId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitiesCountries");

            migrationBuilder.DropTable(
                name: "Continents");

            migrationBuilder.DropTable(
                name: "GeographicIcons");
        }
    }
}
