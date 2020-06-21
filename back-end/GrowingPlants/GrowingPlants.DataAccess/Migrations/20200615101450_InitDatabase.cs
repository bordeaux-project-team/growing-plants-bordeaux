using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "MeasurementUnit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnit", x => x.Id);
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
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Days = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recurrence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Humidity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FromUnit = table.Column<int>(nullable: false),
                    ToUnit = table.Column<int>(nullable: false),
                    MeasurementUnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humidity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Humidity_MeasurementUnit_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Light",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FromUnit = table.Column<int>(nullable: false),
                    ToUnit = table.Column<int>(nullable: false),
                    MeasurementUnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Light", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Light_MeasurementUnit_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnit",
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
                    Description = table.Column<string>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FromDegree = table.Column<int>(nullable: false),
                    ToDegree = table.Column<int>(nullable: false),
                    MeasurementUnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperature_MeasurementUnit_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Tree",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ComparisonWith = table.Column<string>(nullable: true),
                    ComparisonAgainst = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    GerminationTime = table.Column<int>(nullable: false),
                    VegetativeTime = table.Column<int>(nullable: false),
                    FloweringTime = table.Column<int>(nullable: false),
                    HarvestTime = table.Column<int>(nullable: false),
                    LightId = table.Column<int>(nullable: true),
                    TemperatureId = table.Column<int>(nullable: true),
                    HumidityId = table.Column<int>(nullable: true),
                    GardenType = table.Column<string>(nullable: true),
                    PlantingGuide = table.Column<string>(nullable: true),
                    ExposureTime = table.Column<int>(nullable: false),
                    PlantingEnvironmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tree_Humidity_HumidityId",
                        column: x => x.HumidityId,
                        principalTable: "Humidity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tree_Light_LightId",
                        column: x => x.LightId,
                        principalTable: "Light",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tree_PlantingEnvironment_PlantingEnvironmentId",
                        column: x => x.PlantingEnvironmentId,
                        principalTable: "PlantingEnvironment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tree_Temperature_TemperatureId",
                        column: x => x.TemperatureId,
                        principalTable: "Temperature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteTree",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    TreeId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    IsFavorite = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteTree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteTree_Tree_TreeId",
                        column: x => x.TreeId,
                        principalTable: "Tree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavoriteTree_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
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
                    HarvestDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantingProcess", x => x.Id);
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
                        name: "FK_ProcessStep_PlantingAction_PlantingActionId",
                        column: x => x.PlantingActionId,
                        principalTable: "PlantingAction",
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

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteTree_TreeId",
                table: "FavoriteTree",
                column: "TreeId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteTree_UserId",
                table: "FavoriteTree",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Humidity_MeasurementUnitId",
                table: "Humidity",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Light_MeasurementUnitId",
                table: "Light",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingAction_MeasurementUnitId",
                table: "PlantingAction",
                column: "MeasurementUnitId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Temperature_MeasurementUnitId",
                table: "Temperature",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Tree_HumidityId",
                table: "Tree",
                column: "HumidityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tree_LightId",
                table: "Tree",
                column: "LightId");

            migrationBuilder.CreateIndex(
                name: "IX_Tree_PlantingEnvironmentId",
                table: "Tree",
                column: "PlantingEnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tree_TemperatureId",
                table: "Tree",
                column: "TemperatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteTree");

            migrationBuilder.DropTable(
                name: "ProcessStep");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "PlantingAction");

            migrationBuilder.DropTable(
                name: "PlantingProcess");

            migrationBuilder.DropTable(
                name: "Recurrence");

            migrationBuilder.DropTable(
                name: "Tree");

            migrationBuilder.DropTable(
                name: "PlantingEnvironment");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Humidity");

            migrationBuilder.DropTable(
                name: "Light");

            migrationBuilder.DropTable(
                name: "Temperature");

            migrationBuilder.DropTable(
                name: "MeasurementUnit");
        }
    }
}
