using Microsoft.EntityFrameworkCore.Migrations;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class UpdatePlantingSteps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_ProcessStep_ProcessStepId",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_ProcessStepId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "ProcessStepId",
                table: "Notification");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcessStepId",
                table: "Notification",
                type: "int",
                nullable: true);

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
        }
    }
}
