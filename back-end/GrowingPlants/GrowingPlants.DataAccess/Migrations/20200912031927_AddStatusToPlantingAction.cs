using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class AddStatusToPlantingAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PlantingAction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "PlantingAction");

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 564, DateTimeKind.Local).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2480));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2503));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2514));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2516));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2518));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2523));
        }
    }
}
