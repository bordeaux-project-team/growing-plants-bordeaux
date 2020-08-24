using Microsoft.EntityFrameworkCore.Migrations;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class ChangePlantingEnvironmentModelFieldsToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantingEnvironment_Humidity_HumidityId",
                table: "PlantingEnvironment");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingEnvironment_Light_LightId",
                table: "PlantingEnvironment");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingEnvironment_Temperature_TemperatureId",
                table: "PlantingEnvironment");

            migrationBuilder.DropIndex(
                name: "IX_PlantingEnvironment_HumidityId",
                table: "PlantingEnvironment");

            migrationBuilder.DropIndex(
                name: "IX_PlantingEnvironment_LightId",
                table: "PlantingEnvironment");

            migrationBuilder.DropIndex(
                name: "IX_PlantingEnvironment_TemperatureId",
                table: "PlantingEnvironment");

            migrationBuilder.DropColumn(
                name: "HumidityId",
                table: "PlantingEnvironment");

            migrationBuilder.DropColumn(
                name: "LightId",
                table: "PlantingEnvironment");

            migrationBuilder.DropColumn(
                name: "TemperatureId",
                table: "PlantingEnvironment");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "PlantingEnvironment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Humidity",
                table: "PlantingEnvironment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Light",
                table: "PlantingEnvironment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temperature",
                table: "PlantingEnvironment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "PlantingEnvironment");

            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "PlantingEnvironment");

            migrationBuilder.DropColumn(
                name: "Light",
                table: "PlantingEnvironment");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "PlantingEnvironment");

            migrationBuilder.AddColumn<int>(
                name: "HumidityId",
                table: "PlantingEnvironment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LightId",
                table: "PlantingEnvironment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TemperatureId",
                table: "PlantingEnvironment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantingEnvironment_HumidityId",
                table: "PlantingEnvironment",
                column: "HumidityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingEnvironment_LightId",
                table: "PlantingEnvironment",
                column: "LightId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingEnvironment_TemperatureId",
                table: "PlantingEnvironment",
                column: "TemperatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingEnvironment_Humidity_HumidityId",
                table: "PlantingEnvironment",
                column: "HumidityId",
                principalTable: "Humidity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingEnvironment_Light_LightId",
                table: "PlantingEnvironment",
                column: "LightId",
                principalTable: "Light",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingEnvironment_Temperature_TemperatureId",
                table: "PlantingEnvironment",
                column: "TemperatureId",
                principalTable: "Temperature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
