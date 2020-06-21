using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class UpdateGardenToPlantingSpot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garden");

            migrationBuilder.CreateTable(
                name: "PlantingSpot",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    TreeId = table.Column<int>(nullable: true),
                    PlantingEnvironmentId = table.Column<int>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantingSpot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantingSpot_PlantingEnvironment_PlantingEnvironmentId",
                        column: x => x.PlantingEnvironmentId,
                        principalTable: "PlantingEnvironment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantingSpot_Tree_TreeId",
                        column: x => x.TreeId,
                        principalTable: "Tree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantingSpot_PlantingEnvironmentId",
                table: "PlantingSpot",
                column: "PlantingEnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingSpot_TreeId",
                table: "PlantingSpot",
                column: "TreeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantingSpot");

            migrationBuilder.CreateTable(
                name: "Garden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlantingEnvironmentId = table.Column<int>(type: "int", nullable: true),
                    TreeId = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Garden_PlantingEnvironment_PlantingEnvironmentId",
                        column: x => x.PlantingEnvironmentId,
                        principalTable: "PlantingEnvironment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Garden_Tree_TreeId",
                        column: x => x.TreeId,
                        principalTable: "Tree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Garden_PlantingEnvironmentId",
                table: "Garden",
                column: "PlantingEnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Garden_TreeId",
                table: "Garden",
                column: "TreeId");
        }
    }
}
