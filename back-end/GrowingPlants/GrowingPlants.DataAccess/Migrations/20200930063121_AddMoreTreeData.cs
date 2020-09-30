using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class AddMoreTreeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tree",
                columns: new[] { "Id", "ComparisonAgainst", "ComparisonWith", "CreatedAt", "Description", "EnvironmentType", "ExposureTime", "FloweringTime", "GerminationTime", "HarvestTime", "Humidity", "Light", "Name", "PictureId", "PlantType", "PlantingGuide", "Temperature", "UpdatedAt", "VegetativeTime", "WaterLevel" },
                values: new object[,]
                {
                    { 11, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified), "A mango is a type of fruit. The mango tree is native to South Asia, from where it has been taken to become one of the most widely cultivated fruits in the tropics.It is harvested in the month of march (summer season) till the end of May.", "Outdoor", 5, 12, 24, 30, "47", "88", "Mango", null, "Fruit", "Just water it", "36 Degree", null, 7, 8 },
                    { 12, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified), "The lemon is a small tree (Citrus limon) that is green even in the winter. It came from Asia, and is also the name of the tree's oval-shaped yellow fruit.", "Indoor", 15, 32, 45, 23, "49", "48", "Lemon", null, "Fruit", "Just water it", "16 Degree", null, 4, 14 },
                    { 13, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified), "The peach is a species of the Prunus persica, and is a fruit tree of the rose family Rosaceae. They grow in the warm regions of both the northern and southern hemispheres.", "Indoor", 65, 12, 65, 10, "19", "49", "Peach", null, "Fruit", "Just water it", "16 Degree", null, 36, 24 },
                    { 14, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified), "Papaya is a tall herbaceous plant in the genus Carica; its edible fruit is also called papaya. It is native to the tropical region of America, mainly from southern Mexico to Central America. Now these plants are grown in all tropical regions of the world", "Indoor", 11, 34, 32, 15, "15", "2", "Papaya", null, "Fruit", "Just water it", "16 Degree", null, 31, 22 },
                    { 15, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified), "Jackfruit (also called \"Jakfruit\") is a type of fruit from India, Bangladesh (National fruit)[source?] and Sri Lanka.[1] When a Jackfruit ripens, it changes from green to slightly yellow.", "Outdoor", 12, 12, 12, 15, "55", "10", "Jackfruit", null, "Fruit", "Just water it", "50 Degree", null, 32, 4 },
                    { 16, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified), "A melon is any kind of edible, fleshy fruit in the Cucurbitaceae family. Many different cultivars have been produced, especially of muskmelons. Botanically speaking, the melon is a fruit, but some kinds are often considered vegetables. Most melons belong to the genus Cucumis, but there are also some that belong to Benincasa, Citrullus and Momordica. The muskmelon belongs to Cucumis, while the watermelon belongs to Citrullus", "Outdoor", 5, 12, 24, 30, "47", "88", "Melon", null, "Fruit", "Just water it", "36 Degree", null, 7, 8 },
                    { 17, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified), "The tomato (Solanum lycopersicum) is a botanical fruit (but not a fruit as ordinary people use the word).", "Indoor", 15, 32, 45, 23, "49", "48", "Tomato", null, "Fruit", "Just water it", "16 Degree", null, 4, 14 },
                    { 18, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified), "Longan (scientific name: Dimocarpus longan) is the name for a tree in the Sapindaceae (soapberry) family. It comes from the southern part of Asia and is related to the lychee.", "Outdoor", 65, 12, 65, 10, "19", "49", "Longan", null, "Herb", "Just water it", "16 Degree", null, 36, 24 },
                    { 19, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified), "Apricot is a drupe fruit. It is closely related to the plum.", "Indoor", 11, 34, 32, 15, "15", "2", "Apricot", null, "Fruit", "Just water it", "16 Degree", null, 31, 22 },
                    { 20, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 0, DateTimeKind.Unspecified), "The coconut palm is a palm tree in the family Arecaceae (palm family). It is a large palm, growing to 30 m tall. It has leaves that are 4–6 m long. The term coconut refers to the fruit of the coconut palm. The coconut tree is a monocot.", "Outdoor", 12, 12, 12, 15, "55", "10", "Coconut", null, "Tree", "Just water it", "50 Degree", null, 32, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
