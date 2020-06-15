using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class AddPlantingProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlantingEnvironmentId",
                table: "Tree",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
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
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recurrence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recurrence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantingEnvironment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Width = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: true),
                    LightId = table.Column<int>(nullable: true),
                    TemperatureId = table.Column<int>(nullable: true),
                    HumidityId = table.Column<int>(nullable: true),
                    ExposureTime = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantingEnvironment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantingEnvironment_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantingEnvironment_Humidity_HumidityId",
                        column: x => x.HumidityId,
                        principalTable: "Humidity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantingEnvironment_Light_LightId",
                        column: x => x.LightId,
                        principalTable: "Light",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantingEnvironment_Temperature_TemperatureId",
                        column: x => x.TemperatureId,
                        principalTable: "Temperature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlantingProcess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    TreeId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    GerminationDate = table.Column<DateTime>(nullable: false),
                    VegetativeDate = table.Column<DateTime>(nullable: false),
                    FloweringDate = table.Column<DateTime>(nullable: false),
                    HarvestDate = table.Column<DateTime>(nullable: false),
                    PlantingEnvironmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantingProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantingProcess_PlantingEnvironment_PlantingEnvironmentId",
                        column: x => x.PlantingEnvironmentId,
                        principalTable: "PlantingEnvironment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantingProcess_Tree_TreeId",
                        column: x => x.TreeId,
                        principalTable: "Tree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProcessStep",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    PlantingActionId = table.Column<int>(nullable: true),
                    PlantingProcessId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    RecurrenceId = table.Column<int>(nullable: true),
                    NotificationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessStep_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProcessStep_PlantingProcess_PlantingProcessId",
                        column: x => x.PlantingProcessId,
                        principalTable: "PlantingProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProcessStep_Recurrence_RecurrenceId",
                        column: x => x.RecurrenceId,
                        principalTable: "Recurrence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlantingAction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    MeasurementUnitId = table.Column<int>(nullable: true),
                    ActionDescription = table.Column<string>(nullable: true),
                    ProcessStepId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantingAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantingAction_MeasurementUnit_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantingAction_ProcessStep_ProcessStepId",
                        column: x => x.ProcessStepId,
                        principalTable: "ProcessStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tree_PlantingEnvironmentId",
                table: "Tree",
                column: "PlantingEnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingAction_MeasurementUnitId",
                table: "PlantingAction",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingAction_ProcessStepId",
                table: "PlantingAction",
                column: "ProcessStepId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingEnvironment_CountryId",
                table: "PlantingEnvironment",
                column: "CountryId");

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

            migrationBuilder.CreateIndex(
                name: "IX_PlantingProcess_PlantingEnvironmentId",
                table: "PlantingProcess",
                column: "PlantingEnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingProcess_TreeId",
                table: "PlantingProcess",
                column: "TreeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessStep_NotificationId",
                table: "ProcessStep",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessStep_PlantingActionId",
                table: "ProcessStep",
                column: "PlantingActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessStep_PlantingProcessId",
                table: "ProcessStep",
                column: "PlantingProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessStep_RecurrenceId",
                table: "ProcessStep",
                column: "RecurrenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tree_PlantingEnvironment_PlantingEnvironmentId",
                table: "Tree",
                column: "PlantingEnvironmentId",
                principalTable: "PlantingEnvironment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessStep_PlantingAction_PlantingActionId",
                table: "ProcessStep",
                column: "PlantingActionId",
                principalTable: "PlantingAction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tree_PlantingEnvironment_PlantingEnvironmentId",
                table: "Tree");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantingAction_ProcessStep_ProcessStepId",
                table: "PlantingAction");

            migrationBuilder.DropTable(
                name: "ProcessStep");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "PlantingAction");

            migrationBuilder.DropTable(
                name: "PlantingProcess");

            migrationBuilder.DropTable(
                name: "Recurrence");

            migrationBuilder.DropTable(
                name: "PlantingEnvironment");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Tree_PlantingEnvironmentId",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "PlantingEnvironmentId",
                table: "Tree");
        }
    }
}
