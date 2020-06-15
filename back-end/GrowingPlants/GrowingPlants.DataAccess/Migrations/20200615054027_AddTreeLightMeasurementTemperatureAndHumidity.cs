using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class AddTreeLightMeasurementTemperatureAndHumidity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasurementUnit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Humidity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FromUnit = table.Column<int>(nullable: false),
                    ToUnit = table.Column<int>(nullable: false),
                    MeasurementUnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humidity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Humidity_MeasurementUnit_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Light",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FromUnit = table.Column<int>(nullable: false),
                    ToUnit = table.Column<int>(nullable: false),
                    MeasurementUnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Light", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Light_MeasurementUnit_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FromDegree = table.Column<int>(nullable: false),
                    ToDegree = table.Column<int>(nullable: false),
                    MeasurementUnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperature_MeasurementUnit_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tree",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ComparisonWith = table.Column<string>(nullable: true),
                    ComparisonAgainst = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    GerminationTime = table.Column<int>(nullable: false),
                    VegetativeTime = table.Column<int>(nullable: false),
                    FloweringTime = table.Column<int>(nullable: false),
                    HarvestTime = table.Column<int>(nullable: false),
                    LightId = table.Column<int>(nullable: true),
                    TemperatureId = table.Column<int>(nullable: true),
                    HumidityId = table.Column<int>(nullable: true),
                    GardenType = table.Column<string>(nullable: true),
                    PlantingGuide = table.Column<string>(nullable: true),
                    ExposureTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tree_Humidity_HumidityId",
                        column: x => x.HumidityId,
                        principalTable: "Humidity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tree_Light_LightId",
                        column: x => x.LightId,
                        principalTable: "Light",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tree_Temperature_TemperatureId",
                        column: x => x.TemperatureId,
                        principalTable: "Temperature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Humidity_MeasurementUnitId",
                table: "Humidity",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Light_MeasurementUnitId",
                table: "Light",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperature_MeasurementUnitId",
                table: "Temperature",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Tree_HumidityId",
                table: "Tree",
                column: "HumidityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tree_LightId",
                table: "Tree",
                column: "LightId");

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
                name: "Humidity");

            migrationBuilder.DropTable(
                name: "Light");

            migrationBuilder.DropTable(
                name: "Temperature");

            migrationBuilder.DropTable(
                name: "MeasurementUnit");
        }
    }
}
