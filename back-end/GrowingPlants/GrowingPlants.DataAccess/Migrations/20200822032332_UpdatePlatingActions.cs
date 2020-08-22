using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class UpdatePlatingActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "PlantingAction");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ActionTime",
                table: "PlantingAction",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "PlantingAction",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionTime",
                table: "PlantingAction");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PlantingAction");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "PlantingAction",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
