using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class TestTreeTemperature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FromDegree = table.Column<int>(nullable: false),
                    ToDegree = table.Column<int>(nullable: false),
                    MeasurementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tree",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ComparisonWith = table.Column<string>(nullable: true),
                    ComparisonAgainst = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    GerminationTime = table.Column<int>(nullable: false),
                    VegetativeTime = table.Column<int>(nullable: false),
                    FloweringTime = table.Column<int>(nullable: false),
                    HarvestTime = table.Column<int>(nullable: false),
                    LightId = table.Column<int>(nullable: false),
                    TemperatureId = table.Column<int>(nullable: false),
                    HumidityId = table.Column<int>(nullable: false),
                    GardenType = table.Column<string>(nullable: true),
                    PlantingGuide = table.Column<string>(nullable: true),
                    ExposureTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tree_Temperature_TemperatureId",
                        column: x => x.TemperatureId,
                        principalTable: "Temperature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tree_TemperatureId",
                table: "Tree",
                column: "TemperatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tree");

            migrationBuilder.DropTable(
                name: "Temperature");
        }
    }
}
