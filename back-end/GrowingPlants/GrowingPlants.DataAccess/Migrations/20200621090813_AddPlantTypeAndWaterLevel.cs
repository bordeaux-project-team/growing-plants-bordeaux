using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class AddPlantTypeAndWaterLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessStep_Notification_NotificationId",
                table: "ProcessStep");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessStep_PlantingAction_PlantingActionId",
                table: "ProcessStep");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessStep_Recurrence_RecurrenceId",
                table: "ProcessStep");

            migrationBuilder.DropIndex(
                name: "IX_ProcessStep_NotificationId",
                table: "ProcessStep");

            migrationBuilder.DropIndex(
                name: "IX_ProcessStep_PlantingActionId",
                table: "ProcessStep");

            migrationBuilder.DropIndex(
                name: "IX_ProcessStep_RecurrenceId",
                table: "ProcessStep");

            migrationBuilder.DropColumn(
                name: "GardenType",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "NotificationId",
                table: "ProcessStep");

            migrationBuilder.DropColumn(
                name: "PlantingActionId",
                table: "ProcessStep");

            migrationBuilder.DropColumn(
                name: "RecurrenceId",
                table: "ProcessStep");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PlantingEnvironment");

            migrationBuilder.AddColumn<string>(
                name: "EnvironmentType",
                table: "Tree",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlantTypeId",
                table: "Tree",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WaterLevel",
                table: "Tree",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProcessStepId",
                table: "Recurrence",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnvironmentType",
                table: "PlantingEnvironment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessStepId",
                table: "PlantingAction",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessStepId",
                table: "Notification",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlantType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tree_PlantTypeId",
                table: "Tree",
                column: "PlantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recurrence_ProcessStepId",
                table: "Recurrence",
                column: "ProcessStepId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingAction_ProcessStepId",
                table: "PlantingAction",
                column: "ProcessStepId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_ProcessStepId",
                table: "Notification",
                column: "ProcessStepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_ProcessStep_ProcessStepId",
                table: "Notification",
                column: "ProcessStepId",
                principalTable: "ProcessStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantingAction_ProcessStep_ProcessStepId",
                table: "PlantingAction",
                column: "ProcessStepId",
                principalTable: "ProcessStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recurrence_ProcessStep_ProcessStepId",
                table: "Recurrence",
                column: "ProcessStepId",
                principalTable: "ProcessStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tree_PlantType_PlantTypeId",
                table: "Tree",
                column: "PlantTypeId",
                principalTable: "PlantType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_ProcessStep_ProcessStepId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingAction_ProcessStep_ProcessStepId",
                table: "PlantingAction");

            migrationBuilder.DropForeignKey(
                name: "FK_Recurrence_ProcessStep_ProcessStepId",
                table: "Recurrence");

            migrationBuilder.DropForeignKey(
                name: "FK_Tree_PlantType_PlantTypeId",
                table: "Tree");

            migrationBuilder.DropTable(
                name: "PlantType");

            migrationBuilder.DropIndex(
                name: "IX_Tree_PlantTypeId",
                table: "Tree");

            migrationBuilder.DropIndex(
                name: "IX_Recurrence_ProcessStepId",
                table: "Recurrence");

            migrationBuilder.DropIndex(
                name: "IX_PlantingAction_ProcessStepId",
                table: "PlantingAction");

            migrationBuilder.DropIndex(
                name: "IX_Notification_ProcessStepId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "EnvironmentType",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "PlantTypeId",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "WaterLevel",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "ProcessStepId",
                table: "Recurrence");

            migrationBuilder.DropColumn(
                name: "EnvironmentType",
                table: "PlantingEnvironment");

            migrationBuilder.DropColumn(
                name: "ProcessStepId",
                table: "PlantingAction");

            migrationBuilder.DropColumn(
                name: "ProcessStepId",
                table: "Notification");

            migrationBuilder.AddColumn<string>(
                name: "GardenType",
                table: "Tree",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NotificationId",
                table: "ProcessStep",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlantingActionId",
                table: "ProcessStep",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecurrenceId",
                table: "ProcessStep",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "PlantingEnvironment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessStep_NotificationId",
                table: "ProcessStep",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessStep_PlantingActionId",
                table: "ProcessStep",
                column: "PlantingActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessStep_RecurrenceId",
                table: "ProcessStep",
                column: "RecurrenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessStep_Notification_NotificationId",
                table: "ProcessStep",
                column: "NotificationId",
                principalTable: "Notification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessStep_PlantingAction_PlantingActionId",
                table: "ProcessStep",
                column: "PlantingActionId",
                principalTable: "PlantingAction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessStep_Recurrence_RecurrenceId",
                table: "ProcessStep",
                column: "RecurrenceId",
                principalTable: "Recurrence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
