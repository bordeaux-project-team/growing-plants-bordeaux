using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrowingPlants.DataAccess.Migrations
{
    public partial class AddTenTrees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tree",
                columns: new[] { "Id", "ComparisonAgainst", "ComparisonWith", "CreatedAt", "Description", "EnvironmentType", "ExposureTime", "FloweringTime", "GerminationTime", "HarvestTime", "Humidity", "Light", "Name", "PictureId", "PlantType", "PlantingGuide", "Temperature", "UpdatedAt", "VegetativeTime", "WaterLevel" },
                values: new object[,]
                {
                    { 1, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 564, DateTimeKind.Local).AddTicks(5124), "Chamaecyparis lawsoniana, known as Port Orford cedar or Lawson cypress, is a species of conifer in the genus Chamaecyparis, family Cupressaceae. It is native to Oregon and northwestern California, and grows from sea level up to 1,500 m (4,900 ft) in the valleys of the Klamath Mountains, often along streams", "Outdoor", 5, 12, 24, 30, "47", "88", "Chamaecyparis lawsoniana", null, "Tree", "Just water it", "36 Degree", null, 7, 8 },
                    { 2, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2480), "The blackberry is an edible fruit made by any of several species in the Rubus genus of the Rosaceae family. The blackberry shrub is called 'bramble' in Britain, but in the western U.S. 'caneberry' is the term is used for both blackberries and raspberries", "Indoor", 15, 32, 45, 23, "49", "48", "Blackberry", null, "Fruit", "Just water it", "16 Degree", null, 4, 14 },
                    { 3, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2503), "The apple tree (Malus domestica) is a tree that grows fruit (such as apples) in the rose family best known for its juicy, tasty fruit. It is grown worldwide as a fruit tree. It is considered to be a low-cost fruit harvestable all over the world.", "Indoor", 65, 12, 65, 10, "19", "49", "Apple", null, "Fruit", "Just water it", "16 Degree", null, 36, 24 },
                    { 4, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2507), "The pineapple is a fruit. It is native to South America, Central America and the Caribbean. The word 'pineapple' came from European explorers, who thought the fruit looked similar to a pine cone.", "Indoor", 11, 34, 32, 15, "15", "2", "Pineapple", null, "Fruit", "Just water it", "16 Degree", null, 31, 22 },
                    { 5, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2509), "A banana is the common name for a type of fruit and also the name for the herbaceous plants that grow it. These plants belong to the genus Musa. They are native to the tropical region of southeast Asia.", "Outdoor", 12, 12, 12, 15, "55", "10", "Banana", null, "Fruit", "Just water it", "50 Degree", null, 32, 4 },
                    { 6, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2514), "Umbellularia californica is a large hardwood tree native to coastal forests and the Sierra foothills of California, as well as to coastal forests extending into Oregon. It is endemic to the California Floristic Province. It is the sole species in the genus Umbellularia.", "Outdoor", 5, 12, 24, 30, "47", "88", "Umbellularia", null, "Herb", "Just water it", "36 Degree", null, 7, 8 },
                    { 7, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2516), "Myrrhis odorata, with common names cicely (/ˈsɪsəli/), sweet cicely, myrrh, garden myrrh, and sweet chervil, is a herbaceous perennial plant belonging to the celery family Apiaceae. It is one of two accepted species in the genus Myrrhis.", "Indoor", 15, 32, 45, 23, "49", "48", "Cicely", null, "Herb", "Just water it", "16 Degree", null, 4, 14 },
                    { 8, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2518), "Thai basil (Thai: โหระพา, RTGS: horapha, ISO: h̄oraphā, pronounced [hǒː.rá(ʔ).pʰāː]; Vietnamese: húng quế; in Taiwan: 九層塔) is a type of basil native to Southeast Asia that has been cultivated to provide distinctive traits. Widely used throughout Southeast Asia, its flavor, described as anise- and licorice-like and slightly spicy, is more stable under high or extended cooking temperatures than that of sweet basil. Thai basil has small, narrow leaves, purple stems, and pink-purple flowers.", "Outdoor", 65, 12, 65, 10, "19", "49", "Thai basil", null, "Herb", "Just water it", "16 Degree", null, 36, 24 },
                    { 9, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2520), "Ajwain, ajowan[3] (/ˈædʒəwɒn/), or Trachyspermum ammi—also known as ajowan caraway, bishop's weed,[4] or carom—is an annual herb in the family Apiaceae (or Umbelliferae). Both the leaves and the seed‑like fruit (often mistakenly called seeds) of the plant are consumed by humans. The name \"bishop's weed\" also is a common name for other plants. The \"seed\" (i.e., the fruit) is often confused with lovage \"seed\"", "Indoor", 11, 34, 32, 15, "15", "2", "Ajwain", null, "Herb", "Just water it", "16 Degree", null, 31, 22 },
                    { 10, "Unknown", "Unknown", new DateTime(2020, 8, 30, 9, 49, 0, 565, DateTimeKind.Local).AddTicks(2523), "Hornbeams are hardwood trees in the flowering plant genus Carpinus in the birch family Betulaceae. The 30–40 species occur across much of the temperate regions of the Northern Hemisphere.", "Outdoor", 12, 12, 12, 15, "55", "10", "Hornbeam", null, "Tree", "Just water it", "50 Degree", null, 32, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tree",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
