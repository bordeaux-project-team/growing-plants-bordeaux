using Microsoft.EntityFrameworkCore.Migrations;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class AddUserToPlantingEnvironment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PlantingProcess",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PlantingEnvironment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantingProcess_UserId",
                table: "PlantingProcess",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingEnvironment_UserId",
                table: "PlantingEnvironment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingEnvironment_User_UserId",
                table: "PlantingEnvironment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingProcess_User_UserId",
                table: "PlantingProcess",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantingEnvironment_User_UserId",
                table: "PlantingEnvironment");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingProcess_User_UserId",
                table: "PlantingProcess");

            migrationBuilder.DropIndex(
                name: "IX_PlantingProcess_UserId",
                table: "PlantingProcess");

            migrationBuilder.DropIndex(
                name: "IX_PlantingEnvironment_UserId",
                table: "PlantingEnvironment");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PlantingProcess");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PlantingEnvironment");
        }
    }
}
