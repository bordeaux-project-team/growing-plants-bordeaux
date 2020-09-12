using Microsoft.EntityFrameworkCore.Migrations;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class AddPlantingSpotToPlantingProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlantingSpotId",
                table: "PlantingProcess",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantingProcess_PlantingSpotId",
                table: "PlantingProcess",
                column: "PlantingSpotId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingProcess_PlantingSpot_PlantingSpotId",
                table: "PlantingProcess",
                column: "PlantingSpotId",
                principalTable: "PlantingSpot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantingProcess_PlantingSpot_PlantingSpotId",
                table: "PlantingProcess");

            migrationBuilder.DropIndex(
                name: "IX_PlantingProcess_PlantingSpotId",
                table: "PlantingProcess");

            migrationBuilder.DropColumn(
                name: "PlantingSpotId",
                table: "PlantingProcess");
        }
    }
}
