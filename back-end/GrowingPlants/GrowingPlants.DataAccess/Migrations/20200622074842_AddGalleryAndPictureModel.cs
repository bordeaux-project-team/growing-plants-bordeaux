using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class AddGalleryAndPictureModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Tree");

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Tree",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PlantingProcessId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gallery_PlantingProcess_PlantingProcessId",
                        column: x => x.PlantingProcessId,
                        principalTable: "PlantingProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Source = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GalleryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Picture_Gallery_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Gallery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tree_PictureId",
                table: "Tree",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_PlantingProcessId",
                table: "Gallery",
                column: "PlantingProcessId",
                unique: true,
                filter: "[PlantingProcessId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_GalleryId",
                table: "Picture",
                column: "GalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tree_Picture_PictureId",
                table: "Tree",
                column: "PictureId",
                principalTable: "Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tree_Picture_PictureId",
                table: "Tree");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Gallery");

            migrationBuilder.DropIndex(
                name: "IX_Tree_PictureId",
                table: "Tree");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Tree");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Tree",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
