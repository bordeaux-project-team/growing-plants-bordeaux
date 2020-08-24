using Microsoft.EntityFrameworkCore.Migrations;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class ChangeTreeModelFieldsToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tree_Humidity_HumidityId",
                table: "Tree");

            migrationBuilder.DropForeignKey(
                name: "FK_Tree_Light_LightId",
                table: "Tree");

            migrationBuilder.DropForeignKey(
                name: "FK_Tree_PlantType_PlantTypeId",
                table: "Tree");

            migrationBuilder.DropForeignKey(
                name: "FK_Tree_Temperature_TemperatureId",
                table: "Tree");

            migrationBuilder.DropIndex(
                name: "IX_Tree_HumidityId",
                table: "Tree");

            migrationBuilder.DropIndex(
                name: "IX_Tree_LightId",
                table: "Tree");

            migrationBuilder.DropIndex(
                name: "IX_Tree_PlantTypeId",
                table: "Tree");

            migrationBuilder.DropIndex(
                name: "IX_Tree_TemperatureId",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "HumidityId",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "LightId",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "PlantTypeId",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "TemperatureId",
                table: "Tree");

            migrationBuilder.AddColumn<string>(
                name: "Humidity",
                table: "Tree",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Light",
                table: "Tree",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlantType",
                table: "Tree",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temperature",
                table: "Tree",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "Light",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "PlantType",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Tree");

            migrationBuilder.AddColumn<int>(
                name: "HumidityId",
                table: "Tree",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LightId",
                table: "Tree",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlantTypeId",
                table: "Tree",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TemperatureId",
                table: "Tree",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tree_HumidityId",
                table: "Tree",
                column: "HumidityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tree_LightId",
                table: "Tree",
                column: "LightId");

            migrationBuilder.CreateIndex(
                name: "IX_Tree_PlantTypeId",
                table: "Tree",
                column: "PlantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tree_TemperatureId",
                table: "Tree",
                column: "TemperatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tree_Humidity_HumidityId",
                table: "Tree",
                column: "HumidityId",
                principalTable: "Humidity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tree_Light_LightId",
                table: "Tree",
                column: "LightId",
                principalTable: "Light",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tree_PlantType_PlantTypeId",
                table: "Tree",
                column: "PlantTypeId",
                principalTable: "PlantType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tree_Temperature_TemperatureId",
                table: "Tree",
                column: "TemperatureId",
                principalTable: "Temperature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
