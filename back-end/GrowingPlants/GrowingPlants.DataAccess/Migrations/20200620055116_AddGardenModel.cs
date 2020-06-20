using Microsoft.EntityFrameworkCore.Migrations;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class AddGardenModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tree_PlantingEnvironment_PlantingEnvironmentId",
                table: "Tree");

            migrationBuilder.DropIndex(
                name: "IX_Tree_PlantingEnvironmentId",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "PlantingEnvironmentId",
                table: "Tree");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlantingEnvironmentId",
                table: "Tree",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tree_PlantingEnvironmentId",
                table: "Tree",
                column: "PlantingEnvironmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tree_PlantingEnvironment_PlantingEnvironmentId",
                table: "Tree",
                column: "PlantingEnvironmentId",
                principalTable: "PlantingEnvironment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
