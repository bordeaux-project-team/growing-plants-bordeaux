using Microsoft.EntityFrameworkCore.Migrations;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class ChangePlantingActionModelFieldsToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantingAction_MeasurementUnit_MeasurementUnitId",
                table: "PlantingAction");

            migrationBuilder.DropIndex(
                name: "IX_PlantingAction_MeasurementUnitId",
                table: "PlantingAction");

            migrationBuilder.DropColumn(
                name: "MeasurementUnitId",
                table: "PlantingAction");

            migrationBuilder.AddColumn<string>(
                name: "MeasurementUnit",
                table: "PlantingAction",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasurementUnit",
                table: "PlantingAction");

            migrationBuilder.AddColumn<int>(
                name: "MeasurementUnitId",
                table: "PlantingAction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantingAction_MeasurementUnitId",
                table: "PlantingAction",
                column: "MeasurementUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingAction_MeasurementUnit_MeasurementUnitId",
                table: "PlantingAction",
                column: "MeasurementUnitId",
                principalTable: "MeasurementUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
